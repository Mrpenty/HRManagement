using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface IDepartmentRepository : IRepositoryAsync<Department>
{
    Task<Department> GetByNameAsync(string name);
}