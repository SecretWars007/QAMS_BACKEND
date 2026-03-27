// src/QAMS.Api/Controllers/ReportsController.cs
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
    }
}
