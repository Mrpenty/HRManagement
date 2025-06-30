using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface IUserRepository
{
    Task<bool> AssignRoleAsync(int id, string role);
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAsync();
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}