using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.position;

public class PositionCreate
{
    [Required]
    [StringLength(100, ErrorMessage = "Position cannot excees 100 chars")]
    public string PositionName { get; set; }
}