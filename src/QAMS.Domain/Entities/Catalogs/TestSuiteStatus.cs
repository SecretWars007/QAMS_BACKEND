// src/QAMS.Domain/Entities/Catalogs/TestSuiteStatus.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: Estados de la suite de pruebas.
    /// Valores: PENDIENTE, EN PROCESO, COMPLETADO, DETENIDO.
    /// </summary>
    public class TestSuiteStatus : CatalogBase
    {
        public ICollection<TestSuite> TestSuites { get; set; } = [];
    }
}
