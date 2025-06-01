using HRManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repositories
{
    public  interface IEmployeeRepository
    {
        Task<User> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(User user);

    }
}
