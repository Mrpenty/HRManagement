namespace HRManagement.Data.Entity;

public class Payslip
{
    public int PayslipID { get; set; }
    public int UserID { get; set; }
    public int SalaryID { get; set; }
    
    // Thông tin kỳ lương
    public DateTime Period { get; set; }
    public int WorkingDays { get; set; } // Số ngày làm việc thực tế
    public int TotalDays { get; set; } // Tổng số ngày trong tháng
    public decimal? ActualWorkHours { get; set; } // Giờ làm việc thực tế
    public decimal? OvertimeHours { get; set; } // Giờ làm thêm
    
    // Chi tiết lương
    public decimal? BasicSalary { get; set; }
    public decimal? TotalAllowances { get; set; }
    public decimal? TotalBonus { get; set; }
    public decimal? TotalDeductions { get; set; }
    public decimal? GrossSalary { get; set; }
    public decimal? NetSalary { get; set; }
    
    // Thông tin thanh toán
    public string? PaymentMethod { get; set; } // "Bank", "Cash"
    public string? BankAccount { get; set; }
    public string? BankName { get; set; }
    public DateTime? PaymentDate { get; set; }
    
    // File và trạng thái
    public string? FilePath { get; set; }
    public string Status { get; set; } = "Generated"; // "Generated", "Sent", "Viewed", "Downloaded"
    public string? GeneratedBy { get; set; }
    public DateTime? SentAt { get; set; }
    public DateTime? ViewedAt { get; set; }
    
    // Timestamps
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public User User { get; set; }
    public User? GeneratedByUser { get; set; }
    public Salary Salary { get; set; }
}
