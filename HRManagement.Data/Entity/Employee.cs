using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace HRManagement.Data.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(20)]
        public string EmployeeStatus { get; set; } // Intern, Fresher, Senior, or null

        [Required, StringLength(20)]
        public string ContractType { get; set; } // Full-time, Part-time

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(256)]
        public string PasswordHash { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; } // Admin, HR, Employee

        [StringLength(50)]
        public string Position { get; set; } // Manager, Developer, Accountant, or null

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Salary> Salaries { get; set; }
        public ICollection<Payslip> Payslips { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public ICollection<LeaveRequest> ApprovedLeaveRequests { get; set; }
    }
}
