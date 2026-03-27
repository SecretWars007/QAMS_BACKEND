// src/QAMS.Domain/Entities/Catalogs/TestType.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Tipos de prueba.
    /// Valores seed: FUNCTIONAL_MANUAL, FUNCTIONAL_AUTOMATED, NON_FUNCTIONAL, REGRESSION, SMOKE.
    /// </summary>
    public class TestType : CatalogBase
    {
        public ICollection<TestCase> TestCases { get; set; } = [];
    }
}
