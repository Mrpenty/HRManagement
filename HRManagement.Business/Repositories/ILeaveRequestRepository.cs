using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories;

public interface ILeaveRequestRepository : IRepositoryAsync<LeaveRequest>
{
    Task<IEnumerable<LeaveRequest>> GetAllWithUserAsync();
}