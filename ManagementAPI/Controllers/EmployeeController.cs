using HRManagement.Business.Dtos.Employees;
using HRManagement.Business.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.Threading.Tasks;

namespace ManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("AttendanceSummary")]
        public async Task<IActionResult> GetAttendanceSummary([FromQuery] string month)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            if (!DateTime.TryParse(month + "-01", out var date))
                return BadRequest("Invalid month format");

            var summary = await _employeeService.GetAttendanceSummaryAsync(userId, date.Year, date.Month);
            return Ok(summary);
        }
    }
} 