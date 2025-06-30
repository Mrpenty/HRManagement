using HRManagement.Data.Entity;

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

    public async Task UpdateAsync(Payslip entity)
    {
        await _paySlipRepository.UpdateAsync(entity);
    }
}