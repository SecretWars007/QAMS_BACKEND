// src/QAMS.Domain/Entities/Catalogs/StepResultStatus.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: estados de resultado de paso individual.
    /// Valores seed: NOT_EXECUTED, PASSED, FAILED, BLOCKED.
    /// </summary>
    public class StepResultStatus : CatalogBase
    {
        /// <summary>Resultados de pasos con este estado</summary>
        public ICollection<ExecutionStepResult> ExecutionStepResults { get; set; } =
            new List<ExecutionStepResult>();
    }
}
