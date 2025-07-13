using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.attendance
{
    public class AttendanceHistoryDto
    {
        public DateTime Date { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string Status { get; set; } // OnTime, Late, OnLeave, HasNotCheck
    }
}
