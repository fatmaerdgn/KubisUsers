using Microsoft.AspNetCore.Identity;

namespace KubisUserDeneme.DAL.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string name { get; set; } = string.Empty;
    }
}
