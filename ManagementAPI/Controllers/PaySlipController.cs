using AutoMapper;
using HRManagement.Business.dtos.Payslip;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaySlipController : ControllerBase
{
    private readonly ILogger<PaySlipController> _logger;
    private readonly IPaySlipRepository _paySlipRepository;
    private readonly IMapper _mapper;
    public PaySlipController(ILogger<PaySlipController> logger, IPaySlipRepository paySlipRepository, IMapper mapper)
    {
        _logger = logger;
        _paySlipRepository = paySlipRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var paySlips = await _paySlipRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<Payslip>>(paySlips));
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
            var paySlip = await _paySlipRepository.GetByIdAsync(id);
            if (paySlip == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PaySlipGet>(paySlip));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PaySlipCreate psDto)
    {
        try
        {
            var paySlip = _mapper.Map<Payslip>(psDto);

            await _paySlipRepository.AddAsync(paySlip);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = paySlip.PayslipID }, _mapper.Map<PaySlipGet>(paySlip));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PaySlipCreate psDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paySlip = await _paySlipRepository.GetByIdAsync(id);

            if (paySlip == null)
            {
                return NotFound();
            }

            _mapper.Map(psDto, paySlip);

            await _paySlipRepository.UpdateAsync(paySlip);

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
            var Payslip = await _paySlipRepository.GetByIdAsync(id);

            if (Payslip == null)
            {
                return NotFound();
            }

            await _paySlipRepository.DeleteAsync(id);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
            return StatusCode(500, "Internal server error");
        }
    }
}