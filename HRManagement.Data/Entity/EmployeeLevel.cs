namespace HRManagement.Data.Entity;

public class EmployeeLevel
{
    public int EmployeeLevelID { get; set; }
    public string EmployeeLevelName { get; set; }
    public ICollection<User> Users { get; set; }
}