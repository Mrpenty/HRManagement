using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.HR.Employee_Management
{
    public class CreateEmployeeModel : PageModel
    {
        private readonly HRManagementDbContext _context;

        public CreateEmployeeModel(HRManagementDbContext context)
        {
            _context = context;
        }

        public List<Department> Departments { get; set; }
        public List<Position> Positions { get; set; }
        public List<EmployeeLevel> Levels { get; set; }
        public List<ContractType> ContractTypes { get; set; }

        public IActionResult OnGet()
        {
            Departments = _context.Departments.ToList();
            Positions = _context.Positions.ToList();
            Levels = _context.EmployeeLevels.ToList();
            ContractTypes = _context.ContractTypes.ToList();
            return Page();
        }
    }
}
