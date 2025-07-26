namespace HRManagement.Business.dtos.Payslip;

public class PaySlipGet
{
    public int PayslipID { get; set; }
    public int UserID { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; } 
    public string? DepartmentName { get; set; } 
    public string? PositionName { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal Allowances { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deduction { get; set; }
    public decimal Tax { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime IssueDate { get; set; }
    public string? FilePath { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}