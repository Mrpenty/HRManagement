using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.attendance
{
    public class AttendanceDailyStatus
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Status { get; set; } // "OnTime", "Late", "OnLeave", "HasNotCheck"
        public DateTime AttendanceDate { get; set; }
    }
}
