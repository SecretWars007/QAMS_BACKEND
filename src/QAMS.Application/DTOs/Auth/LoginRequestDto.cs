// src/QAMS.Application/DTOs/Auth/LoginRequestDto.cs
namespace QAMS.Application.DTOs.Auth
{
    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
