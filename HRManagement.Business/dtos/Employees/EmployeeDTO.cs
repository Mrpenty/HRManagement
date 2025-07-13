using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.Employees
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? HireDate { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string ContractTypeName { get; set; }
        public string EmployeeLevelName { get; set; }
    }


}
