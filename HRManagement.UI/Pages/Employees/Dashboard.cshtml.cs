using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.Employees
{
    [Authorize(Roles = "Employee")]
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
} 