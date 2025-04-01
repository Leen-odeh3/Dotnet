namespace UserManagement.Core.DTOs.General;
public class TokenType
{
    public string Token { get; set; } = null!;
    public DateTime ExpiryTokenDate { get; set; }
}
