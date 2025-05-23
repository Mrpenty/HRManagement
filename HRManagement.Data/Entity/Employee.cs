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
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? DepartmentID { get; set; }

        public Department Department { get; set; }

        public DateTime? HireDate { get; set; }

        public string EmployeeStatus { get; set; } // Intern, Fresher, Senior, or null

        public string ContractType { get; set; } // Full-time, Part-time

        public string Username { get; set; }

       

        public string Role { get; set; } // Admin, HR, Employee

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
