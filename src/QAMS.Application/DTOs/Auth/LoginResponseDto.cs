// src/QAMS.Application/DTOs/Auth/LoginResponseDto.cs
namespace QAMS.Application.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string FullName { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new();
    }
}
