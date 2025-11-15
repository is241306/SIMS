namespace sims.Models;

public enum UserRole
{
    Admin,
    User
}

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public bool IsDisabled { get; set; } = false;
}