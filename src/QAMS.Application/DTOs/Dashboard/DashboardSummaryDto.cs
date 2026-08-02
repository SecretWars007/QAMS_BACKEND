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

    // ── ISTQB Phase 1: KPIs avanzados por proyecto ──
    public class IstqbMetricsDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        // Pass Rate (ya existente, ahora también por proyecto)
        public double PassRate { get; set; }

        // DDP: Defect Detection Percentage
        // % de defectos encontrados en testing vs. el total encontrado (incluyendo producción)
        // DDP = (Defectos_en_pruebas / Total_defectos) * 100
        // Un DDP alto indica que el equipo de pruebas es eficaz capturando defectos
        public double Ddp { get; set; }

        // DRE: Defect Removal Efficiency
        // % de defectos removidos antes de la entrega al cliente
        // DRE = (Defectos_internos / (Defectos_internos + Defectos_en_producción)) * 100
        public double Dre { get; set; }

        // MTTR: Mean Time To Repair (promedio en horas para cerrar un defecto)
        public double MttrHours { get; set; }

        // Cobertura de Requisitos
        public int TotalRequirements { get; set; }
        public int CoveredRequirements { get; set; }
        public double RequirementCoverageRate { get; set; }

        // Defectos
        public int TotalDefects { get; set; }
        public int OpenDefects { get; set; }
        public int ClosedDefects { get; set; }

        // Quality Gate Thresholds (configurables por proyecto)
        public double MinRequirementCoverage { get; set; }
        public double MinPassRate { get; set; }
        public int MaxOpenDefects { get; set; }
        public bool RequireSutLinked { get; set; }

        // Quality Gate Result — ¿Pasa o No?
        public bool QualityGatePassed { get; set; }
        public List<string> QualityGateFailures { get; set; } = [];
    }
}
