using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories;

public interface ILeaveRequestRepository : IRepositoryAsync<LeaveRequest>
{
    Task<IEnumerable<LeaveRequest>> GetAllWithUserAsync();

    Task<List<LeaveRequest>> GetMyLeavesInMonthAsync(int userId, int month, int year);

    Task<List<LeaveRequest>> GetMyLeavesInYearAsync(int userId, int year);
}
