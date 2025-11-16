using api.DTOs.Users;
using api.DTOs.Authentication;

namespace api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    }
}