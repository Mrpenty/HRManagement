using HRManagement.Business.dtos.Employees;
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
        //Khánh làm: Lấy thông tin của tất cả nhân viên
        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Users
                .Include(u => u.Department)
                .Include(u => u.EmployeeLevel)
                .Include(u => u.ContractType)
                .Include(u => u.Position)
                .ToListAsync();

            return employees.Select(u => new EmployeeDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Status = u.status,
                IsVerified = u.isVertify,
                HireDate = u.HireDate,
                DepartmentName = u.Department?.DepartmentName,
                PositionName = u.Position?.PositionName,
                ContractTypeName = u.ContractType?.ContractTypeName,
                EmployeeLevelName = u.EmployeeLevel?.EmployeeLevelName
            }).ToList();
        }
        //Khánh làm: cập nhật thông tin của nhân viên theo ID
        public async Task<bool> UpdateEmployeeAsync(EmployeeDTO employeeDto)
        {
            if (employeeDto == null || employeeDto.Id <= 0)
            {
                return false;
            }


            var existingUser = await _dbContext.Users
                .Include(u => u.Department)
                .Include(u => u.EmployeeLevel)
                .Include(u => u.ContractType)
                .Include(u => u.Position)
                .FirstOrDefaultAsync(u => u.Id == employeeDto.Id);

            if (existingUser == null)
            {
                return false;
            }

            // Cập nhật các thông tin
            existingUser.PhoneNumber = employeeDto.PhoneNumber;
            existingUser.status = employeeDto.Status;
            existingUser.isVertify = employeeDto.IsVerified;
            existingUser.HireDate = employeeDto.HireDate;

            // Nếu có ID liên quan từ DTO, bạn có thể cập nhật như sau:
            if (!string.IsNullOrEmpty(employeeDto.DepartmentName))
            {
                var dept = await _dbContext.Departments
                    .FirstOrDefaultAsync(d => d.DepartmentName == employeeDto.DepartmentName);
                existingUser.DepartmentID = dept?.DepartmentID;
            }

            if (!string.IsNullOrEmpty(employeeDto.PositionName))
            {
                var pos = await _dbContext.Positions
                    .FirstOrDefaultAsync(p => p.PositionName == employeeDto.PositionName);
                existingUser.PositionID = pos?.PositionID;
            }

            if (!string.IsNullOrEmpty(employeeDto.ContractTypeName))
            {
                var contract = await _dbContext.ContractTypes
                    .FirstOrDefaultAsync(c => c.ContractTypeName == employeeDto.ContractTypeName);
                existingUser.ContractTypeID = contract?.ContractTypeID;
            }

            if (!string.IsNullOrEmpty(employeeDto.EmployeeLevelName))
            {
                var level = await _dbContext.EmployeeLevels
                    .FirstOrDefaultAsync(l => l.EmployeeLevelName == employeeDto.EmployeeLevelName);
                existingUser.EmployeeLevelID = level?.EmployeeLevelID;
            }

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        //Khánh làm: Lấy thông tin của nhân viên theo ID    
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                return null;
            }
            var user = await _dbContext.Users
                .Include(u => u.Department)
                .Include(u => u.EmployeeLevel)
                .Include(u => u.ContractType)
                .Include(u => u.Position)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return new EmployeeDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = user.status,
                IsVerified = user.isVertify,
                HireDate = user.HireDate,
                DepartmentName = user.Department?.DepartmentName,
                PositionName = user.Position?.PositionName,
                ContractTypeName = user.ContractType?.ContractTypeName,
                EmployeeLevelName = user.EmployeeLevel?.EmployeeLevelName
            };
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