using System.ComponentModel.DataAnnotations;

namespace KubisUserDeneme.DTO
{
    public class RegisterDTO
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? name { get; set; }
        public string? Password { get; set; }

    }
}
