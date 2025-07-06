using System.Net;
using System.Net.Http.Json;
using HRManagement.Business.dtos.leaveRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.Employees
{
    public class CreateLeaveRequestModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty]
        public LeaveRequestCreate Leave { get; set; } = new();

        public CreateLeaveRequestModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError(string.Empty, "Unauthorized");
                return Page();
            }

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler);

            // ✅ 1. Tính số ngày xin mới
            var daysRequested = (Leave.EndDate - Leave.StartDate).Days + 1;

            if (daysRequested <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid date range.");
                return Page();
            }

            // ✅ 2. Gọi API lấy số ngày còn lại
            var remainingResponse = await client.GetAsync("https://localhost:7201/api/LeaveRequest/remaining-days");
            if (!remainingResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cannot check leave balance.");
                return Page();
            }

            var balance = await remainingResponse.Content.ReadFromJsonAsync<LeaveBalanceDto>();
            if (balance == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid leave balance data.");
                return Page();
            }

            if (balance.Remaining < daysRequested)
            {
                ModelState.AddModelError(string.Empty, $"Bạn chỉ còn {balance.Remaining} ngày phép. Vui lòng điều chỉnh.");
                return Page();
            }

            // ✅ 3. Gửi đơn
            var response = await client.PostAsJsonAsync("https://localhost:7201/api/LeaveRequest", Leave);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Đơn xin nghỉ đã được gửi.";
                return RedirectToPage("/Employees/Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Lỗi khi tạo đơn xin nghỉ.");
                return Page();
            }
        }

        public class LeaveBalanceDto
        {
            public int Used { get; set; }
            public int Remaining { get; set; }
        }
    }
}
