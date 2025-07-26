using AutoMapper;
using HRManagement.Business.dtos.contractType;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractTypeController : ControllerBase
{
    private readonly ILogger<ContractTypeController> _logger;
    private readonly IContractTypeRepository _contractTypeRepository;
    private readonly IMapper _mapper;
    public ContractTypeController(ILogger<ContractTypeController> logger, IContractTypeRepository contractTypeRepository, IMapper mapper)
    {
        _logger = logger;
        _contractTypeRepository = contractTypeRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber , [FromQuery] int pageSize)
    {
        try
        {
            var cts = await _contractTypeRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<ContractType>>(cts));
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
            var ct = await _contractTypeRepository.GetByIdAsync(id);
            if (ct == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ContractTypeGet>(ct));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ContractTypeCreate ctDto)
    {
        try
        {
            var ct = _mapper.Map<ContractType>(ctDto);

            await _contractTypeRepository.AddAsync(ct);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = ct.ContractTypeID }, _mapper.Map<ContractTypeGet>(ct));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ContractTypeCreate ctDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ct = await _contractTypeRepository.GetByIdAsync(id);

            if (ct == null)
            {
                return NotFound();
            }

            _mapper.Map(ctDto, ct);

            await _contractTypeRepository.UpdateAsync(ct);

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
            var ct = await _contractTypeRepository.GetByIdAsync(id);

            if (ct == null)
            {
                return NotFound();
            }

            await _contractTypeRepository.DeleteAsync(id);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }
}