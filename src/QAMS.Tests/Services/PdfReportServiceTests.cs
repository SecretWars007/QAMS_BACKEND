#nullable enable
// PdfReportServiceTests - Tests sin Moq usando datos en memoria (domain objects reales)
// PdfReportService es un servicio de generaciÃ³n de PDFs con lÃ³gica de presentaciÃ³n pura.
// Se valida que el PDF generado no estÃ© vacÃ­o con datos reales de dominio.
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

[Collection(SharedTestCollection.Name)]
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

    [Fact(DisplayName = "GenerateBurndownReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateBurndownReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_burn");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF Burndown Project {Guid.NewGuid():N}",
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
        var result = await service.GenerateBurndownReportAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = "GenerateFinalComplianceReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateFinalComplianceReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_comp");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF Compliance Project {Guid.NewGuid():N}",
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
        var result = await service.GenerateFinalComplianceReportAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = "GenerateExecutiveSummaryReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateExecutiveSummaryReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_exec");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF ExecSummary Project {Guid.NewGuid():N}",
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
        var result = await service.GenerateExecutiveSummaryReportAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = "GenerateFullCertificationReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateFullCertificationReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_cert");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF FullCert Project {Guid.NewGuid():N}",
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
        var result = await service.GenerateFullCertificationReportAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = "GenerateTestSummaryReportAsync_DebeRetornarByteArrayNoVacio")]
    public async Task GenerateTestSummaryReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var user = await CreateTestUserAsync("pdf_user_ts");
        var projectId = Guid.NewGuid();
        var testPlanId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"PDF TestPlan Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });
            db.TestPlans.Add(new TestPlan
            {
                Id = testPlanId,
                ProjectId = projectId,
                Name = "Test Plan Summary Report Test",
                Objectives = "Verify report generation",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                StatusId = 1,
                CreatedByUserId = user.Id
            });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GenerateTestSummaryReportAsync(testPlanId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }
}


