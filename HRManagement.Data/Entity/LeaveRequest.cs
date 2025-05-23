using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entity
{
    public class LeaveRequest
    {
        public int LeaveRequestID { get; set; }

        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        public string LeaveType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; } = "Pending";

        public int? ApproverID { get; set; }

        public Employee Approver { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
