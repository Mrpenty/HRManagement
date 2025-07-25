namespace HRManagement.Business.dtos.Auth;

public class AuthMessDTO
{
    public bool IsAuthSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; } = [];
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

