using HRManagement.Business.dtos.attendance;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Business.Repositories.impl;

public class AttdendanceRepository : IAttdendanceRepository
{
    private readonly IRepositoryAsync<Attendance> _attendanceRepository;
    private readonly HRManagementDbContext _context;

    public AttdendanceRepository(IRepositoryAsync<Attendance> attendanceRepository, HRManagementDbContext context)
    {
        _attendanceRepository = attendanceRepository;
        _context = context;
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

    public async Task<List<AttendanceDailyStatus>> GetDailyAttendanceStatusAsync(DateTime date)
    {
        var users = await _context.Users.ToListAsync();

        var attendances = await _context.Attendances
            .Where(a => a.AttendanceDate.Date == date.Date)
            .ToListAsync();

        var approvedLeaves = await _context.LeaveRequests
            .Where(lr => lr.Status == "Approved"
                      && lr.StartDate.Date <= date.Date
                      && lr.EndDate.Date >= date.Date)
            .ToListAsync();

        var result = new List<AttendanceDailyStatus>();

        foreach (var user in users)
        {
            var attendance = attendances.FirstOrDefault(a => a.UserID == user.Id);
            var onLeave = approvedLeaves.Any(lr => lr.UserID == user.Id);

            string status;
            if (onLeave)
                status = "OnLeave";
            else if (attendance?.CheckInTime == null)
                status = "HasNotCheck";
            else if (attendance.CheckInTime.Value.TimeOfDay > new TimeSpan(8, 30, 0))
                status = "Late";
            else
                status = "OnTime";

            result.Add(new AttendanceDailyStatus
            {
                UserID = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                CheckInTime = attendance?.CheckInTime,
                CheckOutTime = attendance?.CheckOutTime,
                Status = status,
                AttendanceDate = date.Date
            });
        }

        return result;
    }

    //Trí làm: Lấy UserId chấm công để view danh sách số ngày Employee đang đăng nhập đã chấm công
    public async Task<IEnumerable<Attendance>> GetByUserIdAsync(int userId)
    {
        return await _context.Attendances
            .Where(a => a.UserID == userId)
            .OrderByDescending(a => a.AttendanceDate)
            .ToListAsync();
    }


}