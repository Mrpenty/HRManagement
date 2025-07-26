using HRManagement.Business.dtos.Payslip;

namespace HRManagement.Business.Repositories;

public interface IPdfGeneratorRepository
{
    Task GeneratePaySlipPdfAsync(PaySlipGet payslipDto, string filePath);
}