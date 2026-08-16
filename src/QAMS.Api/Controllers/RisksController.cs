// src/QAMS.Api/Controllers/RisksController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QAMS.Api.Filters;
using QAMS.Domain.Entities;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RisksController(QamsDbContext dbContext, ILogger<RisksController> logger) : ControllerBase
    {
        private readonly QamsDbContext _db = dbContext;
        private readonly ILogger<RisksController> _logger = logger;

        /// <summary>
        /// Obtiene los riesgos del producto calculados a partir de los requisitos del proyecto.
        /// (Implementación base para ISTQB Product Risk Analysis).
        /// </summary>
        [HttpGet]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetRisksByProject([FromQuery] Guid projectId)
        {
            _logger.LogInformation("GET /api/Risks?projectId={ProjectId}", projectId);

            // Obtener requisitos del proyecto
            var requirements = await _db.Set<Requirement>()
                .Where(r => r.ProjectId == projectId && !r.IsDeleted)
                .Include(r => r.RequirementTestCases)
                .Include(r => r.RequirementPriority)
                .Include(r => r.RequirementComplexity)
                .AsNoTracking()
                .ToListAsync();

            var risks = requirements.Select(r =>
            {
                // Cálculo simple de probabilidad e impacto basado en prioridad y complejidad del requisito
                // para propósitos del reporte RBT (Risk-Based Testing).
                int probability = MapTo1To5Scale(r.RequirementComplexity?.Name);
                int impact = MapTo1To5Scale(r.RequirementPriority?.Name);
                int score = probability * impact;

                return new
                {
                    id = r.Id,
                    projectId = r.ProjectId,
                    requirementCode = r.Code,
                    requirementTitle = r.Title,
                    category = DetermineCategory(r),
                    probability = probability,
                    impact = impact,
                    riskScore = score,
                    riskLevel = DetermineRiskLevel(score),
                    mitigationStrategy = "Asegurar cobertura de pruebas y revisión de código estática.",
                    associatedTestCasesCount = r.RequirementTestCases.Count
                };
            }).ToList();

            return Ok(risks);
        }

        private int MapTo1To5Scale(string? value)
        {
            return (value?.ToLower()) switch
            {
                "crítica" or "alto" or "alta" or "crítico" => 5,
                "media" or "medio" => 3,
                "baja" or "bajo" => 1,
                _ => 2,
            };
        }

        private string DetermineCategory(Requirement r)
        {
            // Podría basarse en el RequirementType
            return "Funcional";
        }

        private string DetermineRiskLevel(int score)
        {
            if (score >= 20) return "Crítico";
            if (score >= 12) return "Alto";
            if (score >= 5) return "Medio";
            return "Bajo";
        }
    }
}
