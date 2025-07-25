namespace HRManagement.Data.Entity
{
    public class SalaryAdjustment
    {
        public int SalaryAdjustmentID { get; set; }
        public int SalaryID { get; set; }
        public Salary Salary { get; set; }
        public string Type { get; set; } // "Bonus" hoặc "Deduction"
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 