using HRManagement.Business.dtos.Auth;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace HRManagement.Business.Repositories;

public interface ITokenRepository
{
    Task<TokenDTO> CreateJWTTokenAsync(User user, bool populateExp);
    Task<TokenDTO> RefreshJWTTokenAsync(TokenDTO tokenDTO);
    void SetTokenCookie(TokenDTO tokenDTO, HttpContext context);
    void DeleteTokenCookie(HttpContext context);    


}