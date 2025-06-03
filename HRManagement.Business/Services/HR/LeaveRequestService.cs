using HRManagement.Business.Dtos.HR;
using HRManagement.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Services.HR
{
    public class LeaveRequestService
    {
        private readonly HRManagementDbContext _context;

        public LeaveRequestService(HRManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequestDto>> GetAllLeaveRequestsAsync()
        {
            return await _context.LeaveRequests
                .Include(x => x.User)
                .Select(x => new LeaveRequestDto
                {
                    LeaveRequestID = x.LeaveRequestID,
                    LeaveType = x.LeaveType,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Reason = x.Reason,
                    Status = x.Status,
                    EmployeeName = x.User.FirstName + " " + x.User.LastName,
                    ApproverNote = x.ApproverNote
                }).ToListAsync();
        }

        public async Task<bool> ApproveOrRejectLeaveRequestAsync(ApproveRejectRequestDTO dto, int approverId)
        {
            var request = await _context.LeaveRequests.FindAsync(dto.RequestId);
            if (request == null || request.Status != "Pending") return false;

            request.Status = dto.IsApproved ? "Approved" : "Rejected";
            request.ApproverID = approverId;
            request.ApproverNote = dto.ApproverNote;
            request.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

    }


}
