using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.department;

public class DepartmentCreate
{
    [Required]
    [MaxLength(30, ErrorMessage = "Name cannot exceed 30 char")]
    public string DepartmentName { get; set; }
    [Required]
    [RegularExpression("Active|Inactive|Pending", ErrorMessage = "Status must be either Active or Inactive or Pending")]
    public string Status { get; set; } = "Inactive";
    public DateTime UpdateTime { get; set; } = DateTime.Now;
    [Required]
    [MaxLength(200, ErrorMessage = "Description cannot exceed 200 char")]
    public string Description { get; set; }
}