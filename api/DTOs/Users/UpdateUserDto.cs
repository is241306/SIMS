using api.Models;

namespace api.DTOs.Users
{

    public class UpdateUserDto
    {
        public UserRole? Role { get; set; }
        public string? Password { get; set; } 
    }
}