// src/QAMS.Domain/Entities/Catalogs/RequirementPriority.cs
using System.Collections.Generic;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Prioridades del requisito.
    /// Valores: LOW, MEDIUM, HIGH, CRITICAL.
    /// </summary>
    public class RequirementPriority : CatalogBase
    {
        public ICollection<Requirement> Requirements { get; set; } = [];
    }
}
