using HRManagement.Business.dtos.attendance;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories;

public interface IRepositoryAsync<T> where T : class
{
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}