using HRManagement.Business.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Services.HR
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto?> GetDepartmentByIdAsync(int id);
        Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto);
        Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto);
        Task<bool> DeleteDepartmentAsync(int id);
    }

}
