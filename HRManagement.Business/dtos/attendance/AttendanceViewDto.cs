using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.attendance
{
    public class AttendanceViewDto
    {
        public DateTime AttendanceDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; } 
        public decimal? WorkHours { get; set; }
        public decimal OvertimeHours { get; set; }

        public string Status { get; set; }
        public string Location { get; set; }

    }

}
