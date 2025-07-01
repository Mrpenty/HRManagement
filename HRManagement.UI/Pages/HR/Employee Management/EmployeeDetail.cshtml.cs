using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.HR.Employee_Management
{
    public class EmployeeDetailModel : PageModel
    {
        public int EmployeeId { get; set; }
        public void OnGet(int id)
        {
            EmployeeId = id;
        }
    }
} 