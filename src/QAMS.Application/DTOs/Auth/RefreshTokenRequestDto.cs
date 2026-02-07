// src/QAMS.Application/DTOs/Auth/RefreshTokenRequestDto.cs
namespace QAMS.Application.DTOs.Auth
{
    public class RefreshTokenRequestDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
