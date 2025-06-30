namespace HRManagement.Business.dtos.salary;

public class SalaryGet
{
    public int SalaryID { get; set; }
    public int UserID { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal Allowances { get; set; } 
    public decimal Bonus { get; set; } 
    public decimal Deduction { get; set; } 
    public decimal Tax { get; set; } 
    public decimal NetSalary { get; set; }
    public DateTime SalaryPeriod { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
}