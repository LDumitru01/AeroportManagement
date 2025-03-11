namespace AirportManagement.Core.Authentification;

public class AuthResponse
{
    public string Token { get; set; }
    public string Email { get; set; }

    public AuthResponse(string token, string email)
    {
        Token = token;
        Email = email;
    }
}