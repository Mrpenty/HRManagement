using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.department;

public class DepartmentCreate
{
    [Required]
    [MaxLength(30, ErrorMessage = "Name cannot exceed 30 char")]
    public string DepartmentName { get; set; }
    public string Status { get; set; } = "Inactive";
    public DateTime UpdateTime { get; set; } = DateTime.Now;

}