#nullable enable
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace QAMS.Tests.Services;

[Collection(SharedTestCollection.Name)]
public class TestCaseServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private ITestCaseService GetService(IServiceScope scope)
        => scope.ServiceProvider.GetRequiredService<ITestCaseService>();

    private async Task<(Guid projectId, Guid testCaseId, User owner)> CreateTestCaseAsync(string suffix)
    {
        var user = await CreateTestUserAsync($"tc_owner_{suffix}");
        var projectId = Guid.NewGuid();
        var testCaseId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            var priority = await db.Set<TestCasePriority>().FirstOrDefaultAsync();
            if (priority == null)
            {
                priority = new TestCasePriority { Name = "Media", Code = "MEDIUM", SortOrder = 1 };
                db.Set<TestCasePriority>().Add(priority);
            }

            var testSuiteId = Guid.NewGuid();

            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"TC Project {suffix}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });

            db.Set<TestSuite>().Add(new TestSuite
            {
                Id = testSuiteId,
                Name = $"Suite {suffix}",
                ProjectId = projectId,
                CreatedByUserId = user.Id,
                StatusId = 1
            });

            db.TestCases.Add(new TestCase
            {
                Id = testCaseId,
                ProjectId = projectId,
                TestSuiteId = testSuiteId,
                Title = $"Test Case {suffix}",
                IsActive = true,
                CreatedByUserId = user.Id,
                PriorityId = priority.Id,
                TestSteps =
                [
                    new TestStep { Id = Guid.NewGuid(), Action = "Step 1", StepOrder = 1, CreatedByUserId = user.Id }
                ]
            });
            await db.SaveChangesAsync();
        });

        return (projectId, testCaseId, user);
    }

    [Fact(DisplayName = "GetByIdAsync_CuandoExiste_DebeRetornarDto")]
    public async Task GetByIdAsync_WhenExists_ShouldReturnDto()
    {
        // Arrange
        var (_, testCaseId, _) = await CreateTestCaseAsync("getbyid");

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetByIdAsync(testCaseId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(testCaseId);
    }

    [Fact(DisplayName = "UpdateAsync_DebeActualizarPasos")]
    public async Task UpdateAsync_ShouldSyncSteps()
    {
        // Arrange: crear usuario con rol Administrator (tiene todos los permisos seeded)
        var adminRoleId = new Guid("11111111-1111-1111-1111-111111111111");
        var user = await CreateTestUserAsync("tc_update_admin");

        // Asignar rol Administrator al usuario directamente en la BD
        await ExecuteInScopeAsync(async db =>
        {
            db.UserRoles.Add(new QAMS.Domain.Entities.UserRole
            {
                UserId = user.Id,
                RoleId = adminRoleId,
                AssignedAt = DateTime.UtcNow
            });
            await db.SaveChangesAsync();
        });

        var (_, testCaseId, _) = await CreateTestCaseAsync("update");

        // Autenticar con el usuario Admin para que CurrentUserService devuelva un UserId vÃ¡lido
        Authenticate(user.Id);

        var dto = new CreateTestCaseDto
        {
            Title = "Updated Test Case Title",
            ExpectedResult = "Se actualiza correctamente",
            PriorityId = 1,
            Steps =
            [
                new() { Action = "Updated Step 1", StepOrder = 1, ExpectedResult = "Paso 1 pasa" },
                new() { Action = "New Step 2", StepOrder = 2, ExpectedResult = "Paso 2 pasa" }
            ]
        };

        // Act: llamar al endpoint HTTP PUT en lugar del servicio directamente
        var response = await Client.PutAsJsonAsync($"/api/testcases/{testCaseId}", dto);

        // Assert HTTP
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK,
            $"El endpoint debe retornar 200 OK. Respuesta: {await response.Content.ReadAsStringAsync()}");

        // Assert DB State
        // TestCaseService implementa versionado: al actualizar, marca la versiÃ³n anterior como obsoleta
        // y crea una nueva versiÃ³n con un nuevo ID. Por lo tanto buscamos la versiÃ³n mÃ¡s reciente.
        await ExecuteInScopeAsync(async db =>
        {
            var oldTc = await db.TestCases.FirstOrDefaultAsync(t => t.Id == testCaseId);
            oldTc!.IsLatestVersion.Should().BeFalse("la versiÃ³n anterior debe quedar marcada como obsoleta");

            var latestTc = await db.TestCases
                .Include(t => t.TestSteps)
                .FirstOrDefaultAsync(t => t.ProjectId == oldTc.ProjectId && t.IsLatestVersion && t.Title == "Updated Test Case Title");

            latestTc.Should().NotBeNull("debe existir la nueva versiÃ³n con el tÃ­tulo actualizado");
            latestTc!.Title.Should().Be("Updated Test Case Title");
            latestTc.TestSteps.Should().HaveCount(2);
        });
    }

    [Fact(DisplayName = "DeleteAsync_DebeDesactivarTestCase")]
    public async Task DeleteAsync_ShouldDeactivate()
    {
        // Arrange
        var (_, testCaseId, _) = await CreateTestCaseAsync("delete");

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.DeleteAsync(testCaseId);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var tc = await db.TestCases.IgnoreQueryFilters().FirstOrDefaultAsync(t => t.Id == testCaseId);
            tc.Should().NotBeNull();
            tc!.IsActive.Should().BeFalse();
            tc.IsDeleted.Should().BeTrue();
        });
    }

    [Fact(DisplayName = "GetByProjectAsync_DebeRetornarSoloTestCasesDelProyecto")]
    public async Task GetByProjectAsync_ShouldReturnOnlyProjectTestCases()
    {
        // Arrange
        var (projectId, testCaseId, _) = await CreateTestCaseAsync("getbyproject");

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetByProjectIdAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().Contain(tc => tc.Id == testCaseId);
    }
}


