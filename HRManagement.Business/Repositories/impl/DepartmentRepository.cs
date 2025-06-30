using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories.impl;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IRepositoryAsync<Department> _departmentRepository;
    private readonly HRManagementDbContext _context;
    public DepartmentRepository(IRepositoryAsync<Department> departmentRepository, HRManagementDbContext context)
    {
        _departmentRepository = departmentRepository;
        _context = context;
    }
    public async Task AddAsync(Department entity)
    {
        await _departmentRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _departmentRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Department>> GetAsync()
    {
        return await _departmentRepository.GetAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Department entity)
    {
        await _departmentRepository.UpdateAsync(entity);
    }

    public async Task<Department> GetByNameAsync(string name)
    {
        return await _context.Set<Department>().FirstOrDefaultAsync(d => d.DepartmentName == name);                 
    }
}