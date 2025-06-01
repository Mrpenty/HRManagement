using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly HRManagementDbContext _context;

        public EmployeeRepository(HRManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetEmployeeByIdAsync(int id)
        {
            return await _context.Users
                 .Include(u => u.Department)
                 .Include(u => u.EmployeeLevel)
                 .Include(u => u.ContractType)
                 .Include(u => u.Position)
                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateEmployeeAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
