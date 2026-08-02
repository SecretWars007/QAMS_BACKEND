// src/QAMS.Domain/Entities/Defect.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Defecto/Bug encontrado durante una ejecución de prueba.
    /// ISTQB: un defecto es la causa de un fallo observado en la ejecución.
    /// Trazabilidad completa: Defecto → Ejecución → Caso de Prueba → Requisito.
    /// </summary>
    public class Defect : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Contexto del defecto
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }

        /// <summary>Caso de prueba donde se detectó el defecto (opcional)</summary>
        public Guid? TestCaseId { get; set; }
        public TestCase? TestCase { get; set; }

        /// <summary>Ejecución específica donde se detectó (opcional)</summary>
        public Guid? TestExecutionId { get; set; }
        public TestExecution? TestExecution { get; set; }

        /// <summary>Paso de ejecución específico donde se falló (opcional)</summary>
        public Guid? TestExecutionStepResultId { get; set; }
        public ExecutionStepResult? TestExecutionStepResult { get; set; }

        // Información del defecto
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? StepsToReproduce { get; set; }
        public string? ActualResult { get; set; }
        public string? ExpectedResult { get; set; }

        // Clasificación (ISTQB: severidad y prioridad)
        public int DefectPriorityId { get; set; }
        public DefectPriority? DefectPriority { get; set; }

        public int DefectStatusId { get; set; }
        public DefectStatus? DefectStatus { get; set; }

        // Responsables
        public Guid ReportedByUserId { get; set; }
        public User? ReportedBy { get; set; }

        public Guid? AssignedToUserId { get; set; }
        public User? AssignedTo { get; set; }

        public DateTime? ResolvedAt { get; set; }
        public string? ResolutionNotes { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
    }
}
