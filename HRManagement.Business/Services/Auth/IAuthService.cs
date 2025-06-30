using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagement.Business.dtos.Auth;


namespace HRManagement.Business.Repositories
{
    public interface IAuthService
    {
        Task<AuthMessDTO> LoginAsync(LoginDTO loginDTO);
        Task<AuthMessDTO> RegisterAsync(RegisterDTO registerDTO);
        Task LogoutAsync();
    }
}