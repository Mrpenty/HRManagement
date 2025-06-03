namespace HRManagement.Data.Entity;

public class ContractType
{
    public int ContractTypeID { get; set; }
    public string ContractTypeName { get; set; }
    public ICollection<User> Users { get; set; }
}