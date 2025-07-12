using HRManagement.Business.dtos.leaveRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace HRManagement.UI.Pages.Employees
{
    public class LeaveRequestDetailModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LeaveRequestDetailModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public LeaveRequestGet LeaveRequest { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token)) return Unauthorized();

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler);

            var response = await client.GetAsync($"https://localhost:7201/api/LeaveRequest/{id}");
            if (response.IsSuccessStatusCode)
            {
                LeaveRequest = await response.Content.ReadFromJsonAsync<LeaveRequestGet>() ?? new();
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token)) return Unauthorized();
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid input data.";
                return Page();
            }

            if (LeaveRequest.Status != "Pending")
            {
                TempData["ErrorMessage"] = "Only pending requests can be updated.";
                return RedirectToPage("/Employees/LeaveRequestDetail", new { id = LeaveRequest.LeaveRequestID });
            }

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler);

            var updateDto = new LeaveRequestCreate
            {
                StartDate = LeaveRequest.StartDate,
                EndDate = LeaveRequest.EndDate,
                LeaveType = LeaveRequest.LeaveType,
                Reason = LeaveRequest.Reason
            };

            var response = await client.PutAsJsonAsync($"https://localhost:7201/api/LeaveRequest/{LeaveRequest.LeaveRequestID}", updateDto);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Leave request updated successfully.";
                return RedirectToPage("/Employees/LeaveRequestDetail", new { id = LeaveRequest.LeaveRequestID });
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update leave request.";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var token = HttpContext.Request.Cookies["accessToken"];
            if (string.IsNullOrEmpty(token)) return Unauthorized();

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler);

            var response = await client.DeleteAsync($"https://localhost:7201/api/LeaveRequest/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Leave request deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete leave request.";
            }

            return RedirectToPage("/Employees/LeaveRequest");
        }
    }
}
