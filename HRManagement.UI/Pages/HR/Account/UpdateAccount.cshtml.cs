using HRManagement.Business.dtos.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace HRManagement.UI.Pages.HR.Account
{
    public class UpdateAccountModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public UpdateAccountModel(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public EmployeeDTO Employee { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Id))
                return NotFound();

            string apiUrl = $"https://localhost:7201/api/Employee/GetById?id={Id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return NotFound();

            Employee = await response.Content.ReadFromJsonAsync<EmployeeDTO>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string apiUrl = "https://localhost:7201/api/Employee/Update-Employee";
            var response = await _httpClient.PutAsJsonAsync(apiUrl, Employee);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("/HR/Account/ListAccount");

            ModelState.AddModelError(string.Empty, "Cập nhật thất bại.");
            return Page();
        }
    }
}
