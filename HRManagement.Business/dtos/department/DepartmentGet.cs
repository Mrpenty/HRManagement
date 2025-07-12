namespace HRManagement.Business.dtos.department;

public class DepartmentGet
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public string Status { get; set; }  
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}