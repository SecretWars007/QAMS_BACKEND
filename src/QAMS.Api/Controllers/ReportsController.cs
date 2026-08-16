// src/QAMS.Api/Controllers/ReportsController.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Reports;
using QAMS.Application.Interfaces;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportsController(
        IReportService reportService,
        ILogger<ReportsController> logger,
        QamsDbContext dbContext) : ControllerBase
    {
        private readonly IReportService _reportService = reportService;
        private readonly ILogger<ReportsController> _logger = logger;
        private readonly QamsDbContext _db = dbContext;

        /// <summary>
        /// Genera un reporte PDF detallado de un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("project")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetProjectReport([FromQuery] ProjectReportFilterDto filter)
        {
            _logger.LogInformation("Solicitando reporte PDF para el proyecto: {ProjectId}", filter.ProjectId);

            var pdfData = await _reportService.GenerateProjectReportAsync(filter);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte.");
            }

            string fileName = $"Reporte_Pruebas_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Genera un reporte PDF de tipo Burndown para un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("project/{projectId}/burndown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetBurndownReport(Guid projectId)
        {
            _logger.LogInformation("Solicitando reporte PDF de Burndown para el proyecto: {ProjectId}", projectId);

            var pdfData = await _reportService.GenerateBurndownReportAsync(projectId);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte de Burndown.");
            }

            string fileName = $"Reporte_Burndown_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Genera un reporte PDF con todas las observaciones registradas en un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("project/{projectId}/observations")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetObservationsReport(Guid projectId)
        {
            _logger.LogInformation("Solicitando reporte PDF de Observaciones para el proyecto: {ProjectId}", projectId);

            var pdfData = await _reportService.GenerateProjectObservationsReportAsync(projectId);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte de Observaciones.");
            }

            string fileName = $"Reporte_Observaciones_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Genera un Certificado de Cumplimiento Final en PDF para un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("project/{projectId}/compliance")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetComplianceReport(Guid projectId)
        {
            _logger.LogInformation("Solicitando reporte PDF de Cumplimiento Final para el proyecto: {ProjectId}", projectId);

            var pdfData = await _reportService.GenerateFinalComplianceReportAsync(projectId);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte de Cumplimiento.");
            }

            string fileName = $"Certificado_Cumplimiento_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Genera el reporte completo del proceso de certificación de QA. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("project/{projectId}/full-certification")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetFullCertificationReport(Guid projectId)
        {
            _logger.LogInformation("Solicitando reporte PDF de Certificación QA Completo para el proyecto: {ProjectId}", projectId);

            var pdfData = await _reportService.GenerateFullCertificationReportAsync(projectId);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte de certificación.");
            }

            string fileName = $"Reporte_Certificacion_QA_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Genera el reporte resumen ejecutivo para el usuario final. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("project/{projectId}/executive-summary")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetExecutiveSummaryReport(Guid projectId)
        {
            _logger.LogInformation("Solicitando reporte PDF del Resumen Ejecutivo de Aceptación para el proyecto: {ProjectId}", projectId);

            var pdfData = await _reportService.GenerateExecutiveSummaryReportAsync(projectId);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte de resumen ejecutivo.");
            }

            string fileName = $"Resumen_Ejecutivo_Liberacion_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Genera el Test Summary Report (ISTQB) en PDF para un plan de pruebas. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("test-plan/{planId}/summary")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetTestSummaryReport(Guid planId)
        {
            _logger.LogInformation("Solicitando reporte PDF de Test Summary Report para el plan: {PlanId}", planId);

            var pdfData = await _reportService.GenerateTestSummaryReportAsync(planId);

            if (pdfData == null || pdfData.Length == 0)
            {
                return NotFound("No se encontró información para generar el reporte de Test Summary.");
            }

            string fileName = $"Test_Summary_Report_{DateTime.Now:yyyyMMddHHmm}.pdf";
            return File(pdfData, "application/pdf", fileName);
        }

        /// <summary>
        /// Retorna la Matriz de Trazabilidad RTM (Requisitos ↔ Casos de Prueba ↔ Ejecuciones ↔ Defectos).
        /// ISTQB: trazabilidad bidireccional completa del proyecto.
        /// </summary>
        [HttpGet("rtm-matrix")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetRtmMatrix([FromQuery] Guid projectId)
        {
            _logger.LogInformation("Solicitando RTM Matrix para el proyecto: {ProjectId}", projectId);

            // Cargar requisitos con sus test cases vinculados
            var requirements = await _db.Set<QAMS.Domain.Entities.Requirement>()
                .Where(r => r.ProjectId == projectId)
                .Include(r => r.RequirementStatus)
                .Include(r => r.RequirementTestCases)
                    .ThenInclude(rtc => rtc.TestCase)
                        .ThenInclude(tc => tc!.TestExecutions)
                            .ThenInclude(e => e.Status)
                .Include(r => r.RequirementTestCases)
                    .ThenInclude(rtc => rtc.TestCase)
                        .ThenInclude(tc => tc!.Defects)
                            .ThenInclude(d => d.DefectSeverity)
                .AsNoTracking()
                .ToListAsync();

            var items = new List<object>();

            foreach (var req in requirements)
            {
                var linkedTestCases = req.RequirementTestCases
                    .Select(rtc => rtc.TestCase)
                    .Where(tc => tc != null)
                    .ToList();

                if (linkedTestCases.Count == 0)
                {
                    // Requisito sin casos de prueba: fila vacía
                    items.Add(new
                    {
                        requirementId = req.Id,
                        requirementCode = req.Code,
                        requirementTitle = req.Title,
                        requirementStatus = req.RequirementStatus?.Name ?? "N/A",
                        testCaseId = (Guid?)null,
                        testCaseCode = (string?)null,
                        testCaseTitle = (string?)null,
                        executionStatus = (string?)"Untested",
                        defectId = (Guid?)null,
                        defectTitle = (string?)null,
                        defectSeverity = (string?)null,
                        sutName = (string?)null
                    });
                }
                else
                {
                    foreach (var tc in linkedTestCases)
                    {
                        // Determinar estado de la última ejecución
                        var lastExec = tc!.TestExecutions
                            .Where(e => !e.IsDeleted)
                            .OrderByDescending(e => e.ExecutionDate)
                            .FirstOrDefault();

                        string execStatus = lastExec?.Status?.Code switch
                        {
                            "PASSED" => "Passed",
                            "FAILED" => "Failed",
                            "BLOCKED" => "Blocked",
                            null => "Untested",
                            _ => "Untested"
                        };

                        // Defecto más reciente del test case
                        var lastDefect = tc.Defects
                            .Where(d => !d.IsDeleted)
                            .OrderByDescending(d => d.CreatedAt)
                            .FirstOrDefault();

                        items.Add(new
                        {
                            requirementId = req.Id,
                            requirementCode = req.Code,
                            requirementTitle = req.Title,
                            requirementStatus = req.RequirementStatus?.Name ?? "N/A",
                            testCaseId = tc.Id,
                            testCaseCode = $"TC-{tc.Id.ToString()[..6].ToUpper()}",
                            testCaseTitle = tc.Title,
                            executionStatus = execStatus,
                            defectId = lastDefect?.Id,
                            defectTitle = lastDefect?.Title,
                            defectSeverity = lastDefect?.DefectSeverity?.Name,
                            sutName = (string?)null
                        });
                    }
                }
            }

            // Calcular métricas de resumen
            var totalRequirements = requirements.Count;
            var coveredRequirements = requirements.Count(r => r.RequirementTestCases.Any(rtc => rtc.TestCase != null));
            var coveragePercentage = totalRequirements > 0 ? (double)coveredRequirements / totalRequirements * 100 : 0;

            var allTestCaseIds = requirements
                .SelectMany(r => r.RequirementTestCases)
                .Select(rtc => rtc.TestCase)
                .Where(tc => tc != null)
                .Select(tc => tc!.Id)
                .Distinct()
                .ToList();

            var totalTestCases = allTestCaseIds.Count;
            var passedTestCases = requirements
                .SelectMany(r => r.RequirementTestCases)
                .Select(rtc => rtc.TestCase)
                .Where(tc => tc != null)
                .Count(tc => tc!.TestExecutions
                    .OrderByDescending(e => e.ExecutionDate)
                    .FirstOrDefault()?.Status?.Code == "PASSED");

            var openDefects = await _db.Set<QAMS.Domain.Entities.Defect>()
                .Where(d => d.ProjectId == projectId && !d.IsDeleted &&
                            d.DefectStatus != null && d.DefectStatus.Code != "CLOSED" && d.DefectStatus.Code != "RESOLVED")
                .CountAsync();

            return Ok(new
            {
                totalRequirements,
                coveredRequirements,
                coveragePercentage = Math.Round(coveragePercentage, 1),
                totalTestCases,
                passedTestCases,
                openDefects,
                items
            });
        }
    }
}
