using HRManagement.Business.DTO;
using HRManagement.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly HRManagementDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<IdentityUser> userManager, HRManagementDbContext context, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Invalid login request");
            }

            _logger.LogInformation("Attempting to find user: {Username}", loginModel.Username);
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user == null)
            {
                _logger.LogWarning("User not found: {Username}", loginModel.Username);
                return Unauthorized("Invalid username");
            }

            _logger.LogInformation("Checking password for user: {Username}", loginModel.Username);
            var result = await _userManager.CheckPasswordAsync(user, loginModel.Password);
            if (!result)
            {
                _logger.LogWarning("Invalid password for user: {Username}", loginModel.Username);
                return Unauthorized("Invalid password");
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Username == loginModel.Username);
            if (employee == null)
            {
                _logger.LogWarning("Employee data not found for username: {Username}", loginModel.Username);
                return Unauthorized("Employee data not found");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, employee.Username),
                new Claim(ClaimTypes.Role, employee.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            if (key.KeySize < 256)
            {
                _logger.LogError("JWT Key size ({KeySize} bits) is less than 256 bits", key.KeySize);
                return StatusCode(500, "Internal server error: Invalid JWT key size");
            }

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            _logger.LogInformation("Login successful for user: {Username}", loginModel.Username);
            return Ok(new { token = tokenString });
        }
    


}
    
}
