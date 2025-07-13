using HRManagement.Business.Dtos.Employees;
using HRManagement.Business.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using HRManagement.Business.dtos.Employees;

namespace ManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        //Khánh làm: Lấy thông tin của các nhân viên
        [HttpGet("All-Employees")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();

                if (employees == null || !employees.Any())
                {
                    return NotFound(new { message = "No employees found." });
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }
        //Khánh làm: cập nhật thông tin của nhân viên
        [HttpPut("Update-Employee")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null || employeeDto.Id <= 0)
            {
                return BadRequest("Invalid employee data.");
            }

            try
            {
                var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employeeDto);
                if (updatedEmployee == null)
                {
                    return NotFound(new { message = "Employee not found." });
                }

                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }
        //Khánh làm: Lấy thông tin của nhân viên theo ID
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Missing ID.");

            if (!int.TryParse(id, out var parsedId))
                return BadRequest("Invalid ID format.");

            var employee = await _employeeService.GetEmployeeByIdAsync(parsedId);

            if (employee == null)
                return NotFound();

            return Ok(employee);
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