// src/QAMS.Domain/Entities/RolePermission.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Tabla puente M:N Role-Permission (4FN).</summary>
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
