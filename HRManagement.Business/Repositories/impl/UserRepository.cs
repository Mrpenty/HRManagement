using HRManagement.Business.dtos.page;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories.impl;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly HRManagementDbContext _context;
    public UserRepository(UserManager<User> userManager, HRManagementDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        IQueryable<User> query = _userManager.Users;

        var datas = await query.ToListAsync();

        return datas;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }

    public async Task UpdateAsync(User entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var result = await _userManager.UpdateAsync(entity);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to update user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to delete user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }

    public async Task<bool> AssignRoleAsync(int id, string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            throw new ArgumentException("Role cannot be null or empty.", nameof(role));

        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
            return false;

        var result = await _userManager.AddToRoleAsync(user, role);
        return result.Succeeded;
    }

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetQueryable()
    {
       return _userManager.Users
                          .Include(u => u.Department)
                          .Include(u => u.EmployeeLevel)
                          .Include(u => u.ContractType)
                          .Include(u => u.Position);
    }

    public HRManagementDbContext GetDbContext() => _context;
}