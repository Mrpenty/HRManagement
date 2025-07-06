namespace HRManagement.Data.Entity;

public class Deduction
{
    public int DeductionID { get; set; }
    public int UserID { get; set; }
    public int? DeductionReasonID { get; set; }
    public decimal? Amount { get; set; }
    public string? Description { get; set; }
    public DateTime DeductionDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; }
    public DeductionReason? Reason { get; set; }
}