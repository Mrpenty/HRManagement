using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories.impl;

public class SalaryRepository : ISalaryRepository
{
    private readonly IRepositoryAsync<Salary> _salaryRepository;
    public SalaryRepository(IRepositoryAsync<Salary> salaryRepository)
    {
        _salaryRepository = salaryRepository;
    }

    public async Task AddAsync(Salary entity)
    {
        await _salaryRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _salaryRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Salary>> GetAsync()
    {
        return await _salaryRepository.GetAsync();
    }

    public async Task<Salary> GetByIdAsync(int id)
    {
        return await _salaryRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Salary entity)
    {
        await _salaryRepository.UpdateAsync(entity);
    }
}