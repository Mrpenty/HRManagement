namespace HRManagement.Data.Entity
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int UserID { get; set; }
        
        // Thông tin chấm công
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } // "Present", "Absent", "Late", "HalfDay", "Leave"
        
        // Thông tin vị trí cho chấm công online
        public string? Location { get; set; }
        public decimal? WorkHours { get; set; }
        public decimal OvertimeHours { get; set; }
       
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Navigation Properties
        public User User { get; set; }
        public User? Approver { get; set; }
        public ICollection<SalaryBonus> SalaryBonuses { get; set; }
        public ICollection<Deduction> Deductions { get; set; }
    }
}
