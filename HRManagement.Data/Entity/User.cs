using Microsoft.AspNetCore.Identity;

namespace HRManagement.Data.Entity;

public class User : IdentityUser<int>
{
    // Thông tin cơ bản
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; } // "Male", "Female", "Other"
    public string? Nationality { get; set; }
    public string? IDNumber { get; set; } // CMND/CCCD
    public DateTime? IDIssueDate { get; set; }
    public string? IDIssuePlace { get; set; }
    
    // Thông tin liên hệ
    public string? Address { get; set; }
    
    
    // Thông tin công việc
    public DateTime? HireDate { get; set; }
    public DateTime? ProbationEndDate { get; set; }
    public DateTime? ContractEndDate { get; set; }
    public string? EmployeeCode { get; set; } // Mã nhân viên
    public string? WorkLocation { get; set; } // Địa điểm làm việc
    
    // Thông tin hệ thống
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? RefreshToken { get; set; }
    public bool IsVerified { get; set; } = false; // Sửa tên property
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string Status { get; set; } = "Inactive"; // Sửa tên property
    public string? ProfilePicture { get; set; }
    
    // Foreign Keys
    public int? DepartmentID { get; set; }
    public int? EmployeeLevelID { get; set; }
    public int? ContractTypeID { get; set; }
    public int? PositionID { get; set; }
    public int? ManagedByUserId { get; set; }
    
    // Navigation Properties
    public Department? Department { get; set; }
    public EmployeeLevel? EmployeeLevel { get; set; }
    public ContractType? ContractType { get; set; }
    public Position? Position { get; set; }
    public User? Manager { get; set; }
    
    // Collections
    public ICollection<Salary> Salaries { get; set; }
    public ICollection<Payslip> Payslips { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<LeaveRequest> LeaveRequests { get; set; }
    public ICollection<LeaveRequest> ApprovedLeaveRequests { get; set; }
    public ICollection<PerformanceReview> PerformanceReviews { get; set; }
    public ICollection<PerformanceReview> ReviewedPerformanceReviews { get; set; }
}


