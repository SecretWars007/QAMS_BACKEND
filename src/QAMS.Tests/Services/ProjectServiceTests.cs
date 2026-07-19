#nullable enable
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace QAMS.Tests.Services;

[Collection("Integration tests")]
public class ProjectServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private IProjectService GetService(IServiceScope scope)
        => scope.ServiceProvider.GetRequiredService<IProjectService>();

    private async Task<(Guid projectId, User owner)> CreateTestProjectAsync(string name)
    {
        var user = await CreateTestUserAsync($"proj_owner");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = name,
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });
            await db.SaveChangesAsync();
        });

        return (projectId, user);
    }

    [Fact(DisplayName = "GetByIdAsync_CuandoProyectoExiste_DebeRetornarDto")]
    public async Task GetByIdAsync_WhenProjectExists_ShouldReturnProjectDto()
    {
        // Arrange
        var uniqueName = $"Project GetById {Guid.NewGuid():N}";
        var (projectId, _) = await CreateTestProjectAsync(uniqueName);

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetByIdAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(projectId);
        result.Name.Should().Be(uniqueName);
    }

    [Fact(DisplayName = "GetByIdAsync_CuandoProyectoNoExiste_DebeThrowEntityNotFoundException")]
    public async Task GetByIdAsync_WhenProjectDoesNotExist_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var fakeId = Guid.NewGuid();

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => service.GetByIdAsync(fakeId));
    }

    [Fact(DisplayName = "CreateAsync_CuandoProyectoNombreDuplicado_DebeLanzarDomainException")]
    public async Task CreateAsync_WhenProjectNameAlreadyExists_ShouldThrowDomainException()
    {
        // Arrange
        var uniqueName = $"Duplicate Project {Guid.NewGuid():N}";
        await CreateTestProjectAsync(uniqueName);

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateProjectDto { Name = uniqueName, ProjectStatusId = 1, ProjectPriorityId = 1 };

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
    }

    [Fact(DisplayName = "CreateAsync_CuandoProyectoNuevo_DebeCrearYRetornarDto")]
    public async Task CreateAsync_WhenProjectIsNew_ShouldCreateAndReturnProjectDto()
    {
        // Arrange — necesitamos un usuario autenticado para CurrentUserService
        var testerUser = await CreateTestUserAsync("proj_tester_create", "Tester");
        var uniqueName = $"New Integration Project {Guid.NewGuid():N}";

        var dto = new CreateProjectDto
        {
            Name = uniqueName,
            Description = "Test",
            ProjectStatusId = 1,
            ProjectPriorityId = 1,
            TesterIds = [testerUser.Id]
        };

        // Autenticar como el tester (el CurrentUserService leerá el userId del HttpContext en el scope)
        Authenticate(testerUser.Id);

        // Act — usamos el HttpClient que ya tiene auth configurada
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(uniqueName);

        await ExecuteInScopeAsync(async db =>
        {
            var project = await db.Projects.FirstOrDefaultAsync(p => p.Name == uniqueName);
            project.Should().NotBeNull();
            project!.IsActive.Should().BeTrue();
        });
    }

    [Fact(DisplayName = "DeleteAsync_CuandoProyectoExiste_DebeDesactivarlo")]
    public async Task DeleteAsync_WhenProjectExists_ShouldDeactivate()
    {
        // Arrange
        var uniqueName = $"Project Delete {Guid.NewGuid():N}";
        var (projectId, _) = await CreateTestProjectAsync(uniqueName);

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.DeleteAsync(projectId);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var project = await db.Projects.FindAsync(projectId);
            project!.IsActive.Should().BeFalse();
        });
    }

    [Fact(DisplayName = "UpdateAsync_CuandoProyectoExiste_DebeActualizarNombre")]
    public async Task UpdateAsync_WhenProjectExists_ShouldUpdateAndReturnProjectDto()
    {
        // Arrange
        var originalName = $"Original Project {Guid.NewGuid():N}";
        var (projectId, _) = await CreateTestProjectAsync(originalName);

        var updatedName = $"Updated Project {Guid.NewGuid():N}";
        var dto = new CreateProjectDto { Name = updatedName, ProjectStatusId = 1, ProjectPriorityId = 1 };

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.UpdateAsync(projectId, dto);

        // Assert
        result.Name.Should().Be(updatedName);

        await ExecuteInScopeAsync(async db =>
        {
            var project = await db.Projects.FindAsync(projectId);
            project!.Name.Should().Be(updatedName);
        });
    }
}
