// src/QAMS.Domain/Entities/Catalogs/ProjectPriority.cs
using System.Collections.Generic;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Prioridades del proyecto.
    /// Valores: LOW, MEDIUM, HIGH, CRITICAL.
    /// </summary>
    public class ProjectPriority : CatalogBase
    {
        public ICollection<Project> Projects { get; set; } = [];
    }
}
