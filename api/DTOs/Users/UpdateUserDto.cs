using api.Models;

namespace api.DTOs.Users
{

    public class UpdateUserDto
    {
        public UserRole? Role { get; set; }
        public string? Password { get; set; } 
        public List<int>? RoleIds { get; set; }
        public bool? IsActive { get; set; }

    }
}