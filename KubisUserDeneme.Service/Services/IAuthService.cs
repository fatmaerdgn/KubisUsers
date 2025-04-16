using KubisUserDeneme.DTO;
using Microsoft.AspNetCore.Identity;

namespace KubisUserDeneme.Service.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO model);
        Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<string?> GeneratePasswordResetTokenAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword);
        Task<bool> LoginAsync(LoginDTO model);
    }
}
