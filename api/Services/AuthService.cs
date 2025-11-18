using System.Security.Cryptography;
using api.Data;
using api.DTOs.Users;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace api.Services;

public class AuthService : IAuthService {
    private readonly SimsContext _context;

    public AuthService(SimsContext context) {
        _context = context;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto) {
        var existing = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
        if (existing != null) return false;
        
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: dto.Password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32
        ));

        var user = new User {
            Username = dto.Username,
            PasswordHash = hash,
            PasswordSalt = Convert.ToBase64String(salt)
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }
}