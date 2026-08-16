// src/QAMS.Domain/Entities/Catalogs/DefectSeverity.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: severidades de defectos/bugs (ISTQB).
    /// Valores: MINOR, MAJOR, CRITICAL, BLOCKER
    /// </summary>
    public class DefectSeverity : CatalogBase
    {
        public ICollection<Defect> Defects { get; set; } = [];
    }
}
