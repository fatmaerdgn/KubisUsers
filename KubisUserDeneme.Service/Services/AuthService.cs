using KubisUserDeneme.DAL.Models;
using KubisUserDeneme.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KubisUserDeneme.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO model)
        {
            AppUser appUser = new()
            {
                Email = model.Email,
                UserName = model.Username,
                name = model.name
            };

            return await _userManager.CreateAsync(appUser, model.Password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            AppUser? appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanici bulunamadi" });
            }

            return await _userManager.ChangePasswordAsync(appUser, oldPassword, newPassword);
        }

        public async Task<string?> GeneratePasswordResetTokenAsync(string email)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
            {
                return null;
            }
            return await _userManager.GeneratePasswordResetTokenAsync(appUser);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanici bulunamadi" });
            }
            return await _userManager.ResetPasswordAsync(appUser, token, newPassword);
        }

        public async Task<bool> LoginAsync(LoginDTO model)
        {
            AppUser? appUser =
                await _userManager.Users
                .FirstOrDefaultAsync(x =>
                    x.Email == model.UserNameOrEmail ||
                    x.UserName == model.UserNameOrEmail);

            if (appUser == null)
            {
                return false; // Kullanıcı bulunamadı
            }

            return await _userManager.CheckPasswordAsync(appUser, model.Password);
        }
    }
}
