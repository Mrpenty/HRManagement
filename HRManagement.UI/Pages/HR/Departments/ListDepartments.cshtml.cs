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

        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        public List<DepartmentGet> Departments { get; set; } = new();
        public string? ErrorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 3;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public async Task OnGetAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var filters = new List<string>();

                if (FromDate.HasValue && ToDate.HasValue)
                {
                    string from = FromDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                    string to = ToDate.Value.Date.AddDays(1).AddTicks(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");

                    filters.Add($"CreatedAt ge {from} and CreatedAt le {to}");
                }

                if (!string.IsNullOrEmpty(SearchTitle))
                {
                    filters.Add($"contains(DepartmentName,'{SearchTitle}')");
                }

                if (!string.IsNullOrEmpty(Status))
                {
                    filters.Add($"Status eq '{Status}'");
                }

                string filterQuery = filters.Count > 0 ? $"$filter={string.Join(" and ", filters)}&" : "";
                int skip = (PageNumber - 1) * PageSize;

                string url = $"https://localhost:7201/odata/Department?{filterQuery}$top={PageSize}&$skip={skip}&$count=true";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;

                    if (root.TryGetProperty("@odata.count", out var countProperty))
                    {
                        TotalCount = countProperty.GetInt32();
                    }

                    var value = root.GetProperty("value");

                    Departments = JsonSerializer.Deserialize<List<DepartmentGet>>(value.GetRawText(), new JsonSerializerOptions
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
