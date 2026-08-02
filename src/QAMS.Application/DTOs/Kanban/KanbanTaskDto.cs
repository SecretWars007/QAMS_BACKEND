// src/QAMS.Application/DTOs/Kanban/KanbanTaskDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    /// <summary>
    /// DTO de tarea Kanban enriquecido con contexto de certificación ISTQB.
    /// Incluye progreso de pasos, defectos abiertos y estado de ejecución
    /// para que la tarjeta Kanban refleje el avance real del proyecto.
    /// </summary>
    public class KanbanTaskDto
    {
        public Guid Id { get; set; }
        public Guid KanbanColumnId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? AssigneeId { get; set; }
        public string? AssigneeName { get; set; }
        public Guid? TestCaseId { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public string PriorityCode { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public int OrderIndex { get; set; }

        // ── Contexto de Certificación ISTQB ──

        /// <summary>Nombre del caso de prueba vinculado (si aplica).</summary>
        public string? TestCaseTitle { get; set; }

        /// <summary>Total de pasos de prueba del caso vinculado.</summary>
        public int TotalSteps { get; set; }

        /// <summary>Pasos con resultado PASS o FAIL (ejecutados).</summary>
        public int CompletedSteps { get; set; }

        /// <summary>Pasos aprobados (PASS) en la última ejecución.</summary>
        public int PassedSteps { get; set; }

        /// <summary>Defectos ABIERTOS asociados al TestCase (no cerrados).</summary>
        public int OpenDefectsCount { get; set; }

        /// <summary>Código del estado de la última ejecución: PENDING, IN_PROGRESS, PASSED, FAILED, BLOCKED.</summary>
        public string? LastExecutionStatusCode { get; set; }

        /// <summary>Nombre amigable del estado de la última ejecución.</summary>
        public string? LastExecutionStatusName { get; set; }

        /// <summary>Nombre del Sistema Bajo Prueba (SUT) vinculado al proyecto.</summary>
        public string? SutName { get; set; }

        /// <summary>true si el caso está vencido (DueDate < hoy).</summary>
        public bool IsOverdue => DueDate.HasValue && DueDate.Value < DateTime.UtcNow;

        /// <summary>Porcentaje de pasos completados (0-100).</summary>
        public int StepProgressPercent => TotalSteps > 0
            ? (int)Math.Round((double)CompletedSteps / TotalSteps * 100)
            : 0;
    }
}
