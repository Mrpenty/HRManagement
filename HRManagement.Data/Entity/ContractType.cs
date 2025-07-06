namespace HRManagement.Data.Entity;

public class ContractType
{
    public int ContractTypeID { get; set; }
    public string ContractTypeName { get; set; } // e.g., "Full-Time", "Part-Time", "Contract"
    public DateTime? StartDate { get; set; } // Ngày bắt đầu áp dụng loại hợp đồng
    public DateTime? EndDate { get; set; } // Ngày kết thúc (null nếu không thời hạn)
    public int? DurationMonths { get; set; } // Thời gian hợp đồng tính bằng tháng (0 nếu không thời hạn)
    public string? Status { get; set; } = "Active"; // "Active", "Expired", "PendingApproval"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<User> Users { get; set; }
}