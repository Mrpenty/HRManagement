using AutoMapper;
using HRManagement.Business.dtos.leaveRequest;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestController : ControllerBase
{
    private readonly ILogger<LeaveRequestController> _logger;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    public LeaveRequestController(ILogger<LeaveRequestController> logger, ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _logger = logger;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");
        if (userIdClaim == null) throw new UnauthorizedAccessException();
        return int.Parse(userIdClaim.Value);
    }

    [Authorize(Roles = "HR")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var leaveRequests = await _leaveRequestRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<LeaveRequest>>(leaveRequests));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LeaveRequestGet>(leaveRequest));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    // Trí làm: Tạo đơn xin nghỉ phép    
    [HttpPost]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> CreateAsync([FromBody] LeaveRequestCreate lrDto)
    {
        try
        {
            int userId = GetCurrentUserId();

            if (lrDto.StartDate > lrDto.EndDate)
                return BadRequest("Ngày bắt đầu không được sau ngày kết thúc.");

            if (lrDto.StartDate.Date < DateTime.Today)
                return BadRequest("Ngày bắt đầu không được ở quá khứ.");

            if (string.IsNullOrWhiteSpace(lrDto.LeaveType))
                return BadRequest("Loại nghỉ phép không được để trống.");

            // ✅ Check quota 12 ngày
            var leavesThisYear = await _leaveRequestRepository.GetMyLeavesInYearAsync(userId, DateTime.Today.Year);
            int totalUsed = leavesThisYear
                .Where(lr => lr.Status == "Approved" || lr.Status == "Pending")
                .Sum(lr => (lr.EndDate - lr.StartDate).Days + 1);

            int daysRequested = (lrDto.EndDate - lrDto.StartDate).Days + 1;

            if (totalUsed + daysRequested > 12)
                return BadRequest($"Bạn còn {12 - totalUsed} ngày phép. Không thể tạo đơn vượt quá.");

            var leaveRequest = _mapper.Map<LeaveRequest>(lrDto);
            leaveRequest.UserID = userId;
            leaveRequest.Status = "Pending";
            leaveRequest.CreatedAt = DateTime.Now;
            leaveRequest.UpdatedAt = DateTime.Now;

            await _leaveRequestRepository.AddAsync(leaveRequest);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = leaveRequest.LeaveRequestID }, _mapper.Map<LeaveRequestGet>(leaveRequest));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }

    }


    //Trí làm: Sửa đơn xin nghỉ phép
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] LeaveRequestCreate lrDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            // ✅ Chỉ cho update nếu đơn chưa được duyệt
            if (leaveRequest.Status != "Pending")
            {
                return BadRequest("Only requests with status 'Pending' can be updated.");
            }

            // ✅ Cập nhật trường cho phép
            leaveRequest.StartDate = lrDto.StartDate;
            leaveRequest.EndDate = lrDto.EndDate;
            leaveRequest.LeaveType = lrDto.LeaveType;
            leaveRequest.Reason = lrDto.Reason;

            leaveRequest.UpdatedAt = DateTime.UtcNow;

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    //Trí làm: Xóa đơn nghỉ phép
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            await _leaveRequestRepository.DeleteAsync(id);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    //Trí làm: Lấy tất cả đơn nghỉ phép của mình
    [HttpGet("my-leaves")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> GetMyLeaves()
    {
        try
        {
            int userId = GetCurrentUserId();

            var now = DateTime.Now;
            Console.WriteLine($"[DEBUG] Now: {now}");
            var leaves = await _leaveRequestRepository.GetMyLeavesInMonthAsync(userId, now.Month, now.Year);
            Console.WriteLine($"[DEBUG] UserID: {userId}");
            Console.WriteLine($"[DEBUG] Found {leaves.Count} leaves");
            foreach (var lr in leaves)
            {
                Console.WriteLine($" - ID: {lr.LeaveRequestID}, Start: {lr.StartDate}, End: {lr.EndDate}, Status: {lr.Status}");
            }
            var result = leaves.Select(lr => new LeaveViewDto
            {
                LeaveRequestID = lr.LeaveRequestID,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = lr.LeaveType,
                Status = lr.Status
            }).ToList();
            foreach (var r in result)
            {
                Console.WriteLine($" - DTO ID: {r.LeaveRequestID}, Start: {r.StartDate}, End: {r.EndDate}, Status: {r.Status}");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting my leaves");
            return StatusCode(500, "Internal Server Error");
        }
    }

    //Trí làm: Tính số ngày nghỉ phép
    [HttpGet("remaining-days")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> GetRemainingDays()
    {
        int userId = GetCurrentUserId();
        var leaves = await _leaveRequestRepository.GetMyLeavesInYearAsync(userId, DateTime.Now.Year);

        int totalUsed = leaves
            .Where(lr => lr.Status == "Approved" || lr.Status == "Pending")
            .Sum(lr => (lr.EndDate - lr.StartDate).Days + 1);

        int remaining = 12 - totalUsed;

        return Ok(new { Used = totalUsed, Remaining = remaining });
    }

}