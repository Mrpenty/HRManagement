using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.contractType;

public class ContractTypeCreate
{
    [Required]
    [MaxLength(100, ErrorMessage = "Contract Type Cannot Exceed 100 chars")]
    public string ContractTypeName { get; set; }
}