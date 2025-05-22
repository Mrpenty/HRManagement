using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entity
{
    public class Payslip
    {
        [Key]
        public int PayslipID { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        public int SalaryID { get; set; }

        [ForeignKey("SalaryID")]
        public Salary Salary { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [StringLength(255)]
        public string? FilePath { get; set; } // Changed to nullable string

        [StringLength(20)]
        public string Status { get; set; } = "Generated";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
