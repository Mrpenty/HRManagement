using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entity
{
    public class Payslip
    {
        public int PayslipID { get; set; }

        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        public int SalaryID { get; set; }

        public Salary Salary { get; set; }

        public DateTime IssueDate { get; set; }

        public string? FilePath { get; set; } // Changed to nullable string

        public string Status { get; set; } = "Generated";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
