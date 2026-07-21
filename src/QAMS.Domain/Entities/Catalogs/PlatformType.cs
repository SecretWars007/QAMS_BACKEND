// src/QAMS.Domain/Entities/Catalogs/PlatformType.cs
using System.Collections.Generic;

namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Tipos de Plataforma para Sistemas Bajo Prueba (SUT).
    /// Valores: WEB, DESKTOP, DATA_PROCESSING.
    /// </summary>
    public class PlatformType : CatalogBase
    {
        public ICollection<SystemUnderTest> SystemsUnderTest { get; set; } = [];
    }
}
