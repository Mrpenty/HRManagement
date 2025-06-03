using HRManagement.Business.Dtos.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Services.HR
{
    public interface ILeaveRequestService
    {
        Task<bool> ApproveOrRejectAsync(int id, string status, string note, int approverId);
    }
}
