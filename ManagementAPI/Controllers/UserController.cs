using AutoMapper;
using HRManagement.Business.dtos.Employees;
using HRManagement.Business.dtos.user;
using HRManagement.Business.Repositories;
using HRManagement.Business.Services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly HRManagement.Data.Data.HRManagementDbContext _dbContext;
    private readonly IEmployeeService _employeeService;

    

    public UserController(ILogger<UserController> logger, IMapper mapper, IUserRepository userRepository, IEmployeeService employeeService)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
        _employeeService = employeeService;
    }

    [HttpGet]
    
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var users = await _userRepository.GetAsync();
            var usersDto = _mapper.Map<IEnumerable<UserGet>>(users);
            return Ok(usersDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }

    }

    [HttpGet("{id:int}")]
    
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserGet>(user);
            return Ok(userDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }

    }

    [HttpPut("{id:int}")]
    
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserUpdate userDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }

            _mapper.Map(userDto, user);

            await _userRepository.UpdateAsync(user);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            var deleted = await _userRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound("User Not Found!");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");          
        }
    }

    [HttpPost("{id:int}/assign-role")]
    public async Task<IActionResult> AssignRoleAsync([FromRoute] int id, [FromBody] string role)
    {
        try
        {
            var success = await _userRepository.AssignRoleAsync(id, role);
            if (!success)
            {
                return BadRequest("User Not Found or Role Does Not Exist!");
            }
            return Ok($"User with ID {id} assigned to role {role}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");  
        }
    }

    [HttpPost("WithSalary")]
    public async Task<IActionResult> CreateEmployeeWithSalary([FromBody] EmployeeWithSalaryCreateDto dto)
    {
        try
        {
            var employeeId = await _employeeService.CreateEmployeeWithSalaryAsync(dto);
            return Ok(new { Id = employeeId });
        }
        catch
        {
            return BadRequest("Error creating employee and salary");
        }
    }
}