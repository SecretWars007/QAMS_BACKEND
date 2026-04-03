// src/QAMS.Domain/Entities/Catalogs/RequirementType.cs
using System.Collections.Generic;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Tipos de requisitos.
    /// Valores: FUNCTIONAL, NON_FUNCTIONAL, TECHNICAL, USER_STORY.
    /// </summary>
    public class RequirementType : CatalogBase
    {
        public ICollection<Requirement> Requirements { get; set; } = [];
    }
}
