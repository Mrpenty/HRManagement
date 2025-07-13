using HRManagement.Business.dtos.attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace HRManagement.UI.Pages.HR.Attendance
{
    public class AttendanceInMonthModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AttendanceInMonthModel(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Month { get; set; } = DateTime.Now.Month;

        [BindProperty(SupportsGet = true)]
        public int Year { get; set; } = DateTime.Now.Year;

        public AttendanceMonthlySummaryDto AttendanceSummary { get; set; }

        public string EmployeeName => AttendanceSummary?.FullName ?? "";
        public List<AttendanceHistoryDto> Attendances => AttendanceSummary?.DailyRecords ?? new();
        public int WorkDays => AttendanceSummary?.TotalWorkDays ?? 0;
        public int LateDays => AttendanceSummary?.TotalLateDays ?? 0;
        public int LeaveDays => AttendanceSummary?.TotalLeaveDays ?? 0;
        public int HasNotCheckCount => AttendanceSummary?.DailyRecords.Count(x => x.Status == "HasNotCheck") ?? 0;
        public int OnTimeCount => WorkDays - LateDays;

        public async Task<IActionResult> OnGetAsync()
        {
            if (UserId <= 0) return NotFound();

            string apiUrl = $"https://localhost:7201/api/Attendance/MonthlyHistory?userId={UserId}&month={Month}&year={Year}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Không thể lấy dữ liệu.");
                return Page();
            }

            AttendanceSummary = await response.Content.ReadFromJsonAsync<AttendanceMonthlySummaryDto>();
            return Page();
        }
    }
}
