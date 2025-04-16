using KubisUserDeneme.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace KubisUserDeneme.Service.Services
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<List<AppRole>> GetAllRolesAsync();
    }
}
