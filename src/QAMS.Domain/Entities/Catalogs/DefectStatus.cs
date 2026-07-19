// src/QAMS.Domain/Entities/Catalogs/DefectStatus.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: estados del ciclo de vida de un defecto (ISTQB).
    /// Valores: OPEN, IN_PROGRESS, RESOLVED, CLOSED, REJECTED
    /// </summary>
    public class DefectStatus : CatalogBase
    {
        public ICollection<Defect> Defects { get; set; } = [];
    }
}
