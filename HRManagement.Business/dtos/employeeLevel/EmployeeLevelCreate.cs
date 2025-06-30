using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.employeeLevel;

public class EmployeeLevelCreate
{
    [Required]
    [MaxLength(100, ErrorMessage = "Employee Level Cannot Exceed 100 chars")]
    public string EmployeeLevelName { get; set; }
}