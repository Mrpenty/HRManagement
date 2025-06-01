using HRManagement.Business.Dtos.Employees;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace HRManagement.Business.Services.Employee
{
    public interface IEmployeeService
    {
        Task<UserProfileDTO> GetEmployeeByIdAsync(int userId, ClaimsPrincipal principal);
        Task UpdateEmployeeAsync(int userId, UpdateUserProfileDTO dto, IFormFile? profilePicture, ClaimsPrincipal principal);
    }


}
