using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Clear the access token cookie
            Response.Cookies.Delete("accessToken", new CookieOptions { Path = "/" });
            return RedirectToPage("/Auth/Login");
        }
    }
} 