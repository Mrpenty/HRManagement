using AutoMapper;
using HRManagement.Business.dtos.attendance;
using HRManagement.Business.Repositories;
using HRManagement.Business.Repositories.impl;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly ILogger<AttendanceController> _logger;
    private readonly IAttdendanceRepository _attdendanceRepository;
    private readonly IMapper _mapper;
    public AttendanceController(ILogger<AttendanceController> logger, IAttdendanceRepository attdendanceRepository, IMapper mapper)
    {
        _logger = logger;
        _attdendanceRepository = attdendanceRepository;
        _mapper = mapper;
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
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var attdendances = await _attdendanceRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<Attendance>>(attdendances));
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

    //Trí làm: Controller View danh sách số ngày đã chấm công của người đang đăng nhập
    [HttpGet("my-attendance")]
    public async Task<IActionResult> GetMyAttendanceAsync()
    {
        try
        {
            // Lấy UserID từ claim JWT
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserID");
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim.Value);

            var attendances = await _attdendanceRepository.GetByUserIdAsync(userId);

            return Ok(attendances.Select(a => new
            {
                a.AttendanceID,
                a.AttendanceDate,
                a.CheckInTime,
                a.CheckOutTime,
                a.WorkHours,
                a.OvertimeHours
            }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when getting attendance");
            return StatusCode(500, "Internal server error");
        }
    }
}