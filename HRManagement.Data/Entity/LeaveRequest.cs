namespace HRManagement.Data.Entity;

public class LeaveRequest
{
    public int LeaveRequestID { get; set; }
    public int UserID { get; set; }
    public int? ApproverID { get; set; }
    
    // Thông tin nghỉ phép
    public string LeaveType { get; set; } // "Annual Leave", "Sick Leave", "Personal Leave"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan? StartTime { get; set; } // Giờ bắt đầu (cho nghỉ nửa ngày)
    public TimeSpan? EndTime { get; set; } // Giờ kết thúc
    public decimal RequestedDays { get; set; } // Số ngày yêu cầu
    
    // Lý do và trạng thái
    public string? Reason { get; set; }
    public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected", "Cancelled"
    public string? ApproverNote { get; set; }
    public DateTime? ApprovedAt { get; set; }
    
    // Thông tin bổ sung
    public string? ContactInfo { get; set; } // Thông tin liên lạc khi nghỉ
    public string? WorkHandover { get; set; } // Bàn giao công việc
    public bool IsEmergency { get; set; } = false; // Nghỉ khẩn cấp
    public bool HolidayImpact { get; set; } // Ảnh hưởng đến lương nếu không lương
    
    // Timestamps
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public User User { get; set; }
    public User? Approver { get; set; }
    public ICollection<Deduction> Deductions { get; set; }
}
