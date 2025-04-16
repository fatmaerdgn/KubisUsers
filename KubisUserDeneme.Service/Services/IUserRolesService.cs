using Microsoft.AspNetCore.Identity;

namespace KubisUserDeneme.Service.Services
{
    public interface IUserRolesService
    {
        Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName);
    }
}
