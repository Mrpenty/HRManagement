using HRManagement.Business.dtos.department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.HR.Departments
{
    public class CreateDepartmentModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public CreateDepartmentModel(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        [BindProperty]
        public DepartmentCreate Department { get; set; }

        public void OnGet()
        {
            // Mặc định status là Inactive
            Department = new DepartmentCreate
            {
                Status = "Inactive",
                UpdateTime = DateTime.Now,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            //Department.Status = Department.Status; 
            Department.UpdateTime = DateTime.Now;

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7201/api/Department", Department);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("ListDepartments");

            ModelState.AddModelError(string.Empty, "Tạo phòng ban thất bại");
            return Page();
        }
    }

}
