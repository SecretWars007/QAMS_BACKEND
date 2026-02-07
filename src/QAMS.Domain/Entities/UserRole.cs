// src/QAMS.Domain/Entities/UserRole.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Tabla puente M:N User-Role (4FN).</summary>
    public class UserRole
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
