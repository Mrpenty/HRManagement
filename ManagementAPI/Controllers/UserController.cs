using AutoMapper;
using HRManagement.Business.dtos.user;
using HRManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase 
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    [HttpGet]
    [EnableQuery(PageSize = 10)]
    public IActionResult GetAllAsync()
    {
        try
        {
            var query = _userRepository.GetQueryable();

            var usersWithRoles = query
                .Select(u => new UserGet
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    DateOfBirth = u.DateOfBirth,
                    HireDate = u.HireDate,
                    ProfilePicture = u.ProfilePicture,
                    IsVertify = u.IsVertify,
                    Status = u.Status,
                    DepartmentID = u.DepartmentID,
                    EmployeeLevelID = u.EmployeeLevelID,
                    ContractTypeID = u.ContractTypeID,
                    PositionID = u.PositionID,

                    RoleIds = _userRepository
                    .GetDbContext()
                    .UserRoles
                    .Where(ur => ur.UserId == u.Id)
                    .Select(ur => ur.RoleId)
                    .ToList()
                });

            return Ok(usersWithRoles);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving users");
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
                return NotFound("User Not Found!");
            }
            var userDto = _mapper.Map<UserGet>(user);
            return Ok(userDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving user with ID {Id}", id);
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
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Failed to update user with ID {Id}", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating user with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Failed to delete user with ID {Id}", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting user with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("{id:int}/assign-role")]
    public async Task<IActionResult> AssignRoleAsync([FromRoute] int id, [FromBody] string role)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return BadRequest("Role cannot be null or empty.");
            }

            var success = await _userRepository.AssignRoleAsync(id, role);
            if (!success)
            {
                return BadRequest("User Not Found or Role Does Not Exist!");
            }
            return Ok($"User with ID {id} assigned to role {role}");
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid role for user with ID {Id}", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while assigning role to user with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}