// src/QAMS.Domain/Entities/Catalogs/TestCasePriority.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: prioridades de casos de prueba.
    /// Separado de TaskPriority (4FN: independencia multivaluada).
    /// </summary>
    public class TestCasePriority : CatalogBase
    {
        /// <summary>Casos de prueba con esta prioridad</summary>
        public ICollection<TestCase> TestCases { get; set; } = new List<TestCase>();
    }
}
