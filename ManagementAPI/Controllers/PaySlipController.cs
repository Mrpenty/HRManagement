using AutoMapper;
using HRManagement.Business.dtos.Payslip;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaySlipController : ControllerBase
{
    private readonly ILogger<PaySlipController> _logger;
    private readonly IPaySlipRepository _paySlipRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;
    private readonly IPdfGeneratorRepository _pdfGeneratorRepository;

    public PaySlipController(
        ILogger<PaySlipController> logger, 
        IPaySlipRepository paySlipRepository, 
        IMapper mapper,
        IWebHostEnvironment environment,
        IPdfGeneratorRepository pdfGeneratorRepository)
    {
        _logger = logger;
        _paySlipRepository = paySlipRepository;
        _mapper = mapper;
        _environment = environment;
        _pdfGeneratorRepository = pdfGeneratorRepository;
    }

    [HttpGet]
    [EnableQuery]
    [Authorize]
    public IActionResult GetAllAsync()
    {
        try
        {
            var query = _paySlipRepository.GetQueryable();
            var paySlipDto = _mapper.ProjectTo<PaySlipGet>(query);

            return Ok(paySlipDto);
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

    [HttpGet("{id:int}/pdf")]
    public async Task<IActionResult> GetPaySlipPdf(int id)
    {
        try
        {
            var paySlip = await _paySlipRepository.GetByIdAsync(id);
            if (paySlip == null || string.IsNullOrEmpty(paySlip.FilePath))
            {
                return NotFound("Payslip or PDF file not found");
            }

            var fullPath = Path.Combine(_environment.ContentRootPath, paySlip.FilePath);
            
            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound("PDF file not found on server");
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(fullPath);
            return File(fileBytes, "application/pdf", $"payslip_{paySlip.PayslipID}.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving PDF");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PaySlipCreate psDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paySlip = _mapper.Map<Payslip>(psDto);
                        
            paySlip.FilePath = null;
            
            await _paySlipRepository.AddAsync(paySlip);

            var fullPayslip = _paySlipRepository.GetQueryable().FirstOrDefault(ps => ps.PayslipID == paySlip.PayslipID);

            if (fullPayslip == null)
                return StatusCode(500, "Failed to load payslip details");

            var paySlipDtoForPdf = _mapper.Map<PaySlipGet>(fullPayslip);

            var pdfFileName = $"payslip_{paySlip.PayslipID}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            var pdfDirectory = Path.Combine(_environment.ContentRootPath, "uploads", "payslips");
            
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            var pdfFilePath = Path.Combine(pdfDirectory, pdfFileName);
            
            await _pdfGeneratorRepository.GeneratePaySlipPdfAsync(paySlipDtoForPdf, pdfFilePath);

            paySlip.FilePath = Path.Combine("uploads", "payslips", pdfFileName);
            paySlip.UpdatedAt = DateTime.UtcNow;
            await _paySlipRepository.UpdateAsync(paySlip);

            var result = _mapper.Map<PaySlipGet>(paySlip);
            
            return CreatedAtAction(nameof(GetByIdAsync), new { id = paySlip.PayslipID }, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating payslip");
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

            var oldFilePath = paySlip.FilePath;
            
            _mapper.Map(psDto, paySlip);
            paySlip.UpdatedAt = DateTime.UtcNow;

            await _paySlipRepository.UpdateAsync(paySlip);

            if (psDto.RegeneratePdf || string.IsNullOrEmpty(paySlip.FilePath))
            {
                if (!string.IsNullOrEmpty(oldFilePath))
                {
                    var oldFullPath = Path.Combine(_environment.ContentRootPath, oldFilePath);
                    if (System.IO.File.Exists(oldFullPath))
                    {
                        System.IO.File.Delete(oldFullPath);
                    }
                }

                var fullPayslip = _paySlipRepository.GetQueryable().FirstOrDefault(ps => ps.PayslipID == paySlip.PayslipID);

                if (fullPayslip == null)
                    return StatusCode(500, "Failed to load payslip details");

                var paySlipDtoForPdf = _mapper.Map<PaySlipGet>(fullPayslip);

                var pdfFileName = $"payslip_{paySlip.PayslipID}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                var pdfDirectory = Path.Combine(_environment.ContentRootPath, "uploads", "payslips");
                
                if (!Directory.Exists(pdfDirectory))
                {
                    Directory.CreateDirectory(pdfDirectory);
                }

                var pdfFilePath = Path.Combine(pdfDirectory, pdfFileName);
                await _pdfGeneratorRepository.GeneratePaySlipPdfAsync(paySlipDtoForPdf, pdfFilePath);

                paySlip.FilePath = Path.Combine("uploads", "payslips", pdfFileName);
                paySlip.UpdatedAt = DateTime.UtcNow;
                await _paySlipRepository.UpdateAsync(paySlip);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating payslip");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("{id:int}/regenerate-pdf")]
    public async Task<IActionResult> RegeneratePdfAsync(int id)
    {
        try
        {
            var paySlip = await _paySlipRepository.GetByIdAsync(id);
            if (paySlip == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(paySlip.FilePath))
            {
                var oldFullPath = Path.Combine(_environment.ContentRootPath, paySlip.FilePath);
                if (System.IO.File.Exists(oldFullPath))
                {
                    System.IO.File.Delete(oldFullPath);
                }
            }

            var fullPayslip = _paySlipRepository.GetQueryable().FirstOrDefault(ps => ps.PayslipID == paySlip.PayslipID);

            if (fullPayslip == null)
                return StatusCode(500, "Failed to load payslip details");

            var paySlipDtoForPdf = _mapper.Map<PaySlipGet>(fullPayslip);

            var pdfFileName = $"payslip_{paySlip.PayslipID}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            var pdfDirectory = Path.Combine(_environment.ContentRootPath, "uploads", "payslips");
            
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            var pdfFilePath = Path.Combine(pdfDirectory, pdfFileName);
            await _pdfGeneratorRepository.GeneratePaySlipPdfAsync(paySlipDtoForPdf, pdfFilePath);

            paySlip.FilePath = Path.Combine("uploads", "payslips", pdfFileName);
            paySlip.UpdatedAt = DateTime.UtcNow;
            await _paySlipRepository.UpdateAsync(paySlip);

            return Ok(_mapper.Map<PaySlipGet>(paySlip));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while regenerating PDF for payslip {PaySlipId}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var paySlip = await _paySlipRepository.GetByIdAsync(id);

            if (paySlip == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(paySlip.FilePath))
            {
                var fullPath = Path.Combine(_environment.ContentRootPath, paySlip.FilePath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
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