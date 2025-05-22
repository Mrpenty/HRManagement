using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entity
{
    public class Salary
    {
        [Key]
        public int SalaryID { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [Required]
        public decimal BaseSalary { get; set; }

        public decimal Allowance { get; set; } = 0;
        public decimal Bonus { get; set; } = 0;
        public decimal Deduction { get; set; } = 0;
        public decimal Tax { get; set; } = 0;

        [Required]
        public decimal NetSalary { get; set; }

        [Required]
        public DateTime SalaryPeriod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Payslip> Payslips { get; set; }
    }
}
