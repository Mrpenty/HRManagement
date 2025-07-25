using HRManagement.Business.dtos.page;
using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories.impl;

public class EmployeeLevelRepository : IEmployeeLevelRepository
{
    private readonly IRepositoryAsync<EmployeeLevel> _employeeLevelRepository;
    public EmployeeLevelRepository(IRepositoryAsync<EmployeeLevel> employeeLevelRepository)
    {
        _employeeLevelRepository = employeeLevelRepository;
    }

    public async Task AddAsync(EmployeeLevel entity)
    {
        await _employeeLevelRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeLevelRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<EmployeeLevel>> GetAsync()
    {
        return await _employeeLevelRepository.GetAsync();
    }

    public async Task<EmployeeLevel> GetByIdAsync(int id)
    {
        return await _employeeLevelRepository.GetByIdAsync(id);
    }

    public IQueryable<EmployeeLevel> GetQueryable()
    {
        return _employeeLevelRepository.GetQueryable();
    }


    public async Task UpdateAsync(EmployeeLevel entity)
    {
        await _employeeLevelRepository.UpdateAsync(entity);
    }
}