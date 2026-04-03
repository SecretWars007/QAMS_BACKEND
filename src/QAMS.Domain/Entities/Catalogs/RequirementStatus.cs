// src/QAMS.Domain/Entities/Catalogs/RequirementStatus.cs
using System.Collections.Generic;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Estados del requisito.
    /// Valores: DRAFT, IN_REVIEW, APPROVED, REJECTED, IMPLEMENTED, VERIFIED.
    /// </summary>
    public class RequirementStatus : CatalogBase
    {
        public ICollection<Requirement> Requirements { get; set; } = [];
    }
}
