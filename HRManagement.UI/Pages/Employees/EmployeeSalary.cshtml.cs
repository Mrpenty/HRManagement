using HRManagement.Business.dtos.salary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace HRManagement.UI.Pages.Employees;

public class EmployeeSalaryModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeeSalaryModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public SalaryDto? Salary { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var token = HttpContext.Request.Cookies["accessToken"];
        if (string.IsNullOrEmpty(token)) return Unauthorized();

        var cookieContainer = new CookieContainer();
        cookieContainer.Add(new Uri("https://localhost:7201"), new Cookie("accessToken", token));
        var handler = new HttpClientHandler { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler);

        var response = await client.GetAsync("https://localhost:7201/api/Salary/my-salary");

        if (response.IsSuccessStatusCode)
        {
            Salary = await response.Content.ReadFromJsonAsync<SalaryDto>();
        }
        else
        {
            TempData["ErrorMessage"] = "Could not load salary data.";
        }

        return Page();
    }
}

