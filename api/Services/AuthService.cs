using System.Security.Cryptography;
using api.Data;
using api.DTOs.Users;
using api.DTOs.Authentication;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Services;

public class AuthService : IAuthService 
{
    private readonly SimsContext _context;
    private readonly IConfiguration _config;

    public AuthService(SimsContext context, IConfiguration config) 
    {
        _context = context;
        _config = config;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto) 
    {
        if (_context.Users.Any(u => u.Username == dto.Username))
            return false;

        // Passwort hashen mit PBKDF2
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: dto.Password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32
        ));

        var user = new User 
        {
            Username = dto.Username,
            PasswordHash = hash,
            PasswordSalt = Convert.ToBase64String(salt)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto) 
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
        if (user == null)
            return null;

        var saltBytes = Convert.FromBase64String(user.PasswordSalt);
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: dto.Password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32
        ));

        if (hash != user.PasswordHash)
            return null;

        var token = GenerateJwtToken(user);

        return new LoginResponseDto 
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddHours(1),
            Username = user.Username,
            Role = "User"
        };
    }

    private string GenerateJwtToken(User user) 
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> 
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim("uid", user.Id.ToString()),
            new Claim(ClaimTypes.Role, "User")
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}