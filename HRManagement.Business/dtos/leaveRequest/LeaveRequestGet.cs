namespace HRManagement.Business.dtos.leaveRequest;

public class LeaveRequestGet
{
    public int LeaveRequestID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; } = "";
    public string Reason { get; set; } = "";
    public string Status { get; set; } = "";
}
