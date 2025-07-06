using HRManagement.Business.dtos.leaveRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace HRManagement.UI.Pages.Employees
{
    public class LeaveRequestModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<LeaveViewDto> LeaveList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ToDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        public int TotalUsedDays { get; set; }
        public int RemainingDays { get; set; }


        public LeaveRequestModel(IHttpClientFactory httpClientFactory)
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

            var response = await client.GetAsync("https://localhost:7201/api/LeaveRequest/my-leaves");
            response.EnsureSuccessStatusCode();
            var allLeaves = await response.Content.ReadFromJsonAsync<List<LeaveViewDto>>() ?? new();

            // Filter Client-side
            if (!string.IsNullOrEmpty(FromDate) && DateTime.TryParse(FromDate, out var from))
            {
                allLeaves = allLeaves.Where(l => l.StartDate.Date >= from.Date).ToList();
            }

            if (!string.IsNullOrEmpty(ToDate) && DateTime.TryParse(ToDate, out var to))
            {
                allLeaves = allLeaves.Where(l => l.EndDate.Date <= to.Date).ToList();
            }

            if (!string.IsNullOrEmpty(Status))
            {
                allLeaves = allLeaves.Where(l => l.Status == Status).ToList();
            }

            // Sau khi gọi API lấy danh sách
            // ✅ Luôn tính quota trên allLeaves
            var thisYearLeaves = allLeaves
                .Where(x => x.StartDate.Year == DateTime.Today.Year);

            TotalUsedDays = thisYearLeaves
                .Where(x => x.Status == "Approved" || x.Status == "Pending")
                .Sum(x => (x.EndDate - x.StartDate).Days + 1);

            RemainingDays = 12 - TotalUsedDays;

            LeaveList = allLeaves;

        }
    }
}
