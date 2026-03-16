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

        /// <summary>Envía (o genera) un token de restablecimiento para el email indicado.</summary>
        Task<string> ForgotPasswordAsync(ForgotPasswordRequestDto request);

        /// <summary>Restablece la contraseña usando el token generado.</summary>
        Task ResetPasswordAsync(ResetPasswordRequestDto request);

        /// <summary>Cambia la contraseña de un usuario autenticado.</summary>
        Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request);

        /// <summary>Permite a un administrador restablecer la contraseña de cualquier usuario.</summary>
        Task AdminResetPasswordAsync(Guid targetUserId, string newPassword);
    }
}

