using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entity
{
    public class Attendance
    {
        public int AttendanceID { get; set; }

        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        [StringLength(50)]
        public string CheckInMethod { get; set; } // Mobile, Biometric, CameraAI, GPS, WiFi

        [StringLength(255)]
        public string Location { get; set; }

        public decimal? WorkHours { get; set; }
        public decimal OvertimeHours { get; set; } = 0;


        public DateTime AttendanceDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
