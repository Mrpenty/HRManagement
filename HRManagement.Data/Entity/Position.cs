namespace HRManagement.Data.Entity;

public class Position
{
    public int PositionID { get; set; }
    public string PositionName { get; set; }
    public string? Description { get; set; }
    public string? JobCode { get; set; } // Mã chức vụ
    public int? DepartmentID { get; set; } // Thuộc phòng ban nào
    
    // Thông tin lương
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
    public decimal? BaseSalary { get; set; }
    
    // Yêu cầu và trách nhiệm
    public string? Requirements { get; set; }
    public string? Responsibilities { get; set; }
    public int? RequiredExperience { get; set; } // Số năm kinh nghiệm yêu cầu
    public string? RequiredEducation { get; set; } // Trình độ học vấn yêu cầu
    
    // Trạng thái
    public string Status { get; set; } = "Active"; // "Active", "Inactive"
    public bool IsManagement { get; set; } = false; // Có phải vị trí quản lý không
    
    // Timestamps
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public Department? Department { get; set; }
    public ICollection<User> Users { get; set; }
}