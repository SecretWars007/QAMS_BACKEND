// src/QAMS.Domain/Entities/Catalogs/RequirementComplexity.cs
using System.Collections.Generic;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Complejidades del requisito.
    /// Valores: SIMPLE, MODERATE, COMPLEX, VERY_COMPLEX.
    /// </summary>
    public class RequirementComplexity : CatalogBase
    {
        public ICollection<Requirement> Requirements { get; set; } = [];
    }
}
