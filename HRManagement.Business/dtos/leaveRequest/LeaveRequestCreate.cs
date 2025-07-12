using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.leaveRequest;

public class LeaveRequestCreate
{
    [Required]
    [MaxLength(100)]
    public string LeaveType { get; set; } = default!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [MaxLength(500)]
    public string? Reason { get; set; }
}
