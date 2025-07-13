using HRManagement.Business.dtos.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace HRManagement.UI.Pages.HR.Account
{
    public class ListAccountModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ListAccountModel(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        public List<EmployeeDTO> Accounts { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            string apiUrl = $"https://localhost:7201/api/Employee/All-Employees";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Không thể tải danh sách tài khoản.");
                return Page();
            }

            Accounts = await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();
            return Page();
        }

    }
}
