using HRManagement.Business.dtos.department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HRManagement.UI.Pages.HR.Departments
{
    public class ListDepartmentsModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ListDepartmentsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<DepartmentGet> Departments { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7201/api/Department");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Departments = JsonSerializer.Deserialize<List<DepartmentGet>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })!;
                }
                else
                {
                    ErrorMessage = $"API Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Exception: {ex.Message}";
            }
        }
    }
}
