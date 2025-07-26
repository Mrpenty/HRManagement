public class UserGet
{
    public int Id { get; set; }
    public int? SalaryID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public DateTime? HireDate { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsVertify { get; set; }
    public string Status { get; set; }
    public string? DepartmentName { get; set; }
    public string? EmployeeLevelName { get; set; }
    public string? ContractTypeName { get; set; }
    public string? PositionName { get; set; }
    public IEnumerable<int> RoleIds { get; set; } = [];
}
