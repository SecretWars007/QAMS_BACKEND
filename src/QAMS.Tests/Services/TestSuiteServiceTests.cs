#nullable enable
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.TestSuites;
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
public class TestSuiteServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private static ITestSuiteService GetService(IServiceScope scope)
    {
        return scope.ServiceProvider.GetRequiredService<ITestSuiteService>();
    }

    [Fact(DisplayName = "GetByIdAsync_CuandoExiste_DebeRetornarDto")]
    public async Task GetByIdAsync_WhenExists_ReturnsDto()
    {
        // Arrange
        var user = await CreateTestUserAsync("suite_user");
        var projectId = Guid.NewGuid();
        var suiteId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"Suite Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });

            db.TestSuites.Add(new TestSuite
            {
                Id = suiteId,
                Name = "My Test Suite",
                ProjectId = projectId,
                StatusId = 1,
                CreatedByUserId = user.Id
            });

            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetByIdAsync(suiteId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(suiteId);
        result.Name.Should().Be("My Test Suite");
    }

    [Fact(DisplayName = "GetByIdAsync_CuandoNoExiste_DebeRetornarNull")]
    public async Task GetByIdAsync_WhenNotExists_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var fakeId = Guid.NewGuid();

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act & Assert — el servicio lanza EntityNotFoundException cuando no existe
        await Assert.ThrowsAsync<EntityNotFoundException>(() => service.GetByIdAsync(fakeId));
    }

    [Fact(DisplayName = "CreateAsync_DebeCrearTestSuite")]
    public async Task CreateAsync_ShouldCreateTestSuite()
    {
        // Arrange
        var user = await CreateTestUserAsync("suite_create_user");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"Suite Create Project {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });
            await db.SaveChangesAsync();
        });

        var dto = new CreateTestSuiteDto
        {
            Name = $"New Suite {Guid.NewGuid():N}",
            ProjectId = projectId
        };

        // Authenticate
        Authenticate(user.Id);

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(dto.Name);

        await ExecuteInScopeAsync(async db =>
        {
            var suite = await db.TestSuites.FirstOrDefaultAsync(s => s.Name == dto.Name);
            suite.Should().NotBeNull();
        });
    }
}
