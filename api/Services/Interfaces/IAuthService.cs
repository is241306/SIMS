using api.DTOs.Users;
using api.DTOs.Authentication;

namespace api.Services.Interfaces {
    public interface IAuthService {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    }
}