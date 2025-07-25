using AutoMapper;
using HRManagement.Business.dtos.leaveRequest;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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

    [HttpGet]
    [EnableQuery]
    [Authorize]
    public IActionResult GetAllAsync()
    {
        try
        {
            var query = _leaveRequestRepository.GetQueryable();

            var lrDto = _mapper.ProjectTo<LeaveRequestGet>(query);

            return Ok(lrDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetByIdAsync))]
    [Authorize]
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

    [HttpPost("{id:int}")]
    [Authorize]
    public async Task<IActionResult> CreateAsync(int id, [FromBody] LeaveRequestCreate lrDto)
    {
        try
        {
            if (lrDto.StartDate > lrDto.EndDate)
                return BadRequest("Ngày bắt đầu không được sau ngày kết thúc.");

            if (lrDto.StartDate.Date < DateTime.Today)
                return BadRequest("Ngày bắt đầu không được ở quá khứ.");

            if (string.IsNullOrWhiteSpace(lrDto.LeaveType))
                return BadRequest("Loại nghỉ phép không được để trống.");

            // ✅ Check quota 12 ngày
            var leavesThisYear = await _leaveRequestRepository.GetMyLeavesInYearAsync(id, DateTime.Today.Year);
            int totalUsed = leavesThisYear
                .Where(lr => lr.Status == "Approved" || lr.Status == "Pending")
                .Sum(lr => (lr.EndDate - lr.StartDate).Days + 1);

            int daysRequested = (lrDto.EndDate - lrDto.StartDate).Days + 1;

            if (totalUsed + daysRequested > 12)
                return BadRequest($"Bạn còn {12 - totalUsed} ngày phép. Không thể tạo đơn vượt quá.");

            var leaveRequest = _mapper.Map<LeaveRequest>(lrDto);
            leaveRequest.UserID = id;
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

            if (leaveRequest.Status != "Pending")
            {
                return BadRequest("Only requests with status 'Pending' can be updated.");
            }

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

    [HttpPut("{id:int}/approve")]
    [Authorize(Roles = "HR")]
    public async Task<IActionResult> UpdateStatus(int id)
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

            if (leaveRequest.Status == "Approved")
            {
                return BadRequest("Already Approved");
            }


            leaveRequest.Status = "Approved";

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    [Authorize]
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


    [HttpGet("{id:int}/remaining-days")]
    [Authorize]
    public async Task<IActionResult> GetRemainingDays(int id)
    {
        var leaves = await _leaveRequestRepository.GetMyLeavesInYearAsync(id, DateTime.Now.Year);

        int totalUsed = leaves
            .Where(lr => lr.Status == "Approved" || lr.Status == "Pending")
            .Sum(lr => (lr.EndDate - lr.StartDate).Days + 1);

        int remaining = 12 - totalUsed;

        return Ok(new { Used = totalUsed, Remaining = remaining });
    }

    [HttpGet("GetLeaveRequestByUserId/{userId:int}")]
    [Authorize]
    public async Task<IActionResult> GetLeaveRequestByUserId(int userId)
    {
        var leaves = await _leaveRequestRepository.GetMyLeavesInYearAsync(userId, DateTime.Now.Year);

        return Ok(leaves);
    }
}