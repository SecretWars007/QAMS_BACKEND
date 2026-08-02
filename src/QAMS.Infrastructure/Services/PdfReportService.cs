// src/QAMS.Infrastructure/Services/PdfReportService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Reports;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.Interfaces;

using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QAMS.Infrastructure.Services
{
    public class PdfReportService(
        IProjectRepository projectRepo,
        ITestExecutionRepository execRepo,
        IObservationRepository observationRepo,
        IEvidenceRepository evidenceRepo,
        QAMS.Application.Interfaces.Repositories.ITestPlanRepository testPlanRepo,
        IDashboardService dashboardService,
        ILogger<PdfReportService> logger) : IReportService
    {
        private readonly IProjectRepository _projectRepo = projectRepo;
        private readonly ITestExecutionRepository _execRepo = execRepo;
        private readonly IObservationRepository _observationRepo = observationRepo;
        private readonly IEvidenceRepository _evidenceRepo = evidenceRepo;
        private readonly QAMS.Application.Interfaces.Repositories.ITestPlanRepository _testPlanRepo = testPlanRepo;
        private readonly IDashboardService _dashboardService = dashboardService;
        private readonly ILogger<PdfReportService> _logger = logger;
        private readonly string _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        private const string ColorPrimary = "#1A237E";
        private const string ColorSuccess = "#2E7D32";
        private const string ColorLightPrimary = "#E8EAF6";
        private const string ColorBorder = "#E0E0E0";
        private const string ColorDanger = "#C62828";
        private const string ColorLightSuccess = "#E8F5E9";
        private const string ColorGrey = "#757575";
        private const string ColorGreen = "#4CAF50";
        private const string ColorRed = "#F44336";
        private const string DateFormat = "dd/MM/yyyy";
        private const string TypeImage = "IMAGE";
        private const string StatusPassed = "PASSED";
        private const string StatusAprobado = "Aprobado";

        static PdfReportService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public async System.Threading.Tasks.Task<byte[]> GenerateProjectReportAsync(ProjectReportFilterDto filter)
        {
            // ... (keep current implementation as it's the general report)
            // But I'll make sure it's updated with the latest logic
            return await GenerateProjectReportInternalAsync(filter.ProjectId);
        }

        public async Task<byte[]> GenerateBurndownReportAsync(Guid projectId)
        {
            return await GenerateProjectReportInternalAsync(projectId, isBurndownOnly: true);
        }

        public async Task<byte[]> GenerateProjectObservationsReportAsync(Guid projectId)
        {
            _logger.LogInformation("Generando reporte de observaciones para el proyecto {ProjectId}.", projectId);

            var projectList = await _projectRepo.FindWithDetailsAsync(p => p.Id == projectId);
            var project = projectList.FirstOrDefault();
            if (project == null) return [];

            // Obtener ejecuciones y sus IDs
            var executions = await _execRepo.GetByProjectAsync(projectId);
            var executionIds = executions.Select(e => e.Id).ToList();

            // Obtener todas las observaciones del proyecto con sus detalles
            var allObservations = await _observationRepo.GetByProjectAsync(executionIds);

            // Obtener evidencias para las observaciones
            var stepResultIds = allObservations.Select(o => o.ExecutionStepResultId).Distinct().ToList();
            var allEvidences = await _evidenceRepo.GetByStepResultsAsync(stepResultIds);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    // REFUERZO DE AESTHETICS: Header con gradiente simulado
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("QAMS - QUALITY ASSURANCE MANAGEMENT SYSTEM").FontSize(10).SemiBold().FontColor("#3F51B5");
                            col.Item().Text("REPORT DE HALLAZGOS Y OBSERVACIONES").FontSize(24).ExtraBold().FontColor(ColorPrimary);
                            col.Item().Text($"Proyecto: {project.Name}").FontSize(14).SemiBold().FontColor("#5C6BC0");
                        });

                        row.AutoItem().Column(col =>
                        {
                            col.Item().PaddingTop(5).Text($"Emisión: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9).FontColor(Colors.Grey.Darken1);
                            col.Item().AlignCenter().Text($"Devoluciones: {project.DevolucionesCounter}").FontSize(12).Bold().FontColor("#D32F2F");
                        });
                    });

                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        // SECCIÓN 1: RESUMEN EJECUTIVO
                        col.Item().BorderBottom(2).BorderColor(ColorPrimary).PaddingBottom(5).Text("1. RESUMEN DEL PROYECTO").FontSize(14).Bold().FontColor(ColorPrimary);
                        col.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(120);
                                columns.RelativeColumn();
                            });

                            table.Cell().Text("Descripción:").Bold();
                            table.Cell().Text(project.Description ?? "Sin descripción");

                            table.Cell().PaddingTop(5).Text("Fecha de Inicio:").Bold();
                            table.Cell().PaddingTop(5).Text(project.StartDate?.ToString(DateFormat) ?? "N/A");

                            table.Cell().PaddingTop(5).Text("Estado Actual:").Bold();
                            table.Cell().PaddingTop(5).Text(project.ProjectStatus?.Name ?? "N/A").FontColor(ColorSuccess).Bold();
                        });

                        // SECCIÓN 2: HISTÓRICO DE DEVOLUCIONES
                        col.Item().PaddingTop(25).BorderBottom(2).BorderColor(ColorPrimary).PaddingBottom(5).Text("2. HISTORIAL DE DEVOLUCIONES").FontSize(14).Bold().FontColor(ColorPrimary);

                        if (project.HistoricDevolutions == null || project.HistoricDevolutions.Count == 0)
                        {
                            col.Item().PaddingTop(10).Text("No existen registros históricos de devoluciones.").Italic().FontColor(Colors.Grey.Darken1);
                        }
                        else
                        {
                            col.Item().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(4);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(ColorLightPrimary).Padding(5).Text("F. Devolución").Bold().FontSize(9);
                                    header.Cell().Background(ColorLightPrimary).Padding(5).Text("Motivo / Notas").Bold().FontSize(9);
                                    header.Cell().Background(ColorLightPrimary).Padding(5).Text("F. Respuesta").Bold().FontSize(9);
                                    header.Cell().Background(ColorLightPrimary).Padding(5).Text("Respuesta").Bold().FontSize(9);
                                });

                                foreach (var dev in project.HistoricDevolutions.OrderByDescending(d => d.DevolutionDate))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(dev.DevolutionDate.ToString(DateFormat)).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(dev.Notes).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(dev.ResponseDate?.ToString(DateFormat) ?? "-").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(dev.ResponseNotes ?? "Pendiente").FontSize(8);
                                }
                            });
                        }

                        // SECCIÓN 3: DETALLE DE OBSERVACIONES Y EVIDENCIAS
                        page.Footer().AlignCenter().Text(x => { x.Span("Página "); x.CurrentPageNumber(); });

                        col.Item().PageBreak(); // Comenzar observaciones en nueva página para claridad

                        col.Item().BorderBottom(2).BorderColor(ColorPrimary).PaddingBottom(5).Text("3. DETALLE DE OBSERVACIONES Y EVIDENCIAS").FontSize(14).Bold().FontColor(ColorPrimary);

                        if (allObservations.Count == 0)
                        {
                            col.Item().PaddingTop(20).AlignCenter().Text("--- NO SE REGISTRARON HALLAZGOS DURANTE LAS EJECUCIONES ---").FontSize(12).SemiBold().FontColor(Colors.Grey.Darken1);
                        }
                        else
                        {
                            foreach (var obs in allObservations.OrderByDescending(o => o.CreatedAt))
                            {
                                col.Item().PaddingTop(20).Border(1).BorderColor(ColorBorder).Padding(0).Column(obsCol =>
                                {
                                    // Encabezado de la observación
                                    obsCol.Item().Background("#F5F5F5").Padding(8).Row(r =>
                                    {
                                        r.RelativeItem().Text($"Caso: {obs.ExecutionStepResult?.TestExecution?.TestCase?.Title ?? "N/A"}").FontSize(11).Bold().FontColor(ColorPrimary);
                                        r.AutoItem().Text(obs.CreatedAt.ToString("dd/MM/yyyy HH:mm")).FontSize(9).Italic();
                                    });

                                    obsCol.Item().Padding(10).Column(inner =>
                                    {
                                        inner.Item().Text(t =>
                                        {
                                            t.Span("Paso Registrado: ").Bold();
                                            t.Span(obs.ExecutionStepResult?.TestStep?.Action ?? "N/A");
                                        });

                                        inner.Item().PaddingTop(10).Background("#FFEBEE").Padding(8).Column(fault =>
                                        {
                                            fault.Item().Text("HALLAZGO / OBSERVACIÓN:").Bold().FontColor(ColorDanger).FontSize(9);
                                            fault.Item().PaddingTop(2).Text(obs.Observation).FontSize(10);
                                        });

                                        if (!string.IsNullOrEmpty(obs.Response))
                                        {
                                            inner.Item().PaddingTop(10).Background(ColorLightSuccess).Padding(8).Column(resp =>
                                            {
                                                resp.Item().Text("RESPUESTA DE INGENIERÍA:").Bold().FontColor(ColorSuccess).FontSize(9);
                                                resp.Item().PaddingTop(2).Text(obs.Response).FontSize(10);
                                            });
                                        }

                                        // EVIDENCIAS (Imágenes)
                                        var evidences = allEvidences.Where(e => e.ExecutionStepResultId == obs.ExecutionStepResultId &&
                                            (e.FileType?.Code == TypeImage || e.FileType?.Code == "VIDEO")).ToList();

                                        if (evidences.Count > 0)
                                        {
                                            inner.Item().PaddingTop(10).Text("EVIDENCIAS ADJUNTAS:").Bold().FontSize(9);
                                            inner.Item().PaddingTop(5).Table(table =>
                                            {
                                                table.ColumnsDefinition(columns =>
                                                {
                                                    columns.RelativeColumn();
                                                    columns.RelativeColumn();
                                                });

                                                // 1. Mostrar el archivo propio de la observación si existe y es imagen/video
                                                if (!string.IsNullOrEmpty(obs.FilePath) && (obs.FileType?.Code == TypeImage || obs.FileType?.Code == "VIDEO"))
                                                {
                                                    var obsFilePath = Path.Combine(_uploadsPath, obs.FilePath);
                                                    if (File.Exists(obsFilePath))
                                                    {
                                                        table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2).Column(imgCol =>
                                                        {
                                                            try
                                                            {
                                                                imgCol.Item().Image(obsFilePath).FitHeight();
                                                                imgCol.Item().Padding(2).AlignCenter().Text(obs.FileName ?? "Captura de observación").FontSize(7).Italic();
                                                            }
                                                            catch
                                                            {
                                                                imgCol.Item().Padding(10).Text("[Error al cargar imagen]").FontSize(8);
                                                            }
                                                        });
                                                    }
                                                }

                                                // 2. Mostrar las evidencias generales del paso
                                                foreach (var ev in evidences)
                                                {
                                                    var filePath = Path.Combine(_uploadsPath, ev.FilePath);
                                                    if (File.Exists(filePath))
                                                    {
                                                        table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2).Column(imgCol =>
                                                        {
                                                            try
                                                            {
                                                                imgCol.Item().Image(filePath).FitHeight();
                                                                imgCol.Item().Padding(2).AlignCenter().Text(ev.Description ?? "Captura de evidencia").FontSize(7).Italic();
                                                            }
                                                            catch
                                                            {
                                                                imgCol.Item().Padding(10).Text("[Error al cargar imagen]").FontSize(8);
                                                            }
                                                        });
                                                    }
                                                }
                                            });
                                        }
                                    });
                                });
                            }
                        }
                    });
                });
            });

            return document.GeneratePdf();
        }

        public async Task<byte[]> GenerateFinalComplianceReportAsync(Guid projectId)
        {
            _logger.LogInformation("Generando reporte de cumplimiento final para el proyecto {ProjectId}.", projectId);

            var project = await _projectRepo.GetFullProjectForComplianceReportAsync(projectId);
            if (project == null) return [];

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    // HEADER - Estilo Certificado
                    page.Header().BorderBottom(1).BorderColor(ColorSuccess).PaddingBottom(5).Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("CERTIFICADO DE CUMPLIMIENTO QA").FontSize(20).ExtraBold().FontColor(ColorSuccess);
                            col.Item().Text($"Proyecto: {project.Name}").FontSize(12).SemiBold();
                            col.Item().Text($"Fecha de Emisión: {DateTime.Now:dd/MM/yyyy}").FontSize(9).Italic();
                        });

                        row.AutoItem().Height(40).AlignCenter().Text("QAMS").FontSize(24).ExtraBold().FontColor(ColorSuccess);
                    });

                    page.Content().PaddingTop(20).Column(col =>
                    {
                        // 1. RESUMEN EJECUTIVO
                        col.Item().Text("1. RESUMEN EJECUTIVO").FontSize(14).Bold().FontColor(ColorSuccess);
                        col.Item().PaddingTop(5).Text(project.Description ?? "Este documento certifica que el proyecto ha pasado por las fases de validación de calidad correspondientes.");

                        // 2. PANEL DE RESULTADOS
                        col.Item().PaddingTop(20).Row(row =>
                        {
                            var totalCases = project.TestCases.Count;
                            var passedCases = project.TestCases.Count(tc => tc.TestExecutions.Any(e => e is QAMS.Domain.Entities.TestExecution te && te.IsSuccessful()));
                            var failedCases = project.TestCases.Count(tc => tc.TestExecutions.Any(e => e is QAMS.Domain.Entities.TestExecution te && te.IsFailed()));

                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(10).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("TOTAL CASOS").FontSize(9).FontColor(Colors.Grey.Darken1);
                                stat.Item().AlignCenter().Text(totalCases.ToString()).FontSize(18).Bold();
                            });

                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor("#C8E6C9").Background("#F1F8E9").Padding(10).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("CUMPLIDOS").FontSize(9).FontColor(ColorSuccess);
                                stat.Item().AlignCenter().Text(passedCases.ToString()).FontSize(18).Bold().FontColor(ColorSuccess);
                            });

                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor("#FFCDD2").Background("#FFEBEE").Padding(10).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("CON FALLOS").FontSize(9).FontColor(ColorDanger);
                                stat.Item().AlignCenter().Text(failedCases.ToString()).FontSize(18).Bold().FontColor(ColorDanger);
                            });

                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(10).Column(stat =>
                            {
                                decimal compliance = totalCases > 0 ? (decimal)passedCases / totalCases * 100 : 0;
                                stat.Item().AlignCenter().Text("% ÉXITO").FontSize(9).FontColor(Colors.Grey.Darken1);
                                stat.Item().AlignCenter().Text($"{compliance:N1}%").FontSize(18).Bold();
                            });
                        });

                        // 3. DETALLE DE CUMPLIMIENTO
                        col.Item().PaddingTop(25).Text("2. EVIDENCIAS DE CUMPLIMIENTO POR CASO DE PRUEBA").FontSize(14).Bold().FontColor(ColorSuccess);

                        foreach (var tc in project.TestCases.OrderBy(t => t.Title))
                        {
                            col.Item().PaddingTop(15).Border(0.5f).BorderColor(Colors.Grey.Lighten3).Padding(10).Column(tcBox =>
                            {
                                tcBox.Item().Row(r =>
                                {
                                    r.RelativeItem().Text(tc.Title).Bold().FontSize(11);

                                    var lastExec = tc.TestExecutions.OrderByDescending(e => (e as QAMS.Domain.Entities.TestExecution).ExecutionDate).FirstOrDefault() as QAMS.Domain.Entities.TestExecution;
                                    string statusName = lastExec?.Status?.Name ?? "PENDIENTE";
                                    string statusColor = lastExec?.Status?.Code == StatusPassed ? ColorSuccess : (lastExec == null ? ColorGrey : ColorDanger);

                                    r.AutoItem().Text(statusName).Bold().FontColor(statusColor);
                                });

                                if (!string.IsNullOrEmpty(tc.Description))
                                    tcBox.Item().PaddingTop(2).Text(tc.Description).FontSize(8).Italic().FontColor(Colors.Grey.Darken1);

                                // Evidencias del último resultado
                                if (tc.TestExecutions.OrderByDescending(e => (e as TestExecution).ExecutionDate).FirstOrDefault() is TestExecution { Evidences.Count: > 0 } lastExecResults &&
                                    lastExecResults.Evidences.Any(e => e.FileType is { Code: TypeImage }))
                                {
                                    tcBox.Item().PaddingTop(8).Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn();
                                            columns.RelativeColumn();
                                            columns.RelativeColumn();
                                        });

                                        foreach (var ev in lastExecResults.Evidences.Where(e => e.FileType?.Code == TypeImage).Take(6))
                                        {
                                            var path = Path.Combine(_uploadsPath, ev.FilePath);
                                            if (File.Exists(path))
                                            {
                                                table.Cell().Border(0.2f).BorderColor(Colors.Grey.Lighten2).Column(imgCol =>
                                                {
                                                    imgCol.Item().Image(path).FitWidth();
                                                    imgCol.Item().AlignCenter().Text(ev.Description ?? "Captura").FontSize(6);
                                                });
                                            }
                                        }
                                    });
                                }
                            });
                        }

                        // 4. HISTORIAL DE DEVOLUCIONES
                        if (project.HistoricDevolutions.Count > 0)
                        {
                            col.Item().PageBreak();
                            col.Item().Text("3. TRAZABILIDAD DE DEVOLUCIONES Y REPORTE DE HALLAZGOS").FontSize(14).Bold().FontColor(ColorSuccess);
                            col.Item().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn(3);
                                    columns.ConstantColumn(60);
                                    columns.RelativeColumn(2);
                                });
                                table.Header(h =>
                                {
                                    h.Cell().Background(ColorLightSuccess).Padding(5).Text("Fecha").Bold().FontSize(9);
                                    h.Cell().Background(ColorLightSuccess).Padding(5).Text("Motivo Devolución").Bold().FontSize(9);
                                    h.Cell().Background(ColorLightSuccess).Padding(5).Text("Obs. QA").Bold().FontSize(9);
                                    h.Cell().Background(ColorLightSuccess).Padding(5).Text("Estado / Respuesta").Bold().FontSize(9);
                                });

                                foreach (var dev in project.HistoricDevolutions.OrderByDescending(d => d.DevolutionDate))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(dev.DevolutionDate.ToString(DateFormat)).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(dev.Notes).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(dev.ObservationsCount.ToString()).FontSize(8).AlignCenter();
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(dev.ResponseNotes ?? "Pendiente de atención").FontSize(8);
                                }
                            });
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Documento generado automáticamente por QAMS v1.0. Página ");
                        x.CurrentPageNumber();
                    });
                });
            }).GeneratePdf();

            return document;
        }

        private async Task<byte[]> GenerateProjectReportInternalAsync(Guid projectId, bool isBurndownOnly = false)
        {
            _logger.LogInformation("Generando reporte interno (BurndownOnly: {IsBurndownOnly}) para {ProjectId}.", isBurndownOnly, projectId);

            var projectList = await _projectRepo.FindWithDetailsAsync(p => p.Id == projectId);
            var project = projectList.FirstOrDefault();

            if (project == null) return [];

            var executions = await _execRepo.GetByProjectAsync(projectId);
            var executionList = executions.ToList();

            var kanbanTasks = project.KanbanBoards
                .SelectMany(b => b.Columns)
                .SelectMany(c => c.Tasks)
                .ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor("#FFFFFF");
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Helvetica"));

                    // Header Profesional
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text(project.Name.ToUpper()).FontSize(24).ExtraBold().FontColor(ColorPrimary);
                            col.Item().PaddingTop(-5).Text(isBurndownOnly ? "REPORTE DE PROGRESO Y BURNDOWN (ENFOQUE DE TIEMPO)" : "REPORTE EJECUTIVO DE PROYECTO Y DETALLE QA").FontSize(10).SemiBold().FontColor("#5C6BC0");
                        });

                        row.AutoItem().Column(col =>
                        {
                            col.Item().Text(DateTime.Now.ToString("dd/MM/yyyy HH:mm")).FontSize(9).FontColor("#9E9E9E");
                            col.Item().Text("QAMS - Sistema de Gestión QA").FontSize(9).Italic().FontColor("#9E9E9E");
                        });
                    });

                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        // Sección 1: Información General
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(infoCol =>
                            {
                                infoCol.Item().BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("INFORMACIÓN GENERAL").FontSize(12).Bold().FontColor(ColorPrimary);
                                infoCol.Item().PaddingTop(5).Table(table =>
                                {
                                    table.ColumnsDefinition(c => { c.ConstantColumn(100); c.RelativeColumn(); });

                                    table.Cell().Text("Descripción:").Bold().FontSize(9);
                                    table.Cell().Text(project.Description ?? "N/A").FontSize(9);

                                    table.Cell().Text("Fecha Inicio:").Bold().FontSize(9);
                                    table.Cell().Text(project.StartDate?.ToString(DateFormat) ?? "N/A").FontSize(9);

                                    table.Cell().Text("Fecha Fin:").Bold().FontSize(9);
                                    table.Cell().Text(project.EndDate?.ToString(DateFormat) ?? "N/A").FontSize(9);

                                    table.Cell().Text("Prioridad:").Bold().FontSize(9);
                                    table.Cell().Text(project.ProjectPriority?.Name ?? "N/A").FontSize(9);
                                });
                            });

                            row.ConstantItem(20);

                            row.RelativeItem().Column(metricCol =>
                            {
                                metricCol.Item().BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("MÉTRICAS CLAVE").FontSize(12).Bold().FontColor(ColorPrimary);
                                metricCol.Item().PaddingTop(5).Row(mRow =>
                                {
                                    mRow.RelativeItem().Element(MetricBlock).Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Total Horas").FontSize(8).FontColor(ColorGrey);
                                        c.Item().AlignCenter().Text(project.GetCalculatedTotalHours().ToString("N1")).FontSize(14).Bold();
                                    });
                                    mRow.ConstantItem(5);
                                    mRow.RelativeItem().Element(MetricBlock).Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Total Días").FontSize(8).FontColor(ColorGrey);
                                        c.Item().AlignCenter().Text(project.GetCalculatedTotalDays().ToString()).FontSize(14).Bold();
                                    });
                                    mRow.ConstantItem(5);
                                    mRow.RelativeItem().Element(MetricBlock).Column(c =>
                                    {
                                        c.Item().AlignCenter().Text("Casos").FontSize(8).FontColor(ColorGrey);
                                        c.Item().AlignCenter().Text(project.TestCases.Count.ToString()).FontSize(14).Bold();
                                    });
                                    mRow.ConstantItem(5);
                                    mRow.RelativeItem().Element(MetricBlock).Column(c =>
                                    {
                                        var rate = CalculatePassRate(executionList);
                                        c.Item().AlignCenter().Text("Pass Rate").FontSize(8).FontColor(ColorGrey);
                                        c.Item().AlignCenter().Text($"{rate}%").FontSize(14).Bold().FontColor(rate >= 80 ? ColorGreen : ColorRed);
                                    });
                                });
                            });
                        });

                        // Sección 2: Gráfico Burndown (El protagonista)
                        col.Item().PaddingTop(25).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("TENDENCIA DE TRABAJO (BURNDOWN CHART - DÍAS HÁBILES)").FontSize(14).Bold().FontColor(ColorPrimary);
                        col.Item().PaddingTop(10).Element(c => DrawBurndownChart(c, project, executionList));

                        if (!isBurndownOnly)
                        {
                            // Sección 3: Otros Gráficos
                            col.Item().PaddingTop(25).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("PROGRESO Y LÍNEA DE TIEMPO").FontSize(12).Bold().FontColor(ColorPrimary);
                            col.Item().PaddingTop(10).Row(row =>
                            {
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().PaddingBottom(5).AlignCenter().Text("Drawdown (Casos)").FontSize(9).SemiBold();
                                    c.Item().Element(e => DrawDrawdownChart(e, project, executionList));
                                });
                                row.ConstantItem(15);
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().PaddingBottom(5).AlignCenter().Text("Timeline de Ejecuciones").FontSize(9).SemiBold();
                                    c.Item().Element(e => DrawTimeline(e, executionList));
                                });
                            });
                        }

                        if (!isBurndownOnly)
                        {
                            // Sección 4: Detalle de Escenarios y Casos de Prueba
                            col.Item().PaddingTop(25).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("DETALLE DE ESCENARIOS (SUITES) Y CASOS DE PRUEBA").FontSize(12).Bold().FontColor(ColorPrimary);

                            foreach (var suite in project.TestSuites.OrderBy(s => s.Name))
                            {
                                col.Item().PaddingTop(15).Background(ColorLightPrimary).Padding(5).Column(suiteCol =>
                                {
                                    suiteCol.Item().Text($"ESCENARIO: {suite.Name.ToUpper()}").FontSize(11).Bold().FontColor(ColorPrimary);
                                    if (!string.IsNullOrEmpty(suite.Description))
                                        suiteCol.Item().Text(suite.Description).FontSize(9).Italic().FontColor("#3F51B5");
                                });

                                var suiteTestCases = project.TestCases.Where(tc => tc.TestSuiteId == suite.Id).OrderBy(tc => tc.Title).ToList();

                                foreach (var testCase in suiteTestCases)
                                {
                                    col.Item().PaddingVertical(10).PaddingLeft(10).Column(caseCol =>
                                    {
                                        caseCol.Item().Row(row =>
                                        {
                                            row.RelativeItem().Text($"CASO DE PRUEBA: {testCase.Title.ToUpper()}").FontSize(10).Bold().FontColor("#1976D2");
                                        });

                                        caseCol.Item().PaddingLeft(5).Column(tcDetails =>
                                        {
                                            if (!string.IsNullOrEmpty(testCase.Description))
                                                tcDetails.Item().Text($"Descripción: {testCase.Description}").FontSize(9);

                                            tcDetails.Item().Text($"Precondiciones: {testCase.Preconditions ?? "N/A"}").FontSize(9);
                                            tcDetails.Item().Text($"Resultado Esperado: {testCase.ExpectedResult ?? "N/A"}").FontSize(9);
                                        });

                                        // Pasos Definidos del Caso
                                        if (testCase.TestSteps is { Count: > 0 })
                                        {
                                            caseCol.Item().PaddingTop(5).PaddingLeft(5).Text("Pasos del Caso de Prueba:").FontSize(9).SemiBold();
                                            caseCol.Item().PaddingLeft(5).Table(stepTable =>
                                            {
                                                stepTable.ColumnsDefinition(columns =>
                                                {
                                                    columns.ConstantColumn(20);
                                                    columns.RelativeColumn(3); // Acción (Descripción)
                                                    columns.RelativeColumn(3); // R. Esperado
                                                });

                                                stepTable.Header(header =>
                                                {
                                                    header.Cell().Element(HeaderBase).Text("#").FontSize(8);
                                                    header.Cell().Element(HeaderBase).Text("Descripción (Acción)").FontSize(8);
                                                    header.Cell().Element(HeaderBase).Text("R. Esperado").FontSize(8);
                                                });

                                                foreach (var step in testCase.TestSteps.OrderBy(s => s.StepOrder))
                                                {
                                                    stepTable.Cell().Element(CellStyle).Text(step.StepOrder.ToString()).FontSize(8);
                                                    stepTable.Cell().Element(CellStyle).Text(step.Action ?? "N/A").FontSize(8);
                                                    stepTable.Cell().Element(CellStyle).Text(step.ExpectedResult ?? "N/A").FontSize(8);
                                                }
                                            });
                                        }

                                        // Historial de Ejecuciones del Caso
                                        var caseExecs = executionList.Where(e => e.TestCaseId == testCase.Id).OrderByDescending(e => e.ExecutionDate).ToList();
                                        if (caseExecs.Count > 0)
                                        {
                                            caseCol.Item().PaddingTop(8).PaddingLeft(5).Text("EJECUCIONES REGISTRADAS:").FontSize(9).SemiBold().FontColor("#455A64");
                                            foreach (var exec in caseExecs)
                                            {
                                                caseCol.Item().PaddingLeft(10).PaddingVertical(5).BorderLeft(2).BorderColor("#EEEEEE").PaddingLeft(5).Column(execCol =>
                                                {
                                                    execCol.Item().Row(row =>
                                                    {
                                                        row.RelativeItem().Text($"Ejecución #{exec.Id.ToString()[..8].ToUpper()}").FontSize(9).SemiBold();
                                                        row.AutoItem().Text(exec.ExecutionDate.ToString("dd/MM/yyyy HH:mm")).FontSize(9).Italic();
                                                    });

                                                    if (!string.IsNullOrEmpty(exec.Notes))
                                                        execCol.Item().Text($"Descripción Ejecución (Notas): {exec.Notes}").FontSize(8).FontColor("#616161");

                                                    // Lógica de evaluación inteligente para el Estado Global
                                                    var isTrulyPassed = exec.IsSuccessful();
                                                    var isEnProgreso = exec.StatusId == 2 || exec.Status?.Code == "IN_PROGRESS";
                                                    var isInReview = exec.IsInReview();

                                                    var statusName = isTrulyPassed ? StatusAprobado : (isEnProgreso ? (isInReview ? "Completado/En Revisión" : "En Progreso") : (exec.Status?.Name ?? (exec.StatusId == 4 ? "Fallido" : (exec.StatusId == 1 ? "Pendiente" : exec.StatusId.ToString()))));
                                                    var statusColor = isTrulyPassed || isInReview ? ColorGreen : (isEnProgreso ? "#2196F3" : (exec.IsFailed() ? ColorRed : ColorGrey));

                                                    execCol.Item().Text(text =>
                                                    {
                                                        text.Span("Estado Global: ").FontSize(8);
                                                        text.Span(statusName).FontSize(8).Bold().FontColor(statusColor);
                                                    });

                                                    // Resultados por Paso en esta Ejecución
                                                    if (exec.StepResults is { Count: > 0 })
                                                    {
                                                        execCol.Item().PaddingTop(3).Text("Resultados de Pasos:").FontSize(8).SemiBold();
                                                        execCol.Item().Table(resTable =>
                                                        {
                                                            resTable.ColumnsDefinition(columns =>
                                                            {
                                                                columns.ConstantColumn(20);
                                                                columns.RelativeColumn(3); // Resultado (Descripción)
                                                                columns.ConstantColumn(90);
                                                            });

                                                            foreach (var res in exec.StepResults.OrderBy(sr => sr.TestStep?.StepOrder))
                                                            {
                                                                resTable.Cell().Element(CellStyle).Text(res.TestStep?.StepOrder.ToString() ?? "-").FontSize(7);
                                                                resTable.Cell().Element(CellStyle).Column(c =>
                                                                {
                                                                    c.Item().Text($"Resultado Actual: {res.ActualResult ?? "Sin resultado"}").FontSize(7);
                                                                    if (!string.IsNullOrEmpty(res.Notes)) c.Item().Text($"Descripción del Resultado (Notas): {res.Notes}").FontSize(7).Italic().FontColor("#455A64");
                                                                });

                                                                var sName = res.Status?.Name ?? (res.StatusId == 2 ? StatusAprobado : (res.StatusId == 3 ? "Fallido" : (res.StatusId == 1 ? "No Ejecutado" : res.StatusId.ToString())));
                                                                var sColor = (sName == StatusAprobado || res.StatusId == 2) ? ColorGreen : ((sName == "Fallido" || res.StatusId == 3) ? ColorRed : ColorGrey);

                                                                resTable.Cell().Element(CellStyle).Text(sName).FontSize(7).Bold().FontColor(sColor);

                                                                // Evidencias del PASO de ejecución específica
                                                                if (res.Evidences is { Count: > 0 })
                                                                {
                                                                    foreach (var ev in res.Evidences)
                                                                    {
                                                                        var p = Path.Combine(_uploadsPath, ev.FilePath);
                                                                        if (File.Exists(p) && ((ev.ContentType != null && ev.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)) || IsImageExtension(ev.FileName ?? "")))
                                                                        {
                                                                            resTable.Cell().ColumnSpan(3).PaddingTop(5).Column(evCol =>
                                                                            {
                                                                                if (!string.IsNullOrEmpty(ev.Description))
                                                                                    evCol.Item().PaddingLeft(10).Text($"Evidencia: {ev.Description}").FontSize(6).Italic();
                                                                                evCol.Item().PaddingLeft(10).MaxWidth(150).Image(p);
                                                                            });
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        });
                                                    }

                                                    // Evidencias generales de la Ejecución (Si las hay directas)
                                                    if (exec.Evidences is { Count: > 0 })
                                                    {
                                                        execCol.Item().PaddingTop(5).Text("Evidencias Generales de la Ejecución:").FontSize(8).SemiBold();
                                                        foreach (var evidence in exec.Evidences)
                                                        {
                                                            var fullPath = Path.Combine(_uploadsPath, evidence.FilePath);
                                                            if (File.Exists(fullPath) && ((evidence.ContentType != null && evidence.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)) || IsImageExtension(evidence.FileName ?? "")))
                                                            {
                                                                execCol.Item().PaddingVertical(5).Column(evCol =>
                                                                {
                                                                    if (!string.IsNullOrEmpty(evidence.Description))
                                                                        evCol.Item().Text($"Descripción Evidencia: {evidence.Description}").FontSize(7).Italic();
                                                                    evCol.Item().MaxWidth(200).Image(fullPath);
                                                                });
                                                            }
                                                        }
                                                    }
                                                });
                                            }
                                        }
                                        else
                                        {
                                            caseCol.Item().PaddingLeft(5).Text("Sin ejecuciones registradas.").Italic().FontSize(9).FontColor(ColorGrey);
                                        }
                                    });
                                }
                            }
                        }

                        if (!isBurndownOnly)
                        {
                            // Sección 5: Kanban
                            col.Item().PaddingTop(25).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("ESTADO DE TAREAS KANBAN").FontSize(12).Bold().FontColor(ColorPrimary);
                            col.Item().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(100);
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(HeaderBase).Text("Tarea").FontSize(9).Bold();
                                    header.Cell().Element(HeaderBase).Text("Estado").FontSize(9).Bold();
                                    header.Cell().Element(HeaderBase).Text("Asignado").FontSize(9).Bold();
                                });

                                foreach (var task in kanbanTasks)
                                {
                                    table.Cell().Element(CellStyle).Text(task.Title).FontSize(9);
                                    table.Cell().Element(CellStyle).Text(task.Column?.Name ?? "N/A").FontSize(9);
                                    table.Cell().Element(CellStyle).Text(task.ResponsibleUser?.FullName ?? "Unassigned").FontSize(9);
                                }
                            });
                        }
                    });

                    page.Footer().Column(fCol =>
                    {
                        fCol.Item().PaddingTop(10).BorderTop(0.5f).BorderColor("#EEEEEE").Row(row =>
                        {
                            row.RelativeItem().Text("Documento generado automáticamente por QAMS").FontSize(8).Italic().FontColor("#BDBDBD");
                            row.AutoItem().Text(x =>
                            {
                                x.Span("Página ").FontSize(8);
                                x.CurrentPageNumber().FontSize(8);
                            });
                        });
                    });
                });
            });

            return document.GeneratePdf();
        }

        private static IContainer MetricBlock(IContainer container)
        {
            return container
                .Background("#F5F5F5")
                .Padding(8)
                .Border(0.5f)
                .BorderColor(ColorBorder);
        }

        private static bool IsImageExtension(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            return string.Equals(ext, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ext, ".jpeg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ext, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ext, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ext, ".bmp", StringComparison.OrdinalIgnoreCase);
        }

        private static IContainer Block(IContainer container)
        {
            return container
                .Border(1)
                .Background("#f5f5f5")
                .Padding(5)
                .AlignCenter()
                .AlignMiddle();
        }

        private static IContainer HeaderBase(IContainer container)
        {
            return container
                .BorderBottom(1)
                .PaddingVertical(5)
                .AlignCenter();
        }

        private static IContainer CellStyle(IContainer container)
        {
            return container
                .BorderBottom(1)
                .BorderColor(ColorBorder)
                .PaddingVertical(5)
                .AlignCenter();
        }

        private static void DrawTimeline(IContainer container, List<TestExecution> executions)
        {
            if (executions == null || executions.Count == 0)
            {
                container.Text("Sin histórico de ejecuciones para mostrar en la línea de tiempo.").Italic().FontSize(9).FontColor(ColorGrey);
                return;
            }

            var sortedExecs = executions.OrderBy(e => e.ExecutionDate).ToList();
            var minDate = sortedExecs.First().ExecutionDate.Date;
            var uniqueDays = sortedExecs.Select(e => e.ExecutionDate.Date).Distinct().OrderBy(d => d).Take(14).ToList();

            // Definimos el rango de horas (Ej. de 8:00 a 20:00 o según los datos)
            var minHour = Math.Max(0, sortedExecs.Min(e => e.ExecutionDate.Hour) - 1);
            var maxHour = Math.Min(23, sortedExecs.Max(e => e.ExecutionDate.Hour) + 1);

            if (maxHour - minHour < 5) { minHour = 8; maxHour = 20; } // Rango mínimo estético

            container.Column(col =>
            {
                col.Item().PaddingBottom(5).Text("Eje X: Días del Proyecto | Eje Y: Horas").FontSize(8).Italic().FontColor(ColorGrey).AlignCenter();

                col.Item().Table(table =>
                {
                    // Definición de Columnas: Hora + N Días
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(40); // Columna de Horas (Eje Y)
                        foreach (var day in uniqueDays)
                        {
                            columns.RelativeColumn(); // Una columna por cada día (Eje X)
                        }
                    });

                    // Encabezado de la Tabla (Días)
                    table.Header(header =>
                    {
                        header.Cell().Element(MatrixHeaderStyle).Text("Hora \\ Día").FontSize(7).SemiBold();
                        foreach (var day in uniqueDays)
                        {
                            header.Cell().Element(MatrixHeaderStyle).Text(day.ToString("dd/MM")).FontSize(7).SemiBold();
                        }
                    });

                    // Filas por cada Hora
                    for (int hour = minHour; hour <= maxHour; hour++)
                    {
                        table.Cell().Element(MatrixAxisStyle).Text($"{hour:D2}:00").FontSize(7).FontColor(ColorGrey);

                        foreach (var day in uniqueDays)
                        {
                            var cellExecs = sortedExecs.Where(e => e.ExecutionDate.Date == day && e.ExecutionDate.Hour == hour).ToList();

                            var cell = table.Cell().Element(MatrixCellStyle);

                            if (cellExecs.Count > 0)
                            {
                                cell.Row(row =>
                                {
                                    row.Spacing(2);
                                    foreach (var exec in cellExecs.Take(3)) // Max 3 puntos por celda para no romper layout
                                    {
                                        row.AutoItem().Width(6).Height(6).Background(GetStatusColor(exec)).Border(1).BorderColor("#FFFFFF");
                                    }
                                });
                            }
                        }
                    }
                });
            });
        }

        private static IContainer MatrixHeaderStyle(IContainer container)
        {
            return container
                .Border(0.5f)
                .BorderColor(ColorBorder)
                .Background("#F5F5F5")
                .PaddingVertical(2)
                .AlignCenter()
                .AlignMiddle();
        }

        private static IContainer MatrixAxisStyle(IContainer container)
        {
            return container
                .Border(0.5f)
                .BorderColor(ColorBorder)
                .Background("#FAFAFA")
                .PaddingVertical(2)
                .AlignCenter()
                .AlignMiddle();
        }

        private static IContainer MatrixCellStyle(IContainer container)
        {
            return container
                .Border(0.5f)
                .BorderColor("#F0F0F0")
                .MinHeight(12)
                .AlignCenter()
                .AlignMiddle();
        }

        private static void DrawDrawdownChart(IContainer container, Project project, List<QAMS.Domain.Entities.TestExecution> executions)
        {
            var totalCases = project.TestCases.Count;
            if (totalCases == 0) return;

            var dayGroups = executions
                .OrderBy(e => e.ExecutionDate)
                .GroupBy(e => e.ExecutionDate.Date)
                .ToList();

            if (dayGroups.Count == 0)
            {
                container.Text("Sin datos de progreso para mostrar.").Italic().FontSize(9);
                return;
            }

            container.Column(col =>
            {
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2); // Fecha
                        columns.RelativeColumn(5); // Barra de Progreso
                        columns.RelativeColumn(2); // Quedan
                        columns.RelativeColumn(2); // % Completado
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(HeaderBase).Text("Fecha");
                        header.Cell().Element(HeaderBase).Text("Tendencia de Completitud");
                        header.Cell().Element(HeaderBase).Text("Pendientes");
                        header.Cell().Element(HeaderBase).Text("%");
                    });

                    var passedTestCases = new HashSet<Guid>();
                    foreach (var day in dayGroups)
                    {
                        foreach (QAMS.Domain.Entities.TestExecution exec in day)
                        {
                            var isTrulyPassed = (exec.StatusId == 3) ||
                                               (exec.StatusId == 2 && exec.StepResults != null && exec.StepResults.Count > 0 && exec.StepResults.All(sr => !string.IsNullOrEmpty(sr.ActualResult))) ||
                                               (exec.Status != null && (exec.Status.Code == StatusPassed || exec.Status.Name == StatusAprobado));

                            if (isTrulyPassed)
                                passedTestCases.Add(exec.TestCaseId);
                        }

                        var remaining = totalCases - passedTestCases.Count;
                        var progressPercent = (double)passedTestCases.Count / totalCases;

                        table.Cell().Element(CellStyle).Text(day.Key.ToString(DateFormat)).FontSize(8);

                        // Visualización del progreso (Barra)
                        table.Cell().Element(CellStyle).PaddingVertical(4).Row(row =>
                        {
                            row.RelativeItem(progressPercent > 0 ? (float)progressPercent : 0.001f).Height(8).Background(ColorGreen);
                            row.RelativeItem(1 - (float)progressPercent > 0 ? 1 - (float)progressPercent : 0.001f).Height(8).Background("#EEEEEE");
                        });

                        table.Cell().Element(CellStyle).Text(remaining.ToString()).FontSize(8).Bold();
                        table.Cell().Element(CellStyle).Text($"{Math.Round((1 - progressPercent) * 100, 1)}%").FontSize(8).FontColor(ColorGrey);
                    }
                });

                col.Item().PaddingTop(5).Text(x =>
                {
                    x.Span("Nota: ").SemiBold();
                    x.Span("Este gráfico muestra la reducción de casos de prueba pendientes a través del tiempo.").FontSize(8).Italic();
                });
            });
        }

        private static void DrawBurndownChart(IContainer container, Project project, List<QAMS.Domain.Entities.TestExecution> executions)
        {
            var totalHours = project.GetCalculatedTotalHours();
            if (totalHours == 0)
            {
                container.Text("No hay horas estimadas para este proyecto o el rango de fechas es inválido.").Italic().FontSize(9);
                return;
            }

            var startDate = project.StartDate ?? project.CreatedAt;
            var endDate = project.EndDate ?? (executions.Count > 0 ? executions.Max(e => e.ExecutionDate) : DateTime.Now);
            if (endDate < startDate) endDate = startDate.AddDays(7);

            var burnRate = project.WorkHoursPerDay > 0 ? project.WorkHoursPerDay : 7;

            var completedHoursByDay = executions
                .Where(e => (e.StatusId == 3) ||
                            (e.StatusId == 2 && e.StepResults != null && e.StepResults.Count > 0 && e.StepResults.All(sr => !string.IsNullOrEmpty(sr.ActualResult))) ||
                            (e.Status != null && (e.Status.Code == StatusPassed || e.Status.Name == StatusAprobado)))
                .GroupBy(e => e.ExecutionDate.Date)
                .ToDictionary(g => g.Key, g => g.Select(e => e.TestCase?.EstimatedTimeHours ?? 0).Sum());

            container.Column(col =>
            {
                col.Item().Background("#F8F9FA").Padding(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2); // Fecha
                        columns.RelativeColumn(5); // Visualización (Barras)
                        columns.RelativeColumn(2); // Ideal
                        columns.RelativeColumn(2); // Real
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(MatrixHeaderStyle).Text("Fecha").FontSize(8).Bold();
                        header.Cell().Element(MatrixHeaderStyle).Text("Progreso (Ideal vs Real)").FontSize(8).Bold();
                        header.Cell().Element(MatrixHeaderStyle).Text("Ideal (h)").FontSize(8).Bold();
                        header.Cell().Element(MatrixHeaderStyle).Text("Real (h)").FontSize(8).Bold();
                    });

                    decimal idealRemaining = totalHours;
                    decimal actualRemaining = totalHours;
                    var current = startDate.Date;
                    var finalDate = endDate.Date;

                    while (current <= finalDate || current <= DateTime.Now.Date)
                    {
                        // Excluir fines de semana de las filas del PDF
                        if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                        {
                            table.Cell().Element(CellStyle).Text(current.ToString(DateFormat)).FontSize(8);

                            var idealPercent = (float)(idealRemaining / totalHours);
                            var actualPercent = (float)(actualRemaining / totalHours);

                            table.Cell().Element(CellStyle).PaddingVertical(4).Column(bCol =>
                            {
                                // Ideal Bar (Blue)
                                bCol.Item().Row(row =>
                                {
                                    row.RelativeItem(idealPercent > 0 ? idealPercent : 0.001f).Height(5).Background("#1E88E5");
                                    row.RelativeItem(1 - idealPercent > 0 ? 1 - idealPercent : 0.001f).Height(5).Background("#E3F2FD");
                                });
                                // Actual Bar (Green)
                                bCol.Item().PaddingTop(2).Row(row =>
                                {
                                    row.RelativeItem(actualPercent > 0 ? actualPercent : 0.001f).Height(5).Background("#43A047");
                                    row.RelativeItem(1 - actualPercent > 0 ? 1 - actualPercent : 0.001f).Height(5).Background(ColorLightSuccess);
                                });
                            });

                            table.Cell().Element(CellStyle).Text(Math.Max(0, Math.Round(idealRemaining, 1)).ToString()).FontSize(8).FontColor("#1E88E5").Medium();
                            table.Cell().Element(CellStyle).Text(Math.Max(0, Math.Round(actualRemaining, 1)).ToString()).FontSize(8).Bold().FontColor("#43A047");

                            if (completedHoursByDay.TryGetValue(current, out var burnedToday))
                                actualRemaining -= burnedToday;

                            idealRemaining -= burnRate;
                        }

                        current = current.AddDays(1);

                        if (current > finalDate && current > DateTime.Now.Date) break;
                        if (current > startDate.AddDays(365)) break; // Limite de seguridad
                    }
                });

                col.Item().PaddingTop(10).BorderTop(1).BorderColor("#DEE2E6").PaddingTop(5).Text(x =>
                {
                    x.Span("Metodología: ").SemiBold().FontSize(8);
                    x.Span($"Calculado sobre {project.WorkHoursPerDay}h/día (Lun-Vie). Fines de semana excluidos. ").FontSize(8);
                    x.Span("Azul = Ideal, Verde = Real.").FontSize(8).Italic().FontColor("#6C757D");
                });
            });
        }

        private static string GetStatusColor(QAMS.Domain.Entities.TestExecution exec)
        {
            if (exec.StatusId == 3) return ColorGreen; // Aprobado
            if (exec.StatusId == 4) return ColorRed; // Fallido
            if (exec.StatusId == 2)
            {
                if (exec.StepResults != null && exec.StepResults.Count > 0 && exec.StepResults.All(sr => !string.IsNullOrEmpty(sr.ActualResult)))
                    return ColorGreen; // Completado
                return "#2196F3"; // En Progreso
            }
            return "#9E9E9E"; // Pendiente
        }

        private static double CalculatePassRate(IEnumerable<QAMS.Domain.Entities.TestExecution> executions)
        {
            if (executions == null || !executions.Any()) return 0;
            var list = executions.ToList();
            var passedCount = list.Count(e => e.Status?.Code == StatusPassed || e.StatusId == 3 || (e.StatusId == 2 && e.StepResults != null && e.StepResults.Count > 0 && e.StepResults.All(sr => !string.IsNullOrEmpty(sr.ActualResult))));
            return Math.Round((double)passedCount / list.Count * 100, 2);
        }
        public async Task<byte[]> GenerateTestSummaryReportAsync(Guid testPlanId)
        {
            var plan = await _testPlanRepo.GetByIdWithDetailsAsync(testPlanId);
            if (plan == null) return [];

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(c =>
                        c.BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(5)
                        .Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text($"Test Summary Report - {plan.Name}").FontSize(18).FontColor(ColorPrimary).Bold();
                                col.Item().Text($"Proyecto: {plan.Project?.Name}").FontSize(10).FontColor(Colors.Grey.Medium);
                            });
                        }));

                    page.Content().PaddingVertical(10).Column(column =>
                    {
                        column.Spacing(20);

                        column.Item().Text("1. Resumen Ejecutivo (Executive Summary)").FontSize(14).FontColor(ColorPrimary).Bold();
                        column.Item().Text(plan.Objectives ?? "Sin objetivos definidos.");

                        column.Item().Text("2. Criterios de Entrada y Salida (Entry / Exit Criteria)").FontSize(14).FontColor(ColorPrimary).Bold();
                        if (plan.Criteria != null && plan.Criteria.Any())
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(80);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(ColorLightPrimary).Padding(2).Text("Tipo").Bold();
                                    header.Cell().Background(ColorLightPrimary).Padding(2).Text("Descripción").Bold();
                                    header.Cell().Background(ColorLightPrimary).Padding(2).Text("Estado").Bold();
                                });

                                foreach (var crit in plan.Criteria)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(ColorBorder).Padding(2).Text(crit.CriteriaType);
                                    table.Cell().BorderBottom(1).BorderColor(ColorBorder).Padding(2).Text(crit.Description);

                                    string estado = crit.IsMet ? "CUMPLIDO" : "PENDIENTE";
                                    string color = crit.IsMet ? ColorSuccess : ColorDanger;

                                    table.Cell().BorderBottom(1).BorderColor(ColorBorder).Padding(2).Text(estado).FontColor(color).Bold();
                                }
                            });
                        }
                        else
                        {
                            column.Item().Text("No hay criterios definidos para este plan de pruebas.").Italic();
                        }
                    });

                    page.Footer().Element(c =>
                        c.AlignCenter().Text(t =>
                        {
                            t.Span("Página ");
                            t.CurrentPageNumber();
                            t.Span(" de ");
                            t.TotalPages();
                        }));
                });
            });

            using var ms = new MemoryStream();
            document.GeneratePdf(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> GenerateFullCertificationReportAsync(Guid projectId)
        {
            _logger.LogInformation("Generando reporte completo de certificación ISTQB para el proyecto {ProjectId}.", projectId);

            var project = await _projectRepo.GetFullProjectForComplianceReportAsync(projectId);
            if (project == null) return [];

            var executions = await _execRepo.GetByProjectAsync(projectId);
            var executionList = executions.ToList();
            var executionIds = executionList.Select(e => e.Id).ToList();
            var allObservations = await _observationRepo.GetByProjectAsync(executionIds);

            // ── ISTQB KPIs ─────────────────────────────────────────────────────
            IstqbMetricsDto? istqbMetrics = null;
            try { istqbMetrics = await _dashboardService.GetIstqbMetricsAsync(projectId); }
            catch (Exception ex) { _logger.LogWarning(ex, "No se pudo obtener las métricas ISTQB para el proyecto {ProjectId}.", projectId); }

            // ── Test Plan activo y sus criterios ────────────────────────────────
            var testPlans = await _testPlanRepo.GetByProjectAsync(projectId);
            var activePlan = testPlans.FirstOrDefault(tp => tp.Status?.Name == "ACTIVE" || tp.Status?.Name == "IN_PROGRESS")
                          ?? testPlans.OrderByDescending(tp => tp.UpdatedAt).FirstOrDefault();

            var totalCases = project.TestCases.Count;
            var passedCases = project.TestCases.Count(tc => tc.TestExecutions.Any(e => e is TestExecution te && te.IsSuccessful()));
            var failedCases = project.TestCases.Count(tc => tc.TestExecutions.Any(e => e is TestExecution te && te.IsFailed()));
            var otherCases = totalCases - passedCases - failedCases;
            decimal compliance = totalCases > 0 ? (decimal)passedCases / totalCases * 100 : 0;

            // Dictamen combinado: Quality Gate ISTQB + Pass Rate
            bool qualityGatePassed = istqbMetrics?.QualityGatePassed ?? (compliance >= 85 && failedCases == 0);
            string dictamen = qualityGatePassed ? "CERTIFICADO ISTQB — GO FOR RELEASE" : "NO CERTIFIABLE — QUALITY GATE FAILED";
            string dictamenColor = qualityGatePassed ? ColorSuccess : ColorDanger;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.2f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    // HEADER
                    page.Header().BorderBottom(2).BorderColor(ColorPrimary).PaddingBottom(5).Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("REPORTE INTEGRAL DE CERTIFICACIÓN QA").FontSize(18).ExtraBold().FontColor(ColorPrimary);
                            col.Item().Text($"Proyecto: {project.Name}").FontSize(11).Bold();
                            col.Item().Text($"Líder: {project.Leader?.FullName ?? project.CreatedBy?.FullName ?? "N/A"} | Emitido: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).Italic().FontColor(ColorGrey);
                        });
                        row.AutoItem().Height(40).AlignCenter().Text("QAMS").FontSize(22).ExtraBold().FontColor(ColorPrimary);
                    });

                    // CONTENT
                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        // 1. INFORMACIÓN DEL PROYECTO
                        col.Item().BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("1. INFORMACIÓN GENERAL DEL PROYECTO").FontSize(11).Bold().FontColor(ColorPrimary);
                        col.Item().PaddingTop(5).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(120);
                                columns.RelativeColumn();
                                columns.ConstantColumn(100);
                                columns.RelativeColumn();
                            });

                            table.Cell().Text("Descripción:").Bold();
                            table.Cell().ColumnSpan(3).Text(project.Description ?? "Sin descripción.");

                            table.Cell().PaddingTop(4).Text("Fecha Inicio:").Bold();
                            table.Cell().PaddingTop(4).Text(project.StartDate?.ToString(DateFormat) ?? "N/A");
                            table.Cell().PaddingTop(4).Text("Fecha Fin:").Bold();
                            table.Cell().PaddingTop(4).Text(project.EndDate?.ToString(DateFormat) ?? "N/A");

                            table.Cell().PaddingTop(4).Text("Estado del Proyecto:").Bold();
                            table.Cell().PaddingTop(4).Text(project.ProjectStatus?.Name ?? "N/A");
                            table.Cell().PaddingTop(4).Text("Prioridad:").Bold();
                            table.Cell().PaddingTop(4).Text(project.ProjectPriority?.Name ?? "N/A");
                        });

                        // 2. ISTQB QUALITY GATE & KPIs
                        col.Item().PaddingTop(15).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2)
                            .Text("2. QUALITY GATE ISTQB — KPIs (ISO 29119 / CTFL)").FontSize(11).Bold().FontColor(ColorPrimary);

                        if (istqbMetrics != null)
                        {
                            var m = istqbMetrics; // local non-nullable reference for lambdas
                            // Quality Gate result banner
                            col.Item().PaddingTop(8).Background(dictamenColor).Padding(10).Row(qgRow =>
                            {
                                qgRow.RelativeItem().AlignCenter().Text(dictamen).FontSize(14).Bold().FontColor(Colors.White);
                            });

                            if (m.QualityGateFailures.Count > 0)
                            {
                                col.Item().PaddingTop(5).Column(failCol =>
                                {
                                    failCol.Item().Text("Razones de falla del Quality Gate:").Bold().FontSize(9).FontColor(ColorDanger);
                                    foreach (var failure in m.QualityGateFailures)
                                        failCol.Item().PaddingLeft(10).Text($"• {failure}").FontSize(8).FontColor(ColorDanger);
                                });
                            }

                            // KPI Cards grid
                            col.Item().PaddingTop(10).Row(row =>
                            {
                                // Pass Rate
                                row.RelativeItem().Border(1).BorderColor(ColorBorder).Padding(8).Column(c =>
                                {
                                    c.Item().AlignCenter().Text("PASS RATE").FontSize(7).Bold().FontColor(ColorGrey);
                                    c.Item().AlignCenter().Text($"{m.PassRate:N1}%").FontSize(18).ExtraBold()
                                        .FontColor(m.PassRate >= m.MinPassRate ? ColorSuccess : ColorDanger);
                                    c.Item().AlignCenter().Text($"Umbral: {m.MinPassRate}%").FontSize(7).FontColor(ColorGrey);
                                });

                                // DDP
                                row.RelativeItem().PaddingLeft(4).Border(1).BorderColor(ColorBorder).Padding(8).Column(c =>
                                {
                                    c.Item().AlignCenter().Text("DDP").FontSize(7).Bold().FontColor(ColorGrey);
                                    c.Item().AlignCenter().Text($"{m.Ddp:N1}%").FontSize(18).ExtraBold().FontColor(ColorPrimary);
                                    c.Item().AlignCenter().Text("Defect Detection %").FontSize(7).FontColor(ColorGrey);
                                });

                                // DRE
                                row.RelativeItem().PaddingLeft(4).Border(1).BorderColor(ColorBorder).Padding(8).Column(c =>
                                {
                                    c.Item().AlignCenter().Text("DRE").FontSize(7).Bold().FontColor(ColorGrey);
                                    c.Item().AlignCenter().Text($"{m.Dre:N1}%").FontSize(18).ExtraBold().FontColor(ColorPrimary);
                                    c.Item().AlignCenter().Text("Defect Removal Eff.").FontSize(7).FontColor(ColorGrey);
                                });

                                // MTTR
                                row.RelativeItem().PaddingLeft(4).Border(1).BorderColor(ColorBorder).Padding(8).Column(c =>
                                {
                                    c.Item().AlignCenter().Text("MTTR").FontSize(7).Bold().FontColor(ColorGrey);
                                    c.Item().AlignCenter().Text($"{m.MttrHours:N1}h").FontSize(18).ExtraBold().FontColor(ColorPrimary);
                                    c.Item().AlignCenter().Text("Mean Time To Repair").FontSize(7).FontColor(ColorGrey);
                                });

                                // Req Coverage
                                row.RelativeItem().PaddingLeft(4).Border(1).BorderColor(ColorBorder).Padding(8).Column(c =>
                                {
                                    c.Item().AlignCenter().Text("REQ COVERAGE").FontSize(7).Bold().FontColor(ColorGrey);
                                    c.Item().AlignCenter().Text($"{m.RequirementCoverageRate:N1}%").FontSize(18).ExtraBold()
                                        .FontColor(m.RequirementCoverageRate >= m.MinRequirementCoverage ? ColorSuccess : ColorDanger);
                                    c.Item().AlignCenter().Text($"Umbral: {m.MinRequirementCoverage}%").FontSize(7).FontColor(ColorGrey);
                                });
                            });

                            // Defect summary
                            col.Item().PaddingTop(5).Row(row =>
                            {
                                row.RelativeItem().Padding(4).Text($"Defectos Totales: {m.TotalDefects}  |  Abiertos: {m.OpenDefects}  |  Cerrados: {m.ClosedDefects}  |  Límite permitido: {m.MaxOpenDefects} abiertos")
                                    .FontSize(8).FontColor(ColorGrey);
                            });
                        }
                        else
                        {
                            col.Item().PaddingTop(8).Background(dictamenColor).Padding(10).AlignCenter()
                                .Text(dictamen).FontSize(14).Bold().FontColor(Colors.White);
                            col.Item().PaddingTop(5).Text("Las métricas ISTQB detalladas no están disponibles para este proyecto.").Italic().FontColor(ColorGrey);
                        }

                        // 3. PLAN DE PRUEBAS Y CRITERIOS ENTRY/EXIT (ISO 29119-3)
                        col.Item().PaddingTop(15).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2)
                            .Text("3. PLAN DE PRUEBAS — CRITERIOS DE ENTRADA/SALIDA (ISO 29119-3)").FontSize(11).Bold().FontColor(ColorPrimary);

                        if (activePlan != null)
                        {
                            col.Item().PaddingTop(5).Table(planInfo =>
                            {
                                planInfo.ColumnsDefinition(c => { c.ConstantColumn(100); c.RelativeColumn(); c.ConstantColumn(80); c.RelativeColumn(); });
                                planInfo.Cell().Text("Plan:").Bold().FontSize(8);
                                planInfo.Cell().Text(activePlan.Name ?? "N/A").FontSize(8);
                                planInfo.Cell().Text("Estado:").Bold().FontSize(8);
                                planInfo.Cell().Text(activePlan.Status?.Name ?? "N/A").FontSize(8);
                                if (!string.IsNullOrEmpty(activePlan.TestStrategy))
                                {
                                    planInfo.Cell().PaddingTop(4).Text("Estrategia:").Bold().FontSize(8);
                                    planInfo.Cell().PaddingTop(4).Text(activePlan.TestStrategy).FontSize(8);
                                    planInfo.Cell();
                                    planInfo.Cell();
                                }
                            });

                            var entryCriteria = activePlan.Criteria.Where(c => c.CriteriaType == "ENTRY").ToList();
                            var exitCriteria = activePlan.Criteria.Where(c => c.CriteriaType == "EXIT").ToList();

                            if (entryCriteria.Count > 0 || exitCriteria.Count > 0)
                            {
                                col.Item().PaddingTop(8).Row(criteriaRow =>
                                {
                                    // Entry Criteria
                                    criteriaRow.RelativeItem().Column(ec =>
                                    {
                                        ec.Item().Background(ColorLightPrimary).Padding(4).Text("Criterios de ENTRADA").Bold().FontSize(9).FontColor(ColorPrimary);
                                        int metCount = entryCriteria.Count(c => c.IsMet);
                                        ec.Item().PaddingLeft(4).Text($"{metCount}/{entryCriteria.Count} cumplidos").FontSize(8)
                                            .FontColor(metCount == entryCriteria.Count ? ColorSuccess : ColorDanger);
                                        foreach (var criterion in entryCriteria)
                                        {
                                            ec.Item().PaddingLeft(4).PaddingTop(3).Row(r =>
                                            {
                                                r.AutoItem().Width(10).Text(criterion.IsMet ? "✓" : "✗").FontSize(9)
                                                    .FontColor(criterion.IsMet ? ColorSuccess : ColorDanger);
                                                r.RelativeItem().Text(criterion.Description ?? string.Empty).FontSize(8);
                                            });
                                        }
                                    });

                                    criteriaRow.ConstantItem(10); // spacer

                                    // Exit Criteria
                                    criteriaRow.RelativeItem().Column(xc =>
                                    {
                                        xc.Item().Background(ColorLightPrimary).Padding(4).Text("Criterios de SALIDA").Bold().FontSize(9).FontColor(ColorPrimary);
                                        int metCount = exitCriteria.Count(c => c.IsMet);
                                        xc.Item().PaddingLeft(4).Text($"{metCount}/{exitCriteria.Count} cumplidos").FontSize(8)
                                            .FontColor(metCount == exitCriteria.Count ? ColorSuccess : ColorDanger);
                                        foreach (var criterion in exitCriteria)
                                        {
                                            xc.Item().PaddingLeft(4).PaddingTop(3).Row(r =>
                                            {
                                                r.AutoItem().Width(10).Text(criterion.IsMet ? "✓" : "✗").FontSize(9)
                                                    .FontColor(criterion.IsMet ? ColorSuccess : ColorDanger);
                                                r.RelativeItem().Text(criterion.Description ?? string.Empty).FontSize(8);
                                            });
                                        }
                                    });
                                });
                            }
                            else
                            {
                                col.Item().PaddingTop(5).Text("No se definieron criterios de entrada/salida para el plan de pruebas activo.").Italic().FontColor(ColorGrey);
                            }
                        }
                        else
                        {
                            col.Item().PaddingTop(5).Text("No existe un plan de pruebas asociado a este proyecto.").Italic().FontColor(ColorGrey);
                        }

                        col.Item().PageBreak();

                        // 4. SISTEMAS BAJO PRUEBA (SUT)
                        col.Item().PaddingTop(15).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("4. ENTORNOS Y SISTEMAS BAJO PRUEBA (SUT)").FontSize(11).Bold().FontColor(ColorPrimary);
                        if (project.SystemUnderTest == null)
                        {
                            col.Item().PaddingTop(5).Text("No se registraron Sistemas Bajo Prueba (SUT) para este proyecto.").Italic().FontColor(ColorGrey);
                        }
                        else
                        {
                            col.Item().PaddingTop(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Nombre
                                    columns.RelativeColumn(2); // Plataforma
                                    columns.ConstantColumn(50);  // Versión
                                    columns.ConstantColumn(60);  // Entorno
                                    columns.RelativeColumn(3); // Detalles de acceso
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Nombre").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Plataforma").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Versión").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Entorno").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Detalles de Acceso / Ruta").Bold().FontSize(8);
                                });

                                var sut = project.SystemUnderTest;
                                
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(sut.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(sut.PlatformType?.Name ?? "Web").FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(sut.Version ?? "1.0.0").FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(sut.Environment ?? "QA").FontSize(8);

                                string details = "-";
                                if (sut.PlatformType?.Code == "DESKTOP")
                                {
                                    details = $"Ejecutable: {sut.ExecutablePath ?? "N/A"}\nProceso: {sut.ProcessName ?? "N/A"}";
                                    if (!string.IsNullOrEmpty(sut.BaseUrl)) details += $"\nServidor: {sut.BaseUrl}";
                                }
                                else if (!string.IsNullOrEmpty(sut.BaseUrl))
                                {
                                    details = sut.BaseUrl;
                                }

                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(details).FontSize(8);
                                
                            });
                        }

                        // 5. MATRIZ DE REQUERIMIENTOS Y COBERTURA
                        col.Item().PaddingTop(15).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("5. MATRIZ DE TRAZABILIDAD DE REQUERIMIENTOS").FontSize(11).Bold().FontColor(ColorPrimary);
                        if (project.Requirements == null || project.Requirements.Count == 0)
                        {
                            col.Item().PaddingTop(5).Text("No se registraron requerimientos asociados al proyecto.").Italic().FontColor(ColorGrey);
                        }
                        else
                        {
                            col.Item().PaddingTop(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(60);  // Código
                                    columns.RelativeColumn(3); // Requerimiento
                                    columns.ConstantColumn(80);  // Tipo
                                    columns.ConstantColumn(70);  // Estado
                                    columns.RelativeColumn(3); // Casos de Prueba
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Código").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Título del Requerimiento").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Tipo").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Estado").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Casos de Prueba Vinculados").Bold().FontSize(8);
                                });

                                foreach (var req in project.Requirements.OrderBy(r => r.Code))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(req.Code).FontSize(8).Bold();
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(req.Title).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(req.RequirementType?.Name ?? "Funcional").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(req.RequirementStatus?.Name ?? "Borrador").FontSize(8);

                                    var testCaseTitles = req.RequirementTestCases
                                        .Select(rtc => rtc.TestCase?.Title)
                                        .Where(t => t != null)
                                        .ToList();

                                    string linkedTests = testCaseTitles.Count > 0 
                                        ? string.Join(", ", testCaseTitles)
                                        : "Sin casos asociados";

                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(linkedTests).FontSize(8).Italic();
                                }
                            });
                        }

                        col.Item().PageBreak(); // Siguiente sección en nueva página

                        // 6. RESUMEN DE EJECUCIONES
                        col.Item().BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("6. RESUMEN DE EJECUCIONES DE PRUEBA").FontSize(11).Bold().FontColor(ColorPrimary);
                        col.Item().PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("CASOS DE PRUEBA").FontSize(8).FontColor(ColorGrey);
                                stat.Item().AlignCenter().Text(totalCases.ToString()).FontSize(16).Bold();
                            });
                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor("#C8E6C9").Background("#F1F8E9").Padding(8).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("EXITOSOS").FontSize(8).FontColor(ColorSuccess);
                                stat.Item().AlignCenter().Text(passedCases.ToString()).FontSize(16).Bold().FontColor(ColorSuccess);
                            });
                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor("#FFCDD2").Background("#FFEBEE").Padding(8).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("FALLIDOS").FontSize(8).FontColor(ColorDanger);
                                stat.Item().AlignCenter().Text(failedCases.ToString()).FontSize(16).Bold().FontColor(ColorDanger);
                            });
                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("PEND./OTROS").FontSize(8).FontColor(ColorGrey);
                                stat.Item().AlignCenter().Text(otherCases.ToString()).FontSize(16).Bold();
                            });
                            row.RelativeItem().PaddingLeft(5).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(stat =>
                            {
                                stat.Item().AlignCenter().Text("ÉXITO (PASS RATE)").FontSize(8).FontColor(ColorGrey);
                                stat.Item().AlignCenter().Text($"{compliance:N1}%").FontSize(16).Bold().FontColor(compliance >= 90 ? ColorSuccess : ColorDanger);
                            });
                        });

                        // 7. HISTORIAL DE DEVOLUCIONES
                        if (project.HistoricDevolutions != null && project.HistoricDevolutions.Count > 0)
                        {
                            col.Item().PaddingTop(20).BorderBottom(1).BorderColor(ColorPrimary).PaddingBottom(2).Text("7. HISTORIAL DE DEVOLUCIONES").FontSize(11).Bold().FontColor(ColorPrimary);
                            col.Item().PaddingTop(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Fecha
                                    columns.RelativeColumn(4); // Notas / Motivo
                                    columns.RelativeColumn(2); // Resp. Fecha
                                    columns.RelativeColumn(4); // Respuesta
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("F. Devolución").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Notas / Motivo").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("F. Respuesta").Bold().FontSize(8);
                                    h.Cell().Background(ColorLightPrimary).Padding(4).Text("Respuesta de Ingeniería").Bold().FontSize(8);
                                });

                                foreach (var dev in project.HistoricDevolutions.OrderByDescending(d => d.DevolutionDate))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(dev.DevolutionDate.ToString(DateFormat)).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(dev.Notes).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(dev.ResponseDate?.ToString(DateFormat) ?? "-").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(4).Text(dev.ResponseNotes ?? "Pendiente").FontSize(8);
                                }
                            });
                        }

                        // 8. FIRMAS DE ACEPTACIÓN (ISO 29119-3 §10)
                        var qaLeaderName = project.Leader?.FullName ?? project.CreatedBy?.FullName ?? "QA Manager";
                        var generatedAt = DateTime.Now;

                        col.Item().PaddingTop(20).Background("#F0F4FF").Border(0.5f).BorderColor(ColorPrimary).Padding(10).Column(stamp =>
                        {
                            stamp.Item().Row(r =>
                            {
                                r.RelativeItem().Text($"Documento generado el: {generatedAt:dd/MM/yyyy} a las {generatedAt:HH:mm} UTC-4").FontSize(8).FontColor(ColorGrey);
                                r.AutoItem().Text("ISO/IEC/IEEE 29119-3 COMPLIANT").FontSize(8).Bold().FontColor(ColorPrimary);
                            });
                            stamp.Item().PaddingTop(4).Text("Este documento constituye el Informe Oficial de Certificación de Calidad de Software conforme al estándar ISO/IEC/IEEE 29119-3. Su contenido ha sido generado automáticamente por el sistema QAMS y refleja el estado verificado del ciclo de pruebas del proyecto.").FontSize(7).Italic().FontColor(ColorGrey);
                        });

                        col.Item().PaddingTop(30).Row(row =>
                        {
                            row.RelativeItem().Column(sig =>
                            {
                                sig.Item().AlignCenter().Text("_________________________________").FontSize(9);
                                sig.Item().AlignCenter().Text(qaLeaderName).FontSize(9).Bold().FontColor(ColorPrimary);
                                sig.Item().AlignCenter().Text("Responsable de Calidad (QA)").FontSize(8).FontColor(ColorGrey);
                                sig.Item().AlignCenter().Text($"Fecha: {generatedAt:dd/MM/yyyy}").FontSize(7).FontColor(ColorGrey).Italic();
                            });
                            row.RelativeItem().Column(sig =>
                            {
                                sig.Item().AlignCenter().Text("_________________________________").FontSize(9);
                                sig.Item().AlignCenter().Text("Líder de Ingeniería / Dev Lead").FontSize(9).Bold();
                                sig.Item().AlignCenter().Text("Equipo de Desarrollo").FontSize(8).FontColor(ColorGrey);
                                sig.Item().AlignCenter().Text("Fecha: ___/___/______").FontSize(7).FontColor(ColorGrey).Italic();
                            });
                            row.RelativeItem().Column(sig =>
                            {
                                sig.Item().AlignCenter().Text("_________________________________").FontSize(9);
                                sig.Item().AlignCenter().Text("Product Owner / Cliente").FontSize(9).Bold();
                                sig.Item().AlignCenter().Text("Aceptación Final del Producto").FontSize(8).FontColor(ColorGrey);
                                sig.Item().AlignCenter().Text("Fecha: ___/___/______").FontSize(7).FontColor(ColorGrey).Italic();
                            });
                        });

                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Documento oficial de Certificación de Calidad. Página ");
                        x.CurrentPageNumber();
                    });
                });
            });

            using var ms = new MemoryStream();
            document.GeneratePdf(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> GenerateExecutiveSummaryReportAsync(Guid projectId)
        {
            _logger.LogInformation("Generando resumen ejecutivo para el proyecto {ProjectId}.", projectId);

            var project = await _projectRepo.GetFullProjectForComplianceReportAsync(projectId);
            if (project == null) return [];

            var executions = await _execRepo.GetByProjectAsync(projectId);
            var executionList = executions.ToList();
            var executionIds = executionList.Select(e => e.Id).ToList();
            var allObservations = await _observationRepo.GetByProjectAsync(executionIds);

            var totalCases = project.TestCases.Count;
            var passedCases = project.TestCases.Count(tc => tc.TestExecutions.Any(e => e is TestExecution te && te.IsSuccessful()));
            var failedCases = project.TestCases.Count(tc => tc.TestExecutions.Any(e => e is TestExecution te && te.IsFailed()));
            decimal compliance = totalCases > 0 ? (decimal)passedCases / totalCases * 100 : 0;

            // Cobertura de Requerimientos
            int totalReqs = project.Requirements.Count;
            int coveredReqs = project.Requirements.Count(r => r.RequirementTestCases.Count > 0);
            decimal reqCoverage = totalReqs > 0 ? (decimal)coveredReqs / totalReqs * 100 : 0;

            // Determinar dictamen de liberación
            string verdict = "EN EVALUACIÓN";
            string verdictDesc = "El proyecto se encuentra en fases de ejecución de pruebas y estabilización.";
            string verdictColor = "#FF9800"; // Orange
            string verdictBg = "#FFF3E0";

            if (totalCases > 0)
            {
                if (compliance >= 95 && failedCases == 0 && project.DevolucionesCounter <= 2)
                {
                    verdict = "APROBADO PARA PRODUCCIÓN";
                    verdictDesc = "El sistema cumple satisfactoriamente con los criterios de aceptación y calidad definidos. Se autoriza el despliegue.";
                    verdictColor = ColorSuccess;
                    verdictBg = "#E8F5E9";
                }
                else if (failedCases > 0 || project.DevolucionesCounter > 3)
                {
                    verdict = "RECHAZADO / CON OBSERVACIONES CRÍTICAS";
                    verdictDesc = "El sistema presenta fallos pendientes o ha superado el límite de devoluciones. Se requiere remediación inmediata.";
                    verdictColor = ColorDanger;
                    verdictBg = "#FFEBEE";
                }
                else
                {
                    verdict = "APROBADO CONDICIONADO";
                    verdictDesc = "Cumple parcialmente con observaciones menores no críticas. Despliegue bajo supervisión y plan de acción.";
                    verdictColor = "#FF9800";
                    verdictBg = "#FFF3E0";
                }
            }

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    // HEADER
                    page.Header().BorderBottom(1).BorderColor(ColorBorder).PaddingBottom(5).Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("RESUMEN EJECUTIVO DE CERTIFICACIÓN QA").FontSize(16).ExtraBold().FontColor(ColorPrimary);
                            col.Item().Text($"Proyecto: {project.Name}").FontSize(11).Bold();
                            col.Item().Text($"Versión: {project.Version} | Fecha Emisión: {DateTime.Now:dd/MM/yyyy}").FontSize(8).Italic().FontColor(ColorGrey);
                        });
                        row.AutoItem().Height(40).AlignCenter().Text("QAMS").FontSize(22).ExtraBold().FontColor(ColorPrimary);
                    });

                    // CONTENT
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        // 1. BANNER DE DICTAMEN DE CALIDAD
                        col.Item().Border(1).BorderColor(verdictColor).Background(verdictBg).Padding(12).Column(vBox =>
                        {
                            vBox.Item().AlignCenter().Text("DICTAMEN DE LIBERACIÓN").FontSize(9).Bold().FontColor(verdictColor);
                            vBox.Item().AlignCenter().Text(verdict).FontSize(16).ExtraBold().FontColor(verdictColor);
                            vBox.Item().PaddingTop(5).AlignCenter().Text(verdictDesc).FontSize(9).Italic().FontColor(Colors.Black);
                        });

                        // 2. INDICADORES CLAVE (KPIs)
                        col.Item().PaddingTop(25).Text("INDICADORES CLAVE DE CALIDAD (KPIs)").FontSize(12).Bold().FontColor(ColorPrimary);
                        col.Item().PaddingTop(8).Row(row =>
                        {
                            row.RelativeItem().Border(0.5f).BorderColor(ColorBorder).Background("#FAFAFA").Padding(10).Column(kpi =>
                            {
                                kpi.Item().AlignCenter().Text("ÉXITO DE PRUEBAS").FontSize(8).FontColor(ColorGrey);
                                kpi.Item().AlignCenter().Text($"{compliance:N1}%").FontSize(18).Bold().FontColor(compliance >= 90 ? ColorSuccess : ColorDanger);
                                kpi.Item().AlignCenter().Text($"{passedCases} de {totalCases} aprobados").FontSize(7).Italic();
                            });
                            row.ConstantItem(10);
                            row.RelativeItem().Border(0.5f).BorderColor(ColorBorder).Background("#FAFAFA").Padding(10).Column(kpi =>
                            {
                                kpi.Item().AlignCenter().Text("COBERTURA REQS").FontSize(8).FontColor(ColorGrey);
                                kpi.Item().AlignCenter().Text($"{reqCoverage:N1}%").FontSize(18).Bold().FontColor(reqCoverage >= 80 ? ColorSuccess : "#FF9800");
                                kpi.Item().AlignCenter().Text($"{coveredReqs} de {totalReqs} cubiertos").FontSize(7).Italic();
                            });
                            row.ConstantItem(10);
                            row.RelativeItem().Border(0.5f).BorderColor(ColorBorder).Background("#FAFAFA").Padding(10).Column(kpi =>
                            {
                                kpi.Item().AlignCenter().Text("HALLAZGOS REGISTRADOS").FontSize(8).FontColor(ColorGrey);
                                int totalObs = allObservations.Count;
                                int openObs = allObservations.Count(o => string.IsNullOrEmpty(o.Response));
                                kpi.Item().AlignCenter().Text(totalObs.ToString()).FontSize(18).Bold().FontColor(openObs > 0 ? ColorDanger : ColorSuccess);
                                kpi.Item().AlignCenter().Text($"{openObs} pendientes").FontSize(7).Italic();
                            });
                            row.ConstantItem(10);
                            row.RelativeItem().Border(0.5f).BorderColor(ColorBorder).Background("#FAFAFA").Padding(10).Column(kpi =>
                            {
                                kpi.Item().AlignCenter().Text("DEVOLUCIONES").FontSize(8).FontColor(ColorGrey);
                                kpi.Item().AlignCenter().Text(project.DevolucionesCounter.ToString()).FontSize(18).Bold().FontColor(project.DevolucionesCounter > 2 ? ColorDanger : ColorSuccess);
                                kpi.Item().AlignCenter().Text("Ciclos de corrección").FontSize(7).Italic();
                            });
                        });

                        // 3. RESUMEN DEL SISTEMA EVALUADO
                        col.Item().PaddingTop(25).Text("RESUMEN DE PLATAFORMAS EVALUADAS").FontSize(12).Bold().FontColor(ColorPrimary);
                        if (project.SystemUnderTest == null)
                        {
                            col.Item().PaddingTop(5).Text("No hay información de plataformas o sistemas bajo prueba configurados.").Italic().FontSize(9).FontColor(ColorGrey);
                        }
                        else
                        {
                            col.Item().PaddingTop(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3); // Nombre
                                    columns.RelativeColumn(2); // Tipo
                                    columns.ConstantColumn(80);  // Entorno
                                    columns.RelativeColumn(4); // Dirección / URL / Executable
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Background("#F5F5F5").Padding(5).Text("Sistema / Módulo").Bold().FontSize(8);
                                    h.Cell().Background("#F5F5F5").Padding(5).Text("Tipo").Bold().FontSize(8);
                                    h.Cell().Background("#F5F5F5").Padding(5).Text("Entorno").Bold().FontSize(8);
                                    h.Cell().Background("#F5F5F5").Padding(5).Text("Dirección / URL / Executable").Bold().FontSize(8);
                                });

                                var sut = project.SystemUnderTest;
                                
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(5).Text(sut.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(5).Text(sut.PlatformType?.Name ?? "Web").FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(5).Text(sut.Environment ?? "QA").FontSize(8);

                                string details = "-";
                                if (sut.PlatformType?.Code == "DESKTOP")
                                {
                                    details = $"Proceso: {sut.ProcessName ?? "N/A"}";
                                }
                                else if (!string.IsNullOrEmpty(sut.BaseUrl))
                                {
                                    details = sut.BaseUrl;
                                }

                                table.Cell().BorderBottom(0.5f).BorderColor(ColorBorder).Padding(5).Text(details).FontSize(8);
                                
                            });
                        }

                        // 4. CONCLUSIÓN DE ASEGURAMIENTO
                        col.Item().PaddingTop(25).Text("CONCLUSIÓN Y RECOMENDACIÓN DE LIBERACIÓN").FontSize(12).Bold().FontColor(ColorPrimary);
                        string conclusion = $"El proceso de certificación de calidad del proyecto {project.Name} (Versión {project.Version}) concluyó con una tasa de aprobación de casos de prueba del {compliance:N1}% y una cobertura de requerimientos funcionales del {reqCoverage:N1}%. ";
                        if (verdict == "APROBADO PARA PRODUCCIÓN")
                        {
                            conclusion += "El nivel de estabilidad de la aplicación cumple rigurosamente con los estándares y políticas de calidad institucionales. Se aconseja proceder con la puesta en producción.";
                        }
                        else if (verdict == "APROBADO CONDICIONADO")
                        {
                            conclusion += "Aunque el sistema es funcional, se recomienda su puesta en producción sujeta al seguimiento y corrección prioritaria del plan de acción para las observaciones menores reportadas.";
                        }
                        else
                        {
                            conclusion += "Debido al impacto de los fallos encontrados o la inestabilidad demostrada en los ciclos de prueba, no se recomienda la liberación hasta solventar los hallazgos críticos documentados.";
                        }
                        col.Item().PaddingTop(5).Text(conclusion).FontSize(9).Italic();

                        // 5. FIRMAS DE CONFORMIDAD
                        col.Item().PaddingTop(35).Row(row =>
                        {
                            row.RelativeItem().Column(sig =>
                            {
                                sig.Item().AlignCenter().Text("_________________________________").FontSize(9);
                                sig.Item().AlignCenter().Text("Representante QA / Calidad").FontSize(9).Bold();
                            });
                            row.RelativeItem().Column(sig =>
                            {
                                sig.Item().AlignCenter().Text("_________________________________").FontSize(9);
                                sig.Item().AlignCenter().Text("Product Owner / Cliente Final").FontSize(9).Bold();
                            });
                        });
                    });

                    page.Footer().AlignCenter().Text(t =>
                    {
                        t.Span("Certificado Resumen Ejecutivo QA. Página ");
                        t.CurrentPageNumber();
                    });
                });
            });

            using var ms = new MemoryStream();
            document.GeneratePdf(ms);
            return ms.ToArray();
        }
    }
}

