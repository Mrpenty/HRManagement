using HRManagement.Business.dtos.Employees;
using HRManagement.Business.Dtos.Employees;

namespace HRManagement.Business.Services.Employee
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeAsync(EmployeeDTO employeeDto);

        Task<AttendanceSummaryDto> GetAttendanceSummaryAsync(string userId, int year, int month);
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
    }
} 