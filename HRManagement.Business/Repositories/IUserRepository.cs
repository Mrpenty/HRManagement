using HRManagement.Data.Data;
using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface IUserRepository : IRepositoryAsync<User>
{
    public HRManagementDbContext GetDbContext();
    Task<bool> AssignRoleAsync(int id, string role);
}