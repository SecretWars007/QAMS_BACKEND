#nullable enable
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace QAMS.Tests.Services;

[Collection(SharedTestCollection.Name)]
public class DashboardServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private IDashboardService GetService(IServiceScope scope)
        => scope.ServiceProvider.GetRequiredService<IDashboardService>();

    [Fact(DisplayName = "GetSummaryAsync_DebeCalcularMetricasCorrectas")]
    public async Task GetSummaryAsync_ShouldCalculateCorrectMetrics()
    {
        // Arrange
        var user = await CreateTestUserAsync("dashboard_user");

        // Crear un proyecto activo con un TestCase
        Guid projectId = Guid.NewGuid();
        Guid testCaseId = Guid.NewGuid();
        int passedStatusId = 0;

        await ExecuteInScopeAsync(async db =>
        {
            // Obtener status PASSED real desde la BD
            var passedStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "PASSED");
            passedStatusId = passedStatus.Id;

            var testSuiteId = Guid.NewGuid();

            var project = new Project
            {
                Id = projectId,
                Name = $"Dashboard Test Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            };
            db.Projects.Add(project);

            db.Set<TestSuite>().Add(new TestSuite
            {
                Id = testSuiteId,
                Name = "Suite Dashboard",
                ProjectId = projectId,
                CreatedByUserId = user.Id,
                StatusId = 1
            });

            var testCase = new TestCase
            {
                Id = testCaseId,
                ProjectId = projectId,
                TestSuiteId = testSuiteId,
                Title = "TC Dashboard",
                IsActive = true,
                CreatedByUserId = user.Id,
                PriorityId = 1
            };
            db.TestCases.Add(testCase);

            var exec = new TestExecution
            {
                Id = Guid.NewGuid(),
                TestCaseId = testCaseId,
                TesterId = user.Id,
                StatusId = passedStatus.Id,
                ExecutionDate = DateTime.UtcNow
            };
            db.TestExecutions.Add(exec);

            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetSummaryAsync(user.Id);

        // Assert
        result.Should().NotBeNull();
        result.TotalProjects.Should().BeGreaterThanOrEqualTo(1);
        result.TotalTestCases.Should().BeGreaterThanOrEqualTo(1);
        result.PassedExecutions.Should().BeGreaterThanOrEqualTo(1);
    }

    [Fact(DisplayName = "GetProjectTimelineAsync_DebeRetornarEjecucionesPorProyecto")]
    public async Task GetProjectTimelineAsync_ShouldReturnExecutions()
    {
        // Arrange
        var user = await CreateTestUserAsync("timeline_user");
        Guid projectId = Guid.NewGuid();
        Guid testCaseId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            var passedStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "PASSED");

            var testSuiteId = Guid.NewGuid();

            var project = new Project
            {
                Id = projectId,
                Name = $"Timeline Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            };
            db.Projects.Add(project);

            db.Set<TestSuite>().Add(new TestSuite
            {
                Id = testSuiteId,
                Name = "Suite Timeline",
                ProjectId = projectId,
                CreatedByUserId = user.Id,
                StatusId = 1
            });

            var tc = new TestCase
            {
                Id = testCaseId,
                ProjectId = projectId,
                TestSuiteId = testSuiteId,
                Title = "TC Timeline",
                IsActive = true,
                CreatedByUserId = user.Id,
                PriorityId = 1
            };
            db.TestCases.Add(tc);

            db.TestExecutions.Add(new TestExecution
            {
                Id = Guid.NewGuid(),
                TestCaseId = testCaseId,
                TesterId = user.Id,
                StatusId = passedStatus.Id,
                ExecutionDate = DateTime.UtcNow
            });

            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetProjectTimelineAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCountGreaterThanOrEqualTo(1);
    }

    [Fact(DisplayName = "GetBurndownDataAsync_DebeRetornarDatosDeGrafica")]
    public async Task GetBurndownDataAsync_ShouldReturnBurndownPoints()
    {
        // Arrange
        var user = await CreateTestUserAsync("burndown_user");
        Guid projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            var testSuiteId = Guid.NewGuid();

            var project = new Project
            {
                Id = projectId,
                Name = $"Burndown Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(5),
                WorkHoursPerDay = 8,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            };
            db.Projects.Add(project);

            db.Set<TestSuite>().Add(new TestSuite
            {
                Id = testSuiteId,
                Name = "Suite Burndown",
                ProjectId = projectId,
                CreatedByUserId = user.Id,
                StatusId = 1
            });

            db.TestCases.Add(new TestCase
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                TestSuiteId = testSuiteId,
                Title = "TC Burndown",
                IsActive = true,
                EstimatedTimeHours = 10,
                CreatedByUserId = user.Id,
                PriorityId = 1
            });

            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetBurndownDataAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
    }
}


