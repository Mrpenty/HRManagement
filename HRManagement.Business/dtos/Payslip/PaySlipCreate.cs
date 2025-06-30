namespace HRManagement.Business.dtos.Payslip;

public class PaySlipCreate
{
    public int UserID { get; set; }
    public int SalaryID { get; set; }
    public DateTime IssueDate { get; set; }
    public string? FilePath { get; set; }
    public string Status { get; set; }
}