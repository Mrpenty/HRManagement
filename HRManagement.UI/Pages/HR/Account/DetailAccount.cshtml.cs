using HRManagement.Business.dtos.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.HR.Account
{
    public class DetailAccountModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public DetailAccountModel(IHttpClientFactory factory, IConfiguration config)
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
    }
}
