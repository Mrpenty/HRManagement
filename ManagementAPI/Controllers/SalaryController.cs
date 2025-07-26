using AutoMapper;
using HRManagement.Business.dtos.salary;
using HRManagement.Business.Repositories;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    private readonly ILogger<SalaryController> _logger;
    private readonly ISalaryRepository _salaryRepository;
    private readonly IUserRepository _userRepository;
    private readonly HRManagementDbContext _context;
    private readonly IMapper _mapper;
    public SalaryController(ILogger<SalaryController> logger, ISalaryRepository salaryRepository, IUserRepository userRepository, HRManagementDbContext context, IMapper mapper)
    {
        _logger = logger;
        _salaryRepository = salaryRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    [EnableQuery]
    [Authorize]
    public IActionResult GetAllAsync()
    {
        try
        {
            var query = _salaryRepository.GetQueryable();
            var salaryDto = _mapper.ProjectTo<SalaryGet>(query);

            return Ok(salaryDto);
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
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] SalaryCreate salaryDto)
    {
        try
        {
            decimal taxRate = 0.1m;
            decimal taxableIncome = salaryDto.BaseSalary + salaryDto.Allowances + salaryDto.Bonus;
            decimal tax = taxableIncome * taxRate;
            decimal netSalary = taxableIncome - tax - salaryDto.Deduction;

            var salary = _mapper.Map<Salary>(salaryDto);
            salary.Tax = tax;
            salary.NetSalary = netSalary;

            await _salaryRepository.AddAsync(salary);
            
            var user = await _userRepository.GetByIdAsync(salaryDto.UserID);
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found for salary assignment", salaryDto.UserID);
                return BadRequest("User not found");
            }

            user.SalaryID = salary.SalaryID; 
            await _userRepository.UpdateAsync(user);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = salary.SalaryID },
                _mapper.Map<SalaryGet>(salary));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating salary");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    [Authorize]
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
    [HttpGet("{id:int}/my-salary")]
    [Authorize]
    public async Task<IActionResult> GetMySalaryAsync(int id)
    {
        int month = DateTime.Today.Month;
        int year = DateTime.Today.Year;

        var salary = await _context.Salaries
            .Where(s => s.UserID == id && s.SalaryPeriod.Month == month && s.SalaryPeriod.Year == year)
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