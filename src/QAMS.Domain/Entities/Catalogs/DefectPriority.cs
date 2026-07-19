// src/QAMS.Domain/Entities/Catalogs/DefectPriority.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: prioridades de defectos/bugs.
    /// Valores: LOW, MEDIUM, HIGH, CRITICAL
    /// </summary>
    public class DefectPriority : CatalogBase
    {
        public ICollection<Defect> Defects { get; set; } = [];
    }
}
