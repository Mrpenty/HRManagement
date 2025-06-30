using HRManagement.Business.dtos.Auth;


namespace HRManagement.Business.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthMessDTO> LoginAsync(LoginDTO loginDTO);
        Task<AuthMessDTO> RegisterAsync(RegisterDTO registerDTO);
        Task LogoutAsync();
    }
}
