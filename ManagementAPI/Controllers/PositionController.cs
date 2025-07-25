using AutoMapper;
using HRManagement.Business.dtos.page;
using HRManagement.Business.dtos.position;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private readonly ILogger<PositionController> _logger;
    private readonly IPositionRepository _positionRepository;
    private readonly IMapper _mapper;
    public PositionController(ILogger<PositionController> logger, IPositionRepository positionRepository, IMapper mapper)
    {
        _logger = logger;
        _positionRepository = positionRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAllAsync()
    {
        try
        {
            var query = _positionRepository.GetQueryable();
            var positionDto = _mapper.ProjectTo<PositionGet>(query);

            return Ok(positionDto);
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
            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PositionGet>(position));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PositionCreate ctDto)
    {
        try
        {
            var position = _mapper.Map<Position>(ctDto);

            await _positionRepository.AddAsync(position);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = position.PositionID }, _mapper.Map<PositionGet>(position));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PositionCreate ctDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var position = await _positionRepository.GetByIdAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            _mapper.Map(ctDto, position);

            await _positionRepository.UpdateAsync(position);

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
            var position = await _positionRepository.GetByIdAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            await _positionRepository.DeleteAsync(id);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }
}