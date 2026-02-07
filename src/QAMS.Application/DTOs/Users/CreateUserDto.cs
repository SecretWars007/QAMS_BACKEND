// src/QAMS.Application/DTOs/Users/CreateUserDto.cs
namespace QAMS.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public List<Guid> RoleIds { get; set; } = new();
    }
}
