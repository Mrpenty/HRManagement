using HRManagement.Business.dtos.attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace HRManagement.UI.Pages.HR.Attendance
{
    public class ListAttendanceModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ListAttendanceModel(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime FilterDate { get; set; } = DateTime.Today;

        public List<AttendanceDailyStatus> AttendanceList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            string apiUrl = $"https://localhost:7201/api/Attendance/daily?date={FilterDate:yyyy-MM-dd}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Không thể tải danh sách điểm danh.");
                return Page();
            }

            AttendanceList = await response.Content.ReadFromJsonAsync<List<AttendanceDailyStatus>>();
            return Page();
        }
    }
}
