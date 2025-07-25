using AutoMapper;
using HRManagement.Business.dtos.attendance;
using HRManagement.Business.Repositories;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly ILogger<AttendanceController> _logger;
    private readonly IAttdendanceRepository _attdendanceRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly HRManagementDbContext _context;
    public AttendanceController(ILogger<AttendanceController> logger, IAttdendanceRepository attdendanceRepository, ILeaveRequestRepository leaveRequestRepository,IMapper mapper, HRManagementDbContext context)
    {
        _logger = logger;
        _attdendanceRepository = attdendanceRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _context = context;
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");
        if (userIdClaim == null) throw new UnauthorizedAccessException();
        return int.Parse(userIdClaim.Value);
    }

    [HttpGet("daily")]
    public async Task<IActionResult> GetDailyAttendanceAsync([FromQuery] DateTime date)
    {
        try
        {
            var result = await _attdendanceRepository.GetDailyAttendanceStatusAsync(date);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetDailyAttendance");
            return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
        }
    }

    [HttpGet]
    [EnableQuery]
    public IActionResult GetAllAsync()
    {
        try
        {
            var query = _attdendanceRepository.GetQueryable();

            var attendanceDto = _mapper.ProjectTo<AttendanceGet>(query);

            return Ok(attendanceDto);
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
            var attdendance = await _attdendanceRepository.GetByIdAsync(id);
            if (attdendance == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AttendanceGet>(attdendance));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] AttendanceCreate atDto)
    {
        try
        {
            var attdendance = _mapper.Map<Attendance>(atDto);

            await _attdendanceRepository.AddAsync(attdendance);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = attdendance.AttendanceID }, _mapper.Map<AttendanceGet>(attdendance));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] AttendanceCreate atDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attdendance = await _attdendanceRepository.GetByIdAsync(id);

            if (attdendance == null)
            {
                return NotFound();
            }

            _mapper.Map(atDto, attdendance);

            await _attdendanceRepository.UpdateAsync(attdendance);

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
            var department = await _attdendanceRepository.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            await _attdendanceRepository.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    //Trí làm: Check-in có mặt
    [HttpPost("{id:int}/check-in")]
    [Authorize]
    public async Task<IActionResult> CheckInAsync(int id)
    {
        var today = DateTime.Today; // Local date, OK

        var record = await _context.Attendances
            .FirstOrDefaultAsync(x => x.UserID == id && x.AttendanceDate == today);

        var nowUtc = DateTime.UtcNow;
        var nowLocal = nowUtc.ToLocalTime();

        if (record == null)
        {
            record = new Attendance
            {
                UserID = id,
                AttendanceDate = today,
                CheckInTime = nowUtc,
                Status = nowLocal.TimeOfDay <= new TimeSpan(8, 0, 0) ? "OnTime" : "Late",
                Location = "Office",
                CreatedAt = nowUtc,
                UpdatedAt = nowUtc
            };
            _context.Attendances.Add(record);
        }
        else
        {
            if (record.CheckInTime != null)
                return BadRequest("Đã check-in rồi.");

            record.CheckInTime = nowUtc;
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    //Trí làm: Check-out kèm tính Work Hour và OT
    [HttpPost("{id:int}/check-out")]
    [Authorize]
    public async Task<IActionResult> CheckOutAsync(int id)
    {
        var today = DateTime.Today;

        var att = await _context.Attendances
            .FirstOrDefaultAsync(a => a.UserID == id && a.AttendanceDate == today);

        if (att == null) return BadRequest("Bạn chưa check-in hôm nay.");
        if (!att.CheckInTime.HasValue) return BadRequest("Bạn chưa check-in hôm nay.");

        var nowUtc = DateTime.UtcNow;
        var nowLocal = nowUtc.ToLocalTime();

        att.CheckOutTime = nowUtc;
        att.WorkHours = (decimal)(att.CheckOutTime.Value - att.CheckInTime.Value).TotalHours;
        att.OvertimeHours = (decimal)(att.WorkHours > 8 ? att.WorkHours - 8 : 0);

        if (nowLocal.TimeOfDay < new TimeSpan(15, 0, 0))
            att.Status = "LeftEarly";

        att.UpdatedAt = nowUtc;

        _context.Attendances.Update(att);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Checked out!", time = att.CheckOutTime, status = att.Status });
    }
}