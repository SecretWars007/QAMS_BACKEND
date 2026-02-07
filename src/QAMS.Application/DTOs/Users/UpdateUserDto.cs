// src/QAMS.Application/DTOs/Users/UpdateUserDto.cs
namespace QAMS.Application.DTOs.Users
{
    public class UpdateUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<Guid> RoleIds { get; set; } = new();
    }
}
