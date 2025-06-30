using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories.impl;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly IRepositoryAsync<LeaveRequest> _leaveRequestRepository;
    public LeaveRequestRepository(IRepositoryAsync<LeaveRequest> leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task AddAsync(LeaveRequest entity)
    {
        await _leaveRequestRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _leaveRequestRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LeaveRequest>> GetAsync()
    {
        return await _leaveRequestRepository.GetAsync();
    }

    public async Task<LeaveRequest> GetByIdAsync(int id)
    {
        return await _leaveRequestRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(LeaveRequest entity)
    {
        await _leaveRequestRepository.UpdateAsync(entity);
    }
}