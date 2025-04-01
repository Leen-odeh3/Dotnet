using UserManagement.Core.Models;

namespace UserManagement.Core.DTOs.General;
public class LoginOtpResponse
{
    public string Token { get; set; } = null!;
    public bool IsTwoFactorEnable { get; set; }
    public ApplicationUser User { get; set; } = null!;
}
