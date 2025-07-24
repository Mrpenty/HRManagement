using HRManagement.Data.Entity;
using HRManagement.Business.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Business.Services.Salarys
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryAjustRepository _salaryAjustRepository;
        private readonly IRepositoryAsync<Salary> _salaryRepository;


        public SalaryService(ISalaryAjustRepository salaryAjustRepository, IRepositoryAsync<Salary> salaryRepository)
        {
            _salaryAjustRepository = salaryAjustRepository;
            _salaryRepository = salaryRepository;
        }

        public async Task<decimal> CalculateNetSalaryAsync(int userId, DateTime salaryPeriod)
        {
            var salary = (await _salaryRepository.GetAsync())
                .FirstOrDefault(s => s.UserID == userId && s.SalaryPeriod == salaryPeriod);
            if (salary == null) throw new Exception("Salary record not found");
            var adjustments = (await _salaryAjustRepository.GetAsync())
                .Where(a => a.SalaryID == salary.SalaryID);
            var totalBonus = adjustments.Where(a => a.Type == "Bonus").Sum(a => a.Amount);
            var totalDeduction = adjustments.Where(a => a.Type == "Deduction").Sum(a => a.Amount);
            var gross = salary.BaseSalary + salary.Allowances + totalBonus - totalDeduction;
            var tax = gross * 0.1m;
            var netSalary = gross - tax;
            salary.Bonus = totalBonus;
            salary.Deduction = totalDeduction;
            salary.Tax = tax;
            salary.NetSalary = netSalary;
            await _salaryRepository.UpdateAsync(salary);
            return netSalary;
        }

        public async Task AddBonusAsync(int salaryId, decimal amount, string reason)
        {
            var adjustment = new SalaryAdjustment
            {
                SalaryID = salaryId,
                Type = "Bonus",
                Amount = amount,
                Reason = reason,
                CreatedAt = DateTime.Now
            };
            await _salaryAjustRepository.AddAsync(adjustment);
        }

        public async Task AddDeductionAsync(int salaryId, decimal amount, string reason)
        {
            var adjustment = new SalaryAdjustment
            {
                SalaryID = salaryId,
                Type = "Deduction",
                Amount = amount,
                Reason = reason,
                CreatedAt = DateTime.Now
            };
            await _salaryAjustRepository.AddAsync(adjustment);
        }

        public async Task<List<SalaryAdjustment>> GetAdjustmentsAsync(int salaryId)
        {
            return (await _salaryAjustRepository.GetAsync())
                .Where(a => a.SalaryID == salaryId)
                .ToList();
        }
    }
}