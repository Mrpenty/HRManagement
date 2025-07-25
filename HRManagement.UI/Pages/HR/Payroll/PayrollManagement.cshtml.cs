using HRManagement.Business.dtos.salary;
using HRManagement.Business.dtos.user;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HRManagement.UI.Pages.HR.Payroll
{
    public class PayrollManagementModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PayrollManagementModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<SalaryGet> Salaries { get; set; } = new();
        public List<UserGet> Users { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? UserId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SalaryPeriod { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public string SalaryPeriodString => SalaryPeriod ?? string.Empty;

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            // Fetch salaries
            var salRes = await client.GetAsync("https://localhost:7201/api/Salary");
            if (salRes.IsSuccessStatusCode)
            {
                var json = await salRes.Content.ReadAsStringAsync();
                Salaries = JsonSerializer.Deserialize<List<SalaryGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
            // Fetch users
            var userRes = await client.GetAsync("https://localhost:7201/api/User");
            if (userRes.IsSuccessStatusCode)
            {
                var json = await userRes.Content.ReadAsStringAsync();
                Users = JsonSerializer.Deserialize<List<UserGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }

            // Filter/search
            if (UserId.HasValue)
                Salaries = Salaries.Where(s => s.UserID == UserId).ToList();
            if (!string.IsNullOrWhiteSpace(SalaryPeriod))
                Salaries = Salaries.Where(s => s.SalaryPeriod.ToString("yyyy-MM") == SalaryPeriod).ToList();
            if (!string.IsNullOrWhiteSpace(Search))
                Salaries = Salaries.Where(s =>
                {
                    var user = Users.FirstOrDefault(u => u.Id == s.UserID);
                    return user != null && ($"{user.FirstName} {user.LastName}".ToLower().Contains(Search.ToLower()) || (user.email?.ToLower().Contains(Search.ToLower()) ?? false));
                }).ToList();
        }
    }
}