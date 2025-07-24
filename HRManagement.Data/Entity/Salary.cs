namespace HRManagement.Data.Entity;

public class Salary
{
    public int SalaryID { get; set; }
    public int UserID { get; set; }
    public User User { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal Allowances { get; set; } 
    public decimal Bonus { get; set; } 
    public decimal Deduction { get; set; } 
    public decimal Tax { get; set; } 
    public decimal NetSalary { get; set; }
    public DateTime SalaryPeriod { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public ICollection<Payslip> Payslips { get; set; }
    public ICollection<SalaryAdjustment> SalaryAdjustments { get; set; }
}
