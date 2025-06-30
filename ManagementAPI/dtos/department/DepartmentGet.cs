namespace ManagementAPI.dtos.department;

public class DepartmentGet
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}