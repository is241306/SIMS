namespace api.Models;

public enum UserRole
{
    Admin,
    User
}

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public bool IsDisabled { get; set; } = false;
}