namespace HRManagement.Data.Entity;

public class EmployeeLevel
{
    public int EmployeeLevelID { get; set; }
    public string EmployeeLevelName { get; set; }
    public string? Description { get; set; }
    public string? LevelCode { get; set; } // Mã cấp bậc (e.g., "L1", "L2", "L3")
    
    // Thông tin lương
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
    public decimal? SalaryMultiplier { get; set; } // Hệ số lương
    
    // Yêu cầu thăng cấp
    public int? RequiredYears { get; set; } // Số năm kinh nghiệm yêu cầu
    public string? RequiredSkills { get; set; } // Kỹ năng yêu cầu
    public int? RequiredPerformanceScore { get; set; } // Điểm đánh giá yêu cầu
    
    // Trạng thái
    public string Status { get; set; } = "Active"; // "Active", "Inactive"
    public int SortOrder { get; set; } = 0; // Thứ tự hiển thị
    
    // Timestamps
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public ICollection<User> Users { get; set; }
}