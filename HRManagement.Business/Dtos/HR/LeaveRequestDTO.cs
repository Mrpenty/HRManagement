using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Dtos.HR
{
    public class LeaveRequestDto
    {
        public int LeaveRequestID { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
        public string? ApproverNote { get; set; }
    }

}
