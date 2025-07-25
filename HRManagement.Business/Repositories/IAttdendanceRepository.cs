using HRManagement.Business.dtos.attendance;
using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface IAttdendanceRepository : IRepositoryAsync<Attendance>
{
    Task<List<AttendanceDailyStatus>> GetDailyAttendanceStatusAsync(DateTime date);
}