using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories.impl;

public class PaySlipRepository : IPaySlipRepository
{
    private readonly IRepositoryAsync<Payslip> _paySlipRepository;

    public PaySlipRepository(IRepositoryAsync<Payslip> paySlipRepository)
    {
        _paySlipRepository = paySlipRepository;
    }

    public async Task AddAsync(Payslip entity)
    {
        await _paySlipRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _paySlipRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Payslip>> GetAsync()
    {
        return await _paySlipRepository.GetAsync();
    }

    public async Task<Payslip> GetByIdAsync(int id)
    {
        return await _paySlipRepository.GetByIdAsync(id);
    }
    
    public async Task<Payslip?> GetByIdWithDetailsAsync(int id)
    {
        return await _paySlipRepository
            .GetQueryable()
            .Include(ps => ps.User)
            .Include(ps => ps.Salary)
            .FirstOrDefaultAsync(ps => ps.PayslipID == id);
    }

    public IQueryable<Payslip> GetQueryable()
    {
        return _paySlipRepository.GetQueryable()
                                 .Include(ps => ps.User)
                                 .ThenInclude(u => u.Department)
                                 .Include(ps => ps.User)
                                 .ThenInclude(u => u.Position)
                                 .Include(ps => ps.Salary);
    }

    public async Task UpdateAsync(Payslip entity)
    {
        await _paySlipRepository.UpdateAsync(entity);
    }
}