// src/QAMS.Domain/Entities/Permission.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Permiso granular atómico del RBAC.</summary>
    public class Permission
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
