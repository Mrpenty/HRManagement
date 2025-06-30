using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories.impl;

public class AttdendanceRepository : IAttdendanceRepository
{
    private readonly IRepositoryAsync<Attendance> _attendanceRepository;
    public AttdendanceRepository(IRepositoryAsync<Attendance> attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task AddAsync(Attendance entity)
    {
        await _attendanceRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _attendanceRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Attendance>> GetAsync()
    {
        return await _attendanceRepository.GetAsync();
    }

    public async Task<Attendance> GetByIdAsync(int id)
    {
        return await _attendanceRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Attendance entity)
    {
        await _attendanceRepository.UpdateAsync(entity);
    }
}