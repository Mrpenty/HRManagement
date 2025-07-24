using HRManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repositories.impl
{
    public class SalaryAjustRepository : ISalaryAjustRepository
    {
        private readonly IRepositoryAsync<SalaryAdjustment> _salaryAdjustmentRepository;

        public SalaryAjustRepository(IRepositoryAsync<SalaryAdjustment> salaryAdjustmentRepository)
        {
            _salaryAdjustmentRepository = salaryAdjustmentRepository;
        }

        public async Task AddAsync(SalaryAdjustment entity)
        {
            await _salaryAdjustmentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _salaryAdjustmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SalaryAdjustment>> GetAsync()
        {
            return await _salaryAdjustmentRepository.GetAsync();
        }

        public async Task<SalaryAdjustment> GetByIdAsync(int id)
        {
            return await _salaryAdjustmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SalaryAdjustment entity)
        {
            await _salaryAdjustmentRepository.UpdateAsync(entity);
        }
    }
}
