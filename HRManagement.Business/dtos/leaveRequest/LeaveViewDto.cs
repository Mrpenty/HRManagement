using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.leaveRequest
{
    public class LeaveViewDto
    {
        public int LeaveRequestID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Status { get; set; }
    }
}
