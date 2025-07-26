using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.Payslip;

public class PaySlipCreate
{
    [Required(ErrorMessage = "UserID is required")]
    [Range(1, int.MaxValue, ErrorMessage = "UserID must be greater than 0")]
    public int UserID { get; set; }

    [Required(ErrorMessage = "SalaryID is required")]
    [Range(1, int.MaxValue, ErrorMessage = "SalaryID must be greater than 0")]
    public int SalaryID { get; set; }

    [Required(ErrorMessage = "IssueDate is required")]
    public DateTime IssueDate { get; set; }

    [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
    public string Status { get; set; } = "Generated";
    
    public bool RegeneratePdf { get; set; } = false;
}