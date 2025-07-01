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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] LeaveRequestCreate lrDto)
    {
        try
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(lrDto);

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

            _mapper.Map(lrDto, leaveRequest);

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

    [HttpGet("my-leaves")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> GetMyLeaves()
    {
        try
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

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
}