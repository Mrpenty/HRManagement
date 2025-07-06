namespace HRManagement.Data.Entity;

public class SalaryBonus
{
    public int SalaryBonusID { get; set; }
    public int UserID { get; set; }
    public string BonusType { get; set; } // e.g., "Performance", "Project", "Overtime"
    public decimal? Amount { get; set; }
    public string Description { get; set; }
    public DateTime BonusDate { get; set; } // Ngày thưởng được áp dụng
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; }
}
