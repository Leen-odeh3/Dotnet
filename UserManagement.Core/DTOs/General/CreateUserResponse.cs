using UserManagement.Core.Models;

namespace UserManagement.Core.DTOs.General;
public class CreateUserResponse
{
    public string Token { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

}
