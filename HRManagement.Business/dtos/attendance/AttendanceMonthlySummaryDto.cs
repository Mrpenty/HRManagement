using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.attendance
{
    public class AttendanceMonthlySummaryDto
    {
        public string FullName { get; set; }
        public List<AttendanceHistoryDto> DailyRecords { get; set; } = new();
        public int TotalWorkDays { get; set; }
        public int TotalLateDays { get; set; }
        public int TotalLeaveDays { get; set; }
    }
}
