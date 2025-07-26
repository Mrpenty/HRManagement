using HRManagement.Business.dtos.Auth;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HRManagement.Business.Repositories.impl
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenRepository _tokenRepository;


        public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _tokenRepository = tokenRepository;
        }


        public async Task<AuthMessDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email!);
            if (user == null)
            {
                return new AuthMessDTO { IsAuthSuccessful = false, ErrorMessage = "User not found." };
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            if (result.Succeeded)
            {
                var tokenDto = await _tokenRepository.CreateJWTTokenAsync(user, true);
                var roles = await _userManager.GetRolesAsync(user);

                _tokenRepository.SetTokenCookie(tokenDto, _httpContextAccessor.HttpContext);
                return new AuthMessDTO { IsAuthSuccessful = true, ErrorMessage = "Login successful",Id=user.Id ,Email=user.Email, Roles = roles, AccessToken = tokenDto.AccessToken, RefreshToken= tokenDto.RefreshToken };
            }
            else
            {
                return new AuthMessDTO { IsAuthSuccessful = false, ErrorMessage = "Invalid login attempt." };
            }
        }

        public async Task<AuthMessDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                NormalizedUserName = _userManager.NormalizeName(registerDTO.UserName),
                NormalizedEmail = _userManager.NormalizeEmail(registerDTO.Email),
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName
            };

            var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthMessDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = string.Join(", ", createdUser.Errors.Select(e => e.Description))
                };
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Employee");

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return new AuthMessDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = string.Join(", ", roleResult.Errors.Select(e => e.Description))
                };
            }

            return new AuthMessDTO
            {
                IsAuthSuccessful = true,
                Id = user.Id,         
                Email = user.Email,        
                Roles = ["Employee"]
            };
        }



        public async Task LogoutAsync()
        {
            _tokenRepository.DeleteTokenCookie(_httpContextAccessor.HttpContext);
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthMessDTO> RefreshTokenAsync(TokenDTO tokenDTO)
        {
            try
            {
                var tokenResult = await _tokenRepository.RefreshJWTTokenAsync(tokenDTO);

                _tokenRepository.SetTokenCookie(tokenResult, _httpContextAccessor.HttpContext);

                return new AuthMessDTO
                {
                    IsAuthSuccessful = true,
                    AccessToken = tokenResult.AccessToken,
                    RefreshToken = tokenResult.RefreshToken,
                };
            }
            catch (Exception)
            {
                return new AuthMessDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "failed"
                };
            }
        }
    }
}
