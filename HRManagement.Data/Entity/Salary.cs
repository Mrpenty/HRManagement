namespace HRManagement.Data.Entity;

public class Salary
{
    public int SalaryID { get; set; }
    public int UserID { get; set; }
    
    // Lương cơ bản
    public decimal BaseSalary { get; set; }
    public decimal? Allowances { get; set; } // Phụ cấp cơ bản
    public decimal? PositionAllowance { get; set; } // Phụ cấp chức vụ
    public decimal? ResponsibilityAllowance { get; set; } // Phụ cấp trách nhiệm
    public decimal? SeniorityAllowance { get; set; } // Phụ cấp thâm niên
    public decimal? TransportAllowance { get; set; } // Phụ cấp đi lại
    public decimal? MealAllowance { get; set; } // Phụ cấp ăn trưa
    public decimal? HousingAllowance { get; set; } // Phụ cấp nhà ở
    
    // Thưởng và khấu trừ
    public decimal? Bonus { get; set; } 
    public decimal? Deduction { get; set; } 
    public decimal? Tax { get; set; } 
    public decimal? SocialInsurance { get; set; } // Bảo hiểm xã hội
    public decimal? HealthInsurance { get; set; } // Bảo hiểm y tế
    public decimal? UnemploymentInsurance { get; set; } // Bảo hiểm thất nghiệp
    
    // Tổng lương
    public decimal? GrossSalary { get; set; } // Lương gộp (trước thuế)
    public decimal? NetSalary { get; set; } // Lương thực nhận
    
    // Thông tin kỳ lương
    public int SalaryPeriodID { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    // Trạng thái
    public string Status { get; set; } = "Draft"; // "Draft", "Approved", "Paid", "Cancelled"
    public int? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string? ApprovalNote { get; set; }
    
    // Timestamps
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 

    // Navigation Properties
    public User User { get; set; }
    public User? Approver { get; set; }
    public SalaryPeriod SalaryPeriod { get; set; }
    public ICollection<Payslip> Payslips { get; set; }
    public ICollection<SalaryBonus> SalaryBonuses { get; set; }
    public ICollection<Deduction> Deductions { get; set; }
}
