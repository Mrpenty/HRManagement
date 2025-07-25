using AutoMapper;
using HRManagement.Business.dtos.employeeLevel;
using HRManagement.Business.dtos.page;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeLevelController : ControllerBase
{
    private readonly ILogger<EmployeeLevelController> _logger;
    private readonly IEmployeeLevelRepository _employeeLevelRepository;
    private readonly IMapper _mapper;
    public EmployeeLevelController(ILogger<EmployeeLevelController> logger, IEmployeeLevelRepository employeeLevelRepository, IMapper mapper)
    {
        _logger = logger;
        _employeeLevelRepository = employeeLevelRepository;
        _mapper = mapper;
    }
    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        try
            {
                var els = await _employeeLevelRepository.GetAsync();
                return Ok(_mapper.Map<IEnumerable<EmployeeLevel>>(els));
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
            var el = await _employeeLevelRepository.GetByIdAsync(id);
            if (el == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeLevelGet>(el));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] EmployeeLevelCreate ctDto)
    {
        try
        {
            var el = _mapper.Map<EmployeeLevel>(ctDto);

            await _employeeLevelRepository.AddAsync(el);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = el.EmployeeLevelID }, _mapper.Map<EmployeeLevelGet>(el));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeLevelCreate ctDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ct = await _employeeLevelRepository.GetByIdAsync(id);

            if (ct == null)
            {
                return NotFound();
            }

            _mapper.Map(ctDto, ct);

            await _employeeLevelRepository.UpdateAsync(ct);

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
            var ct = await _employeeLevelRepository.GetByIdAsync(id);

            if (ct == null)
            {
                return NotFound();
            }

            await _employeeLevelRepository.DeleteAsync(id);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }
}