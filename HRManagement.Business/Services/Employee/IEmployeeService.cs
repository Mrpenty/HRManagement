using HRManagement.Business.dtos.Employees;
using HRManagement.Business.Dtos.Employees;

namespace HRManagement.Business.Services.Employee
{
    public interface IEmployeeService
    {
        Task<AttendanceSummaryDto> GetAttendanceSummaryAsync(string userId, int year, int month);
        Task<int> CreateEmployeeWithSalaryAsync(EmployeeWithSalaryCreateDto dto);
    }
} 