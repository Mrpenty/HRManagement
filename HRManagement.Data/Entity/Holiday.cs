namespace HRManagement.Data.Entity;

public class Holiday
{
    public int HolidayID { get; set; }
    public string HolidayName { get; set; }
    public DateTime HolidayDate { get; set; }
    public string? Description { get; set; }
    public bool IsPaid { get; set; } // Paid or unpaid holiday
    public ICollection<SalaryPeriod> SalaryPeriods { get; set; }
}