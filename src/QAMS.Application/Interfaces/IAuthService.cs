// src/QAMS.Application/Interfaces/IAuthService.cs
using QAMS.Application.DTOs.Auth;

namespace QAMS.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task<LoginResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task RevokeRefreshTokenAsync(Guid userId);
    }
}
