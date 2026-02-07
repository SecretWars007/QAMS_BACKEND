// src/QAMS.Domain/Entities/Catalogs/EvidenceType.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: tipos de archivo de evidencia.
    /// Valores seed: IMAGE, VIDEO, DOCUMENT, LOG_FILE.
    /// </summary>
    public class EvidenceType : CatalogBase
    {
        /// <summary>Evidencias de este tipo (navegación inversa)</summary>
        public ICollection<Evidence> Evidences { get; set; } = new List<Evidence>();
    }
}
