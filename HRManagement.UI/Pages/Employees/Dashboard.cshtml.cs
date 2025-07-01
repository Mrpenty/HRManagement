using System.Net;
using System.Net.Http.Json;
using HRManagement.Business.dtos.attendance;
using HRManagement.Business.dtos.leaveRequest;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.Employees
{
    public class DashboardModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<AttendanceViewDto> AttendanceList { get; set; } = new();
        public List<LeaveViewDto> LeaveList { get; set; } = new();

        public DashboardModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task OnGetAsync()
        {
            // 1️⃣ Lấy cookie từ request browser
            var token = HttpContext.Request.Cookies["accessToken"];
            Console.WriteLine($"[DEBUG] Token: {token}");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Cookie accessToken không tồn tại — user chưa login?");
            }

            // 2️⃣ Tạo CookieContainer + gắn token đúng host
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(
                new Uri("https://localhost:7201"), // Đúng URL API
                new Cookie("accessToken", token)
            );

            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };

            using var client = new HttpClient();

            // Thêm header Cookie
            client.DefaultRequestHeaders.Add("Cookie", $"accessToken={token}");

            Console.WriteLine($"[DEBUG] Gửi Cookie thủ công: accessToken={token}");

            // Gọi API
            var response1 = await client.GetAsync("https://localhost:7201/api/Attendance/my-attendance");
            response1.EnsureSuccessStatusCode();
            AttendanceList = await response1.Content.ReadFromJsonAsync<List<AttendanceViewDto>>() ?? new();

            var response2 = await client.GetAsync("https://localhost:7201/api/LeaveRequest/my-leaves");
            response2.EnsureSuccessStatusCode();
            LeaveList = await response2.Content.ReadFromJsonAsync<List<LeaveViewDto>>() ?? new();
        }
    }
}
