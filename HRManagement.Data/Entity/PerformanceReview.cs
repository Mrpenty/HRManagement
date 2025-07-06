namespace HRManagement.Data.Entity;

public class PerformanceReview
{
    public int PerformanceReviewID { get; set; }
    public int UserID { get; set; }
    public int ReviewerID { get; set; }
    public DateTime ReviewDate { get; set; }
    public decimal Rating { get; set; } // 0-5
    public string Comments { get; set; }
    public string Status { get; set; } // "Pending", "Completed", "Cancelled"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; }
    public User Reviewer { get; set; }
}