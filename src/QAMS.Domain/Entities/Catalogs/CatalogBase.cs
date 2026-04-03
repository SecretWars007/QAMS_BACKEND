// src/QAMS.Domain/Entities/Catalogs/CatalogBase.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Clase base abstracta para todas las tablas catálogo.
    /// </summary>
    public abstract class CatalogBase : IAuditable, ISoftDelete
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int SortOrder { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        /// <summary>Soft delete lógico (antiguo, se mantiene por compatibilidad temporal si es necesario, pero usaremos IsDeleted)</summary>
        public bool IsActive { get; set; } = true;
    }
}
