namespace HRManagement.Data.Entity;

public class DeductionReason
{
    public int DeductionReasonID { get; set; }
    public string ReasonName { get; set; } // e.g., "Lateness", "WorkError"
    public string Description { get; set; }
    public decimal? BaseRate { get; set; } // Mức tiền cơ bản (e.g., 10 USD/giờ)
    public string? Unit { get; set; } // e.g., "Hour", "Day"
    public decimal Multiplier { get; set; } // Hệ số nhân (e.g., 1.0)
    public decimal Amount { get; set; } // Fixed amount for this reason
    public ICollection<Deduction> Deductions { get; set; }
}
