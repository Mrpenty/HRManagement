using Microsoft.AspNetCore.Identity;

namespace HRManagement.Data.Entity;

public class User : IdentityUser<int>
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public string? ProfilePicture { get; set; }
    public int? DepartmentID { get; set; }
    public int? EmployeeLevelID { get; set; }
    public int? ContractTypeID { get; set; }
    public int? PositionID { get; set; }
    public Department? Department { get; set; }
    public EmployeeLevel? EmployeeLevel { get; set; }
    public ContractType? ContractType { get; set; }
    public Position? Position { get; set; }
    public ICollection<Salary> Salaries { get; set; }
    public ICollection<Payslip> Payslips { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<LeaveRequest> LeaveRequests { get; set; }
    public ICollection<LeaveRequest> ApprovedLeaveRequests { get; set; }
}
