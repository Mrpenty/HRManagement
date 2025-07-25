using HRManagement.Business.dtos.Employees;
using HRManagement.Business.Dtos.Employees;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
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

        public async Task<int> CreateEmployeeWithSalaryAsync(EmployeeWithSalaryCreateDto dto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var employee = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    DateOfBirth = dto.DateOfBirth,
                    DepartmentID = dto.DepartmentID,
                    PositionID = dto.PositionID,
                    EmployeeLevelID = dto.EmployeeLevelID,
                    ContractTypeID = dto.ContractTypeID,
                };
                _dbContext.User.Add(employee);
                await _dbContext.SaveChangesAsync();

                var salary = new Salary
                {
                    UserID = employee.Id,
                    BaseSalary = dto.BaseSalary,
                    Allowances = dto.Allowances,
                    SalaryPeriod = dto.SalaryPeriod
                };
                _dbContext.Salaries.Add(salary);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
                return employee.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
} 