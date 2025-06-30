using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.salary;

public class SalaryCreate
{
    [Required]
    public int UserID { get; set; }
    [Required]
    public decimal BaseSalary { get; set; }
    [Required]
    public decimal Allowances { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deduction { get; set; } 
    public decimal Tax { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime SalaryPeriod { get; set; }
}