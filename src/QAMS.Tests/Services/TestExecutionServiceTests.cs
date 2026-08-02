#nullable enable
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.TestExecutions;
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
public class TestExecutionServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private ITestExecutionService GetService(IServiceScope scope)
        => scope.ServiceProvider.GetRequiredService<ITestExecutionService>();

    private async Task<(Guid testCaseId, Guid testerId, Guid stepId)> CreateTestCaseWithStepAsync(string suffix)
    {
        var user = await CreateTestUserAsync($"exec_user_{suffix}");
        var projectId = Guid.NewGuid();
        var testCaseId = Guid.NewGuid();
        var stepId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            var priority = await db.Set<TestCasePriority>().FirstOrDefaultAsync()
                ?? new TestCasePriority { Name = "Media", Code = $"MED_{suffix}", SortOrder = 1 };
            if (priority.Id == 0) db.Set<TestCasePriority>().Add(priority);

            var testSuiteId = Guid.NewGuid();

            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"Exec Project {suffix}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });

            db.Set<TestSuite>().Add(new TestSuite
            {
                Id = testSuiteId,
                Name = $"Exec Suite {suffix}",
                ProjectId = projectId,
                CreatedByUserId = user.Id,
                StatusId = 1
            });

            db.TestCases.Add(new TestCase
            {
                Id = testCaseId,
                ProjectId = projectId,
                TestSuiteId = testSuiteId,
                Title = $"TC Exec {suffix}",
                IsActive = true,
                CreatedByUserId = user.Id,
                PriorityId = priority.Id > 0 ? priority.Id : 1,
                TestSteps = [new TestStep { Id = stepId, Action = "Step 1", StepOrder = 1, CreatedByUserId = user.Id }]
            });
            await db.SaveChangesAsync();
        });

        return (testCaseId, user.Id, stepId);
    }

    [Fact(DisplayName = "CreateAsync_DebeInicializarEjecucionConStatusPendiente")]
    public async Task CreateAsync_ShouldInitializeExecutionWithPendingStatus()
    {
        // Arrange
        var (testCaseId, testerId, _) = await CreateTestCaseWithStepAsync("create");

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.CreateAsync(testerId, new CreateTestExecutionDto { TestCaseId = testCaseId });

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var pendingStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "PENDING");
            var exec = await db.TestExecutions
                .Include(e => e.StepResults)
                .FirstOrDefaultAsync(e => e.TestCaseId == testCaseId && e.TesterId == testerId);

            exec.Should().NotBeNull();
            exec!.StatusId.Should().Be(pendingStatus.Id);
            exec.StepResults.Should().HaveCount(1);
        });
    }

    [Fact(DisplayName = "CreateCompleteAsync_CuandoTodosPasaron_DebeSetStatusPasado")]
    public async Task CreateCompleteAsync_WhenAllPassed_ShouldSetPassedStatus()
    {
        // Arrange
        var (testCaseId, testerId, stepId) = await CreateTestCaseWithStepAsync("complete");

        int passedStepStatusId = 0;

        await ExecuteInScopeAsync(async db =>
        {
            var passedStepStatus = await db.Set<StepResultStatus>().FirstOrDefaultAsync(s => s.Code == "PASSED");
            if (passedStepStatus != null) passedStepStatusId = passedStepStatus.Id;
        });

        if (passedStepStatusId == 0)
            return; // Skip if catalog not available

        var dto = new CreateCompleteExecutionDto
        {
            TestCaseId = testCaseId,
            StepResults =
            [
                new() { TestStepId = stepId, StatusId = passedStepStatusId, ActualResult = "OK" }
            ]
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.CreateCompleteAsync(testerId, dto);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var passedExecStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "PASSED");
            var exec = await db.TestExecutions
                .OrderByDescending(e => e.ExecutionDate)
                .FirstOrDefaultAsync(e => e.TestCaseId == testCaseId && e.TesterId == testerId);

            exec.Should().NotBeNull();
            exec!.StatusId.Should().Be(passedExecStatus.Id);
            exec.CompletedAt.Should().NotBeNull();
        });
    }

    [Fact(DisplayName = "UpdateStepResultAsync_CuandoPendiente_DebeCambiarAEnProgreso")]
    public async Task UpdateStepResultAsync_WhenPending_ShouldChangeToInProgress()
    {
        // Arrange
        var (testCaseId, testerId, stepId) = await CreateTestCaseWithStepAsync("step_update");

        Guid execId = Guid.NewGuid();
        int passedStepStatusId = 0;

        await ExecuteInScopeAsync(async db =>
        {
            var pendingStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "PENDING");
            var passedStepStatus = await db.Set<StepResultStatus>().FirstAsync(s => s.Code == "PASSED");
            passedStepStatusId = passedStepStatus.Id;

            var exec = new TestExecution
            {
                Id = execId,
                TestCaseId = testCaseId,
                TesterId = testerId,
                StatusId = pendingStatus.Id,
                ExecutionDate = DateTime.UtcNow,
                StepResults = [new ExecutionStepResult { TestStepId = stepId, StatusId = passedStepStatus.Id }]
            };
            db.TestExecutions.Add(exec);
            await db.SaveChangesAsync();
        });

        var dto = new UpdateStepResultDto { TestStepId = stepId, StatusId = passedStepStatusId, ActualResult = "OK" };

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.UpdateStepResultAsync(execId, dto);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var inProgressStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "IN_PROGRESS");
            var exec = await db.TestExecutions.FindAsync(execId);
            exec!.StatusId.Should().Be(inProgressStatus.Id);
        });
    }

    [Fact(DisplayName = "GetByIdAsync_CuandoExiste_DebeRetornarEjecucion")]
    public async Task GetByIdAsync_WhenExists_ShouldReturnExecution()
    {
        // Arrange
        var (testCaseId, testerId, _) = await CreateTestCaseWithStepAsync("getbyid");

        await ExecuteInScopeAsync(async db =>
        {
            var pendingStatus = await db.Set<ExecutionStatus>().FirstAsync(s => s.Code == "PENDING");
            db.TestExecutions.Add(new TestExecution
            {
                Id = Guid.NewGuid(),
                TestCaseId = testCaseId,
                TesterId = testerId,
                StatusId = pendingStatus.Id,
                ExecutionDate = DateTime.UtcNow
            });
            await db.SaveChangesAsync();
        });

        Guid execId = Guid.Empty;
        await ExecuteInScopeAsync(async db =>
        {
            var exec = await db.TestExecutions.FirstAsync(e => e.TestCaseId == testCaseId);
            execId = exec.Id;
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetByIdAsync(execId);

        // Assert
        result.Should().NotBeNull();
    }
}


