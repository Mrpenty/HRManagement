using HRManagement.Business.dtos.attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http;

namespace HRManagement.UI.Pages.Employees
{
    public class AttendanceTrackingModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<AttendanceViewDto> AttendanceList { get; set; } = new();

        public AttendanceTrackingModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        public async Task OnGetAsync()
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Token null");

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler);

            var fromDate = Request.Query["fromDate"];
            var toDate = Request.Query["toDate"];
            var status = Request.Query["status"].ToString();
            var filters = new List<string>();

            if (!string.IsNullOrEmpty(fromDate))
                filters.Add($"AttendanceDate ge {fromDate}");

            if (!string.IsNullOrEmpty(toDate))
                filters.Add($"AttendanceDate le {toDate}");

            if (!string.IsNullOrEmpty(status))
                filters.Add($"Status eq '{status}'");

            string filterQuery = filters.Any() ? $"?$filter={string.Join(" and ", filters)}" : "";

            var response1 = await client.GetAsync($"https://localhost:7201/api/Attendance/my-attendance{filterQuery}");
            response1.EnsureSuccessStatusCode();
            AttendanceList = await response1.Content.ReadFromJsonAsync<List<AttendanceViewDto>>() ?? new();
        }

        public async Task<IActionResult> OnPostCheckInAsync()
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token))
                throw new Exception("Not logged in");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", $"accessToken={token}");

            var res = await client.PostAsync("https://localhost:7201/api/Attendance/check-in", null);

            if (!res.IsSuccessStatusCode)
            {
                var reason = await res.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = $"Check-in failed: {reason}";
                return RedirectToPage();
            }

            TempData["SuccessMessage"] = "Check-in successful!";
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Not logged in");

            var handler = new HttpClientHandler();
            using var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Cookie", $"accessToken={token}");

            var res = await client.PostAsync("https://localhost:7201/api/Attendance/check-out", null);
            if (!res.IsSuccessStatusCode)
            {
                var reason = await res.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = $"Check-out failed: {reason}";
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
