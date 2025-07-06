namespace HRManagement.Data.Entity;

public class LeaveBalance
{
    public int LeaveBalanceID { get; set; }
    public int UserID { get; set; }
    public int Year { get; set; }
    
    // Loại nghỉ phép
    public string LeaveType { get; set; } // "Annual", "Sick", "Personal", "Maternity", "Paternity"
    
    // Số ngày
    public decimal TotalDays { get; set; } // Tổng số ngày được cấp
    public decimal UsedDays { get; set; } // Số ngày đã sử dụng
    public decimal RemainingDays { get; set; } // Số ngày còn lại
    public decimal? PendingDays { get; set; } // Số ngày đang chờ duyệt
    
    // Thông tin bổ sung
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public User User { get; set; }
} 