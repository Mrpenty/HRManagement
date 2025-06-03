using HRManagement.Business.Dtos.Department;
using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace HRManagement.Business.Services.HR
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HRManagementDbContext _context;

        public DepartmentService(HRManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Include(d => d.Users)
                .Select(d => new DepartmentDto
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName,
                    Users = d.Users.Select(u => new UserInDepartmentDto
                    {
                        UserID = u.Id,
                        FullName = u.FirstName + " " + u.LastName
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(int id)
        {
            var d = await _context.Departments
                .Include(dep => dep.Users)
                .Where(dep => dep.DepartmentID == id)
                .Select(dep => new DepartmentDto
                {
                    DepartmentID = dep.DepartmentID,
                    DepartmentName = dep.DepartmentName,
                    Users = dep.Users.Select(u => new UserInDepartmentDto
                    {
                        UserID = u.Id,
                        FullName = u.FirstName + " " + u.LastName
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return d;
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            var entity = new Department
            {
                DepartmentName = dto.DepartmentName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();

            return new DepartmentDto
            {
                DepartmentID = entity.DepartmentID,
                DepartmentName = entity.DepartmentName
            };
        }

        public async Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            department.DepartmentName = dto.DepartmentName;
            department.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            // Optional: check if department has users
            var hasUsers = await _context.Users.AnyAsync(u => u.DepartmentID == id);
            if (hasUsers) return false; // hoặc xử lý khác tùy bạn

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
