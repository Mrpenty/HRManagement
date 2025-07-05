using AutoMapper;
using HRManagement.Business.dtos.salary;
using HRManagement.Business.Repositories;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    private readonly ILogger<SalaryController> _logger;
    private readonly ISalaryRepository _salaryRepository;
    private readonly HRManagementDbContext _context;
    private readonly IMapper _mapper;
    public SalaryController(ILogger<SalaryController> logger, ISalaryRepository salaryRepository, HRManagementDbContext context, IMapper mapper)
    {
        _logger = logger;
        _salaryRepository = salaryRepository;
        _mapper = mapper;
        _context = context;
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");
        if (userIdClaim == null) throw new UnauthorizedAccessException();
        return int.Parse(userIdClaim.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var salaries = await _salaryRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<Salary>>(salaries));
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
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SalaryGet>(salary));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] SalaryCreate salaryDto)
    {
        try
        {
            var salary = _mapper.Map<Salary>(salaryDto);

            await _salaryRepository.AddAsync(salary);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = salary.SalaryID }, _mapper.Map<SalaryGet>(salary));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SalaryCreate salaryDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salary = await _salaryRepository.GetByIdAsync(id);

            if (salary == null)
            {
                return NotFound();
            }

            _mapper.Map(salaryDto, salary);

            await _salaryRepository.UpdateAsync(salary);

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
            var salary = await _salaryRepository.GetByIdAsync(id);

            if (salary == null)
            {
                return NotFound();
            }

            await _salaryRepository.DeleteAsync(id);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    //Trí làm: Employee xem lương của mình
    [HttpGet("my-salary")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> GetMySalaryAsync()
    {
        int userId = GetCurrentUserId();
        int month = DateTime.Today.Month;
        int year = DateTime.Today.Year;

        var salary = await _context.Salaries
            .Where(s => s.UserID == userId && s.SalaryPeriod.Month == month && s.SalaryPeriod.Year == year)
            .FirstOrDefaultAsync();

        if (salary == null)
            return NotFound("Salary record not found.");

        var dto = new SalaryDto
        {
            BaseSalary = salary.BaseSalary,
            Allowances = salary.Allowances,
            Bonus = salary.Bonus,
            Deduction = salary.Deduction,
            Tax = salary.Tax,
            NetSalary = salary.NetSalary,
            SalaryPeriod = salary.SalaryPeriod.ToString("MM/yyyy")
        };

        return Ok(dto);
    }

}