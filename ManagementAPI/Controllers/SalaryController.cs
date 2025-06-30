using AutoMapper;
using HRManagement.Business.dtos.salary;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    private readonly ILogger<SalaryController> _logger;
    private readonly ISalaryRepository _salaryRepository;
    private readonly IMapper _mapper;
    public SalaryController(ILogger<SalaryController> logger, ISalaryRepository salaryRepository, IMapper mapper)
    {
        _logger = logger;
        _salaryRepository = salaryRepository;
        _mapper = mapper;
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
}