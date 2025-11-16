namespace sims.API.DTOs.Users
{

    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string IsActive { get; set; } = string.Empty;
    }
}