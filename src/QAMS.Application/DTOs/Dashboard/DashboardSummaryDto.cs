// src/QAMS.Application/DTOs/Dashboard/DashboardSummaryDto.cs
namespace QAMS.Application.DTOs.Dashboard
{
    public class DashboardSummaryDto
    {
        public int TotalProjects { get; set; }
        public int TotalTestCases { get; set; }
        public int PendingTestCases { get; set; }
        public int TotalExecutions { get; set; }
        public int PassedExecutions { get; set; }
        public int FailedExecutions { get; set; }
        public int PendingExecutions { get; set; }
        public double PassRate { get; set; }
        public List<TaskProgressDto> TaskProgress { get; set; } = [];
        public List<ExecutionsByStatusDto> ExecutionsByStatus { get; set; } = [];

        // ── ISTQB Compliance: Métricas de Cobertura de Requisitos ──
        /// <summary>Total de requisitos en los proyectos del usuario</summary>
        public int TotalRequirements { get; set; }
        /// <summary>Requisitos con al menos 1 caso de prueba vinculado</summary>
        public int CoveredRequirements { get; set; }
        /// <summary>Porcentaje de cobertura de requisitos (0-100)</summary>
        public double RequirementCoverageRate { get; set; }

        // ── ISTQB Compliance: Defectos ──
        /// <summary>Total de defectos activos (no cerrados) en los proyectos del usuario</summary>
        public int OpenDefects { get; set; }
    }
}
