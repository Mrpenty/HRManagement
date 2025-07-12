using HRManagement.Business.dtos.attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace HRManagement.UI.Pages.Employees
{
    public class DashboardModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public MyDashboardDto? Dashboard { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Token null");

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler);

            var response = await client.GetAsync("https://localhost:7201/api/Attendance/my-dashboard");

            if (response.IsSuccessStatusCode)
            {
                Dashboard = await response.Content.ReadFromJsonAsync<MyDashboardDto>();
            }
            else
            {
                TempData["ErrorMessage"] = "Could not load dashboard data.";
            }

            return Page();
        }
    }
}
