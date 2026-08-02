// src/QAMS.Api/Controllers/ReportsController.cs
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Reports;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportsController(IReportService reportService, ILogger<ReportsController> logger) : ControllerBase
    {
        private readonly IReportService _reportService = reportService;
        private readonly ILogger<ReportsController> _logger = logger;

        /// <summary>
        /// Genera un reporte PDF detallado de un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <param name="filter">Filtros para el reporte (ID de proyecto, rango de fechas).</param>
        /// <returns>Archivo PDF binario.</returns>
        [HttpGet("project")]
        [HasPermission("DASHBOARD_VIEW")] // Reutilizamos permiso de dashboard o creamos uno específico
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
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Archivo PDF binario.</returns>
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
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Archivo PDF binario.</returns>
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
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Archivo PDF binario.</returns>
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
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Archivo PDF binario.</returns>
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
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Archivo PDF binario.</returns>
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
        /// <param name="planId">ID del plan de pruebas.</param>
        /// <returns>Archivo PDF binario.</returns>
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
    }
}
