using HRManagement.Business.Dtos.Employees;
using HRManagement.Business.Repositories;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.Security.Claims;


namespace HRManagement.Business.Services.Employee
{
    public class EmployeeService: IEmployeeService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _environment;

        public EmployeeService(UserManager<User> userManager, IEmployeeRepository employeeRepository, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _employeeRepository = employeeRepository;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }
        public async Task<UserProfileDTO> GetEmployeeByIdAsync(int userId, ClaimsPrincipal principal)
        {
            var user = await _employeeRepository.GetEmployeeByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var currentUser = await _userManager.GetUserAsync(principal);
            if (currentUser?.Id != userId)
            {
                throw new UnauthorizedAccessException("You can only view your own profile.");
            }

            return new UserProfileDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                HireDate = user.HireDate,
                PhoneNumber = user.PhoneNumber,
                ProfilePicture = user.ProfilePicture,
                DepartmentName = user.Department?.DepartmentName,
                EmployeeLevelName = user.EmployeeLevel?.EmployeeLevelName,
                ContractTypeName = user.ContractType?.ContractTypeName,
                PositionName = user.Position?.PositionName
            };
        }

        public async Task UpdateEmployeeAsync(int userId, UpdateUserProfileDTO dto, IFormFile? profilePicture, ClaimsPrincipal principal)
        {
            var user = await _employeeRepository.GetEmployeeByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var currentUser = await _userManager.GetUserAsync(principal);
            if (currentUser?.Id != userId)
            {
                throw new UnauthorizedAccessException("You can only update your own profile.");
            }

            
            user.FirstName = dto.FirstName ?? user.FirstName;
            user.LastName = dto.LastName ?? user.LastName;
            user.DateOfBirth = dto.DateOfBirth ?? user.DateOfBirth;

            if (profilePicture != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(profilePicture.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    throw new ArgumentException("Only .jpg, .jpeg, and .png files are allowed.");
                }

                const long maxFileSize = 5 * 1024 * 1024; // 5MB
                if (profilePicture.Length > maxFileSize)
                {
                    throw new ArgumentException("File size must not exceed 5MB.");
                }

                var webRootPath = _environment.WebRootPath;
                if (string.IsNullOrEmpty(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                var uploadsFolder = Path.Combine(webRootPath, "images/profiles");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = $"{userId}_{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await profilePicture.CopyToAsync(stream);
                }

                user.ProfilePicture = $"/images/profiles/{fileName}";
            }

            if (!string.IsNullOrWhiteSpace(dto.Email) && dto.Email != user.Email)
            {
                var emailChangeResult = await _userManager.SetEmailAsync(user, dto.Email);
                if (!emailChangeResult.Succeeded)
                {
                    throw new Exception("Failed to update email: " + string.Join(", ", emailChangeResult.Errors.Select(e => e.Description)));
                }
            }

            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber) && dto.PhoneNumber != user.PhoneNumber)
            {
                var phoneChangeResult = await _userManager.SetPhoneNumberAsync(user, dto.PhoneNumber);
                if (!phoneChangeResult.Succeeded)
                {
                    throw new Exception("Failed to update phone number: " + string.Join(", ", phoneChangeResult.Errors.Select(e => e.Description)));
                }
            }

            user.UpdatedAt = DateTime.UtcNow;
            await _employeeRepository.UpdateEmployeeAsync(user);
        }
    }

}

