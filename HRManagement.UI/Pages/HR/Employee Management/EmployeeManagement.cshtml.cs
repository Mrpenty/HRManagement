using HRManagement.Business.dtos.user;
using HRManagement.Business.dtos.department;
using HRManagement.Business.dtos.position;
using HRManagement.Business.dtos.employeeLevel;
using HRManagement.Business.dtos.contractType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HRManagement.UI.Pages.HR.Employee_Management
{
    public class EmployeeManagementModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EmployeeManagementModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<UserGet> Employees { get; set; } = new();
        public List<DepartmentGet> Departments { get; set; } = new();
        public List<PositionGet> Positions { get; set; } = new();
        public List<EmployeeLevelGet> Levels { get; set; } = new();
        public List<ContractTypeGet> ContractTypes { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? DepartmentId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? PositionId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? LevelId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            // Fetch employees
            var empRes = await client.GetAsync("https://localhost:7201/api/User");
            if (empRes.IsSuccessStatusCode)
            {
                var json = await empRes.Content.ReadAsStringAsync();
                Employees = JsonSerializer.Deserialize<List<UserGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
            // Fetch departments
            var depRes = await client.GetAsync("https://localhost:7201/api/Department");
            if (depRes.IsSuccessStatusCode)
            {
                var json = await depRes.Content.ReadAsStringAsync();
                Departments = JsonSerializer.Deserialize<List<DepartmentGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
            // Fetch positions
            var posRes = await client.GetAsync("https://localhost:7201/api/Position");
            if (posRes.IsSuccessStatusCode)
            {
                var json = await posRes.Content.ReadAsStringAsync();
                Positions = JsonSerializer.Deserialize<List<PositionGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
            // Fetch levels
            var lvlRes = await client.GetAsync("https://localhost:7201/api/EmployeeLevel");
            if (lvlRes.IsSuccessStatusCode)
            {
                var json = await lvlRes.Content.ReadAsStringAsync();
                Levels = JsonSerializer.Deserialize<List<EmployeeLevelGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
            // Fetch contract types
            var ctRes = await client.GetAsync("https://localhost:7201/api/ContractType");
            if (ctRes.IsSuccessStatusCode)
            {
                var json = await ctRes.Content.ReadAsStringAsync();
                ContractTypes = JsonSerializer.Deserialize<List<ContractTypeGet>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }

            // Filter/search
            if (DepartmentId.HasValue)
                Employees = Employees.Where(e => e.DepartmentID == DepartmentId).ToList();
            if (PositionId.HasValue)
                Employees = Employees.Where(e => e.PositionID == PositionId).ToList();
            if (LevelId.HasValue)
                Employees = Employees.Where(e => e.EmployeeLevelID == LevelId).ToList();
            if (!string.IsNullOrWhiteSpace(Search))
                Employees = Employees.Where(e => ($"{e.FirstName} {e.LastName}".ToLower().Contains(Search.ToLower()) || (e.email?.ToLower().Contains(Search.ToLower()) ?? false))).ToList();
        }
    }
}
