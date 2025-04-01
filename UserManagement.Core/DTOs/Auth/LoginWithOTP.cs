using System.ComponentModel.DataAnnotations;
namespace UserManagement.Core.DTOs.Auth;
public class LoginWithOTP
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Code is required")]
    public string Code { get; set; } = null!;
}