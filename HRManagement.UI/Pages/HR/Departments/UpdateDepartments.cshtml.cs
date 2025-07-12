using HRManagement.Business.dtos.department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRManagement.UI.Pages.HR.Departments
{
    public class UpdateDepartmentsModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public UpdateDepartmentsModel(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        [BindProperty]
        public DepartmentGet Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string apiUrl = $"https://localhost:7201/api/Department/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return RedirectToPage("ListDepartments");

            Department = await response.Content.ReadFromJsonAsync<DepartmentGet>();
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)      
                return Page();
            var updateDto = new DepartmentCreate
            {
                DepartmentName = Department.DepartmentName,
                UpdateTime = DateTime.Now,
                Status = Department.Status,
                Description = Department.Description
            };

            string apiUrl = $"https://localhost:7201/api/Department/{Department.DepartmentID}";
            var response = await _httpClient.PutAsJsonAsync(apiUrl, updateDto);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("ListDepartments");

            ModelState.AddModelError(string.Empty, "Cập nhật thất bại");
            return Page();
        }
    }
}
