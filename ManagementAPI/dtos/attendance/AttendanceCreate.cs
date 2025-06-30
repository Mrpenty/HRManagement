namespace ManagementAPI.dtos.attendance;

public class AttendanceCreate
{
    public int UserID { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public string Location { get; set; }
    public decimal? WorkHours { get; set; }
    public decimal OvertimeHours { get; set; }
    public DateTime AttendanceDate { get; set; }
}