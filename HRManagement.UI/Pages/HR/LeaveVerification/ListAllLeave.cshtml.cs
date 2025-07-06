using HRManagement.Business.dtos.leaveRequest;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HRManagement.UI.Pages.HR.LeaveVerification
{
    public class ListAllLeaveModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ListAllLeaveModel> _logger;

        public List<LeaveRequestGet> AllLeaveRequests { get; set; } = new();

        public ListAllLeaveModel(IHttpClientFactory httpClientFactory, ILogger<ListAllLeaveModel> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("https://localhost:7201/api/LeaveRequest/All-With-User");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    AllLeaveRequests = JsonSerializer.Deserialize<List<LeaveRequestGet>>(json, options);
                }
                else
                {
                    _logger.LogError("API call failed with status: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching leave requests");
            }
        }
    }
}
