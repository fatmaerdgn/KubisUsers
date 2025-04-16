using KubisUserDeneme.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace KubisUserDeneme.Service.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRolesService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName)
        {
            AppUser? appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı Bulunamadı" });
            }

            return await _userManager.AddToRoleAsync(appUser, roleName);
        }
    }
}