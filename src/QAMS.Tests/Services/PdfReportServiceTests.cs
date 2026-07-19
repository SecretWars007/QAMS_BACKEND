#nullable enable
// PdfReportServiceTests - Tests sin Moq usando datos en memoria (domain objects reales)
// PdfReportService es un servicio de generación de PDFs con lógica de presentación pura.
// Se valida que el PDF generado no esté vacío con datos reales de dominio.
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.Reports;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace QAMS.Tests.Services;

[Collection("Integration tests")]
public class PdfReportServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private IReportService GetService(IServiceScope scope)
        => scope.ServiceProvider.GetRequiredService<IReportService>();

    [Fact(DisplayName = "GenerateProjectReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateProjectReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_report");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF Report Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GenerateProjectReportAsync(new ProjectReportFilterDto { ProjectId = projectId });

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = "GenerateProjectObservationsReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateProjectObservationsReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_obs");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF Observations Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GenerateProjectObservationsReportAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }
}
