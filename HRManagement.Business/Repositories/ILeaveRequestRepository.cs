using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface ILeaveRequestRepository : IRepositoryAsync<LeaveRequest>
{
    Task<List<LeaveRequest>> GetMyLeavesInMonthAsync(int userId, int month, int year);
}
