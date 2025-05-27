namespace HRManagement.Data.Entity
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int UserID { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Location { get; set; }
        public decimal? WorkHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
    }
}
