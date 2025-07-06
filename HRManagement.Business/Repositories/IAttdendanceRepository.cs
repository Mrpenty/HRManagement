using HRManagement.Business.dtos.attendance;
using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface IAttdendanceRepository : IRepositoryAsync<Attendance>
{
    Task<List<AttendanceDailyStatus>> GetDailyAttendanceStatusAsync(DateTime date);

    Task<IEnumerable<Attendance>> GetByUserIdAsync(int userId);

    IQueryable<Attendance> Attendances { get; }
}