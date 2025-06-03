namespace HRManagement.Data.Entity;

public class LeaveRequest
{
    public int LeaveRequestID { get; set; }
    public int UserID { get; set; }
    public User User { get; set; }
    public string LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; } //Default: Pending ty config
    public int? ApproverID { get; set; }
    public User Approver { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
