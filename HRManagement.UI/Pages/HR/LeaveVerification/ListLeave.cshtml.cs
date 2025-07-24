using HRManagement.Business.dtos.leaveRequest;
using HRManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagement.UI.Pages.HR.LeaveVerification;

public class ListLeaveModel : PageModel
{
    private readonly ILeaveRequestRepository _repository;

    public ListLeaveModel(ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public List<LeaveRequestGet> PendingRequests { get; set; } = new();

    public async Task OnGetAsync()
    {
        var all = await _repository.GetAllWithUserAsync();
        var today = DateTime.Now.Date;

        PendingRequests = all
            .Where(lr => lr.Status == "Pending" ||
                         (lr.Status == "Approved" && lr.EndDate >= today))
            .Select(lr => new LeaveRequestGet
            {
                LeaveRequestID = lr.LeaveRequestID,
               // UserID = lr.UserID,
                LeaveType = lr.LeaveType,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                Reason = lr.Reason,
                Status = lr.Status,
                UserName = lr.User.FirstName + " " + lr.User.LastName
            })
            .ToList();

    }
}
