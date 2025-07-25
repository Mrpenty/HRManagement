using HRManagement.Business.dtos.salary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;

namespace HRManagement.UI.Pages.HR.PayrollManagement
{
    public class UpdateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UpdateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public SalaryGet Salary { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var salRes = await client.GetAsync($"https://localhost:7201/api/Salary/{id}");
            if (!salRes.IsSuccessStatusCode) return NotFound();
            var salJson = await salRes.Content.ReadAsStringAsync();
            Salary = JsonSerializer.Deserialize<SalaryGet>(salJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var putRes = await client.PutAsync($"https://localhost:7201/api/Salary/{Salary.SalaryID}",
                new StringContent(JsonSerializer.Serialize(Salary), Encoding.UTF8, "application/json"));
            if (!putRes.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Update failed");
                return Page();
            }
            return RedirectToPage("/HR/PayrollManagement/Detail", new { id = Salary.SalaryID });
        }
    }
} 