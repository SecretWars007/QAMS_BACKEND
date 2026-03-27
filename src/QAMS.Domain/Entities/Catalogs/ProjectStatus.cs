// src/QAMS.Domain/Entities/Catalogs/ProjectStatus.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Estados del proyecto.
    /// Valores seed: PENDIENTE, EN_PROCESO, DETENIDO, CERTIFICADO.
    /// </summary>
    public class ProjectStatus : CatalogBase
    {
        public ICollection<Project> Projects { get; set; } = [];
    }
}
