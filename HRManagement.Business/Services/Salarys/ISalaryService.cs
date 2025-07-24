using HRManagement.Data.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HRManagement.Business.Services.Salarys
{
    public interface ISalaryService
    {
        Task<decimal> CalculateNetSalaryAsync(int userId, DateTime salaryPeriod);
        Task AddBonusAsync(int salaryId, decimal amount, string reason);
        Task AddDeductionAsync(int salaryId, decimal amount, string reason);
        Task<List<SalaryAdjustment>> GetAdjustmentsAsync(int salaryId);
    }
}