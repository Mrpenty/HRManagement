using HRManagement.Business.Dtos.Employees;
using HRManagement.Business.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _environment = environment;
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException("User ID not found in token."));
            var profile = await _employeeService.GetEmployeeByIdAsync(userId, User);
            return Ok(profile);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateUserProfileDTO dto, IFormFile? profilePicture)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _employeeService.UpdateEmployeeAsync(userId, dto, profilePicture, User);
            return Ok(new { message = "Profile updated successfully." });
        }
    }
}

