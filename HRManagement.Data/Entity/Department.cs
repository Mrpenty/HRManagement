namespace HRManagement.Data.Entity;

public class Department
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<User> Users { get; set; }
}
