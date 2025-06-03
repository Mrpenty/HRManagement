using HRManagement.Business.Dtos.HR;
using HRManagement.Business.Services.HR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "HR")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly LeaveRequestService _leaveRequestService;

        public LeaveRequestController(LeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _leaveRequestService.GetAllLeaveRequestsAsync();
            return Ok(result);
        }

        [HttpPost("review")]
        public async Task<IActionResult> ReviewLeaveRequest([FromBody] ApproveRejectRequestDTO dto)
        {
            // lấy ID của người duyệt từ token
            var approverId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            var result = await _leaveRequestService.ApproveOrRejectLeaveRequestAsync(dto, approverId);
            if (!result) return BadRequest("Không tìm thấy đơn hoặc đơn đã được xử lý.");

            return Ok("Xử lý đơn thành công.");
        }


    }


}
