namespace ManagementAPI.dtos.user;

public class UserUpdate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }
    public int? DepartmentID { get; set; }
    public int? EmployeeLevelID { get; set; }
    public int? ContractTypeID { get; set; }
    public int? PositionID { get; set; }
}