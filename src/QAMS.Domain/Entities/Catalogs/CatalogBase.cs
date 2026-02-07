// src/QAMS.Domain/Entities/Catalogs/CatalogBase.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Clase base abstracta para todas las tablas catálogo.
    /// Reemplaza los enums estáticos por tablas administrables en BD.
    /// Principio DRY: campos comunes definidos una sola vez.
    /// Principio OCP: extensible para nuevos catálogos sin modificar.
    /// </summary>
    public abstract class CatalogBase
    {
        /// <summary>PK entera secuencial, optimiza joins</summary>
        public int Id { get; set; }

        /// <summary>Código único interno (ej: "PENDING")</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>Nombre legible para la UI (ej: "Pendiente")</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Descripción para tooltips o ayuda contextual</summary>
        public string? Description { get; set; }

        /// <summary>Orden de visualización en dropdowns</summary>
        public int SortOrder { get; set; }

        /// <summary>Soft delete lógico</summary>
        public bool IsActive { get; set; } = true;

        /// <summary>Auditoría de creación</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
