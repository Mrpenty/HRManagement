namespace HRManagement.Data.Entity;

public class SalaryPeriod
{
    public int SalaryPeriodID { get; set; }
    public string PeriodName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalWorkingDays { get; set; }
    public ICollection<Salary> Salaries { get; set; }
    public ICollection<Holiday> Holidays { get; set; }
}
