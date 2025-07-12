using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.attendance
{
    public class MyDashboardDto
    {
        public double TotalWorkHours { get; set; }
        public int WorkDays { get; set; }
        public double OTHours { get; set; }
        public int DaysLeave { get; set; }
    }

}
