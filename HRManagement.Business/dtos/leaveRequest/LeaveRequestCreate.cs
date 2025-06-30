using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.leaveRequest;

public class LeaveRequestCreate
{
    [Required]
    public int UserID { get; set; }
    public int? ApproverID { get; set; }
    [Required]
    [MaxLength(500)]
    public string LeaveType { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [MaxLength(500)]
    public string Reason { get; set; }
    [Required]
    public string Status { get; set; }
    public string? ApproverNote { get; set; }
}