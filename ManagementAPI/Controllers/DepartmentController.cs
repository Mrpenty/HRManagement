using AutoMapper;
using HRManagement.Business.dtos.department;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var departments = await _departmentRepository.GetAsync();
                return Ok(_mapper.Map<IEnumerable<DepartmentGet>>(departments));
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var department = await _departmentRepository.GetByIdAsync(id);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<DepartmentGet>(department));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentCreate dpDto)
        {
            try
            {
                var existing = await _departmentRepository.GetByNameAsync(dpDto.DepartmentName);

                Console.WriteLine(existing);

                if (existing != null)
                {
                    return Conflict($"Department '{dpDto.DepartmentName}' already exists.");
                }

                var department = _mapper.Map<Department>(dpDto);
                department.Status = "Inactive"; // Đặt mặc định trạng thái
                await _departmentRepository.AddAsync(department);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = department.DepartmentID }, _mapper.Map<DepartmentGet>(department));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DepartmentCreate dpDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var department = await _departmentRepository.GetByIdAsync(id);

                if (department == null)
                {
                    return NotFound();
                }
                _mapper.Map(dpDto, department);
                
                await _departmentRepository.UpdateAsync(department);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var department = await _departmentRepository.GetByIdAsync(id);

                if (department == null)
                {
                    return NotFound();
                }

                await _departmentRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}