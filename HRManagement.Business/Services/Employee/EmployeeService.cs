using HRManagement.Business.Dtos.Employees;
using HRManagement.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Business.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HRManagementDbContext _dbContext;
        public EmployeeService(HRManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AttendanceSummaryDto> GetAttendanceSummaryAsync(string userId, int year, int month)
        {
            if (!int.TryParse(userId, out int userIdInt))
                throw new ArgumentException("Invalid userId");

            // Số ngày làm việc (Attendance)
            var workDays = await _dbContext.Attendances
                .Where(a => a.UserID == userIdInt && a.AttendanceDate.Year == year && a.AttendanceDate.Month == month)
                .CountAsync();

            // Số ngày nghỉ (LeaveRequest đã duyệt)
            var leaveDays = await _dbContext.LeaveRequests
                .Where(l => l.UserID == userIdInt && l.Status == "Approved"
                    && l.StartDate.Year == year && l.StartDate.Month == month)
                .SumAsync(l => EF.Functions.DateDiffDay(l.StartDate, l.EndDate) + 1);

            return new AttendanceSummaryDto
            {
                WorkDays = workDays,
                LeaveDays = leaveDays
            };
        }
    }
} 