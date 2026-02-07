// src/QAMS.Domain/Entities/Catalogs/ExecutionStatus.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: estados de ejecución de pruebas.
    /// Valores seed: PENDING, IN_PROGRESS, PASSED, FAILED, BLOCKED, SKIPPED.
    /// </summary>
    public class ExecutionStatus : CatalogBase
    {
        /// <summary>Ejecuciones con este estado (navegación inversa)</summary>
        public ICollection<TestExecution> TestExecutions { get; set; } = new List<TestExecution>();
    }
}
