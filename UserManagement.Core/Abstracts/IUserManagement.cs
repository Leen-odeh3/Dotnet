using UserManagement.Core.DTOs.Auth;
using UserManagement.Core.DTOs.General;
using UserManagement.Core.Models;

namespace UserManagement.Core.Abstracts;
public interface IUserManagement
{
    Task<ApiResponse<CreateUserResponse>> CreateUserWithTokenAsync(Register registerUser);
    Task<ApiResponse<List<string>>> AssignRoleToUserAsync(List<string> roles, ApplicationUser user);
    Task<ApiResponse<LoginOtpResponse>> GetOtpByLoginAsync(Login loginModel);
    Task<ApiResponse<LoginResponse>> GetJwtTokenAsync(ApplicationUser user);
    Task<ApiResponse<LoginResponse>> LoginUserWithJWTokenAsync(string otp, string userName);
    Task<ApiResponse<LoginResponse>> RenewAccessTokenAsync(LoginResponse tokens);
}
