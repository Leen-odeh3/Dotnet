namespace UserManagement.Core.DTOs.General;
public class LoginResponse
{
    public TokenType AccessToken { get; set; }
    public TokenType RefreshToken { get; set; }

}