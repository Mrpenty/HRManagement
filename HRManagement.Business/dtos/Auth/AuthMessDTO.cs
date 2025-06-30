namespace HRManagement.Business.dtos.Auth;

public class AuthMessDTO
{
    public bool IsAuthSuccessful { get; set; }
    public string? ErrorMessage { get; set; }

    public string Token { get; set; }
}

