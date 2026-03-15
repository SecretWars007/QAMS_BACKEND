using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.Services;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepo = new();
    private readonly Mock<IUserRepository> _mockUserRepo = new();
    private readonly Mock<ICurrentUserService> _mockCurrentUserService = new();
    private readonly Mock<IGenericRepository<ProjectDevolution>> _mockDevolutionRepo = new();
    private readonly Mock<IKanbanService> _mockKanbanService = new();
    private readonly Mock<ITestExecutionRepository> _mockExecRepo = new();
    private readonly Mock<IObservationRepository> _mockObservationRepo = new();
    private readonly Mock<IUnitOfWork> _mockUow = new();
    private readonly Mock<IMapper> _mockMapper = new();
    private readonly Mock<ILogger<ProjectService>> _mockLogger = new();

    private ProjectService CreateService() => new ProjectService(
        _mockProjectRepo.Object,
        _mockUserRepo.Object,
        _mockCurrentUserService.Object,
        _mockKanbanService.Object,
        _mockDevolutionRepo.Object,
        _mockExecRepo.Object,
        _mockObservationRepo.Object,
        _mockUow.Object,
        _mockMapper.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task GetByIdAsync_WhenProjectExists_ShouldReturnProjectDto()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var project = new Project { Id = projectId, Name = "Test Project" };
        var projectDto = new ProjectDto { Id = projectId, Name = "Test Project" };

        _mockProjectRepo.Setup(r => r.GetWithDetailsAsync(projectId)).ReturnsAsync(project);
        _mockMapper.Setup(m => m.Map<ProjectDto>(project)).Returns(projectDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(projectId);
        _mockProjectRepo.Verify(r => r.GetWithDetailsAsync(projectId), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WhenProjectDoesNotExist_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        _mockProjectRepo.Setup(r => r.GetWithDetailsAsync(projectId)).ReturnsAsync((Project?)null);

        var service = CreateService();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => service.GetByIdAsync(projectId));
    }

    [Fact]
    public async Task CreateAsync_WhenProjectNameAlreadyExists_ShouldThrowDomainException()
    {
        // Arrange
        var dto = new CreateProjectDto { Name = "Existing Project" };
        _mockProjectRepo.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Project, bool>>>())).ReturnsAsync(true);

        var service = CreateService();

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
    }

    [Fact]
    public async Task CreateAsync_WhenProjectIsNew_ShouldCreateAndReturnProjectDto()
    {
        // Arrange
        var dto = new CreateProjectDto 
        { 
            Name = "New Project", 
            Description = "Test Description",
            TesterIds = new List<Guid> { Guid.NewGuid() }
        };
        
        var tester = new User { Id = dto.TesterIds[0], FullName = "John Tester" };
        tester.UserRoles.Add(new UserRole { UserId = tester.Id, RoleId = QAMS.Domain.Constants.SystemRoles.TesterRoleId });

        _mockProjectRepo.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Project, bool>>>())).ReturnsAsync(false);
        _mockUserRepo.Setup(r => r.GetByIdsWithRolesAsync(It.IsAny<List<Guid>>())).ReturnsAsync(new List<User> { tester });
        _mockCurrentUserService.Setup(s => s.UserId).Returns(Guid.NewGuid());
        _mockMapper.Setup(m => m.Map<ProjectDto>(It.IsAny<Project>())).Returns(new ProjectDto { Name = dto.Name });

        var service = CreateService();

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(dto.Name);
        _mockProjectRepo.Verify(r => r.AddAsync(It.IsAny<Project>()), Times.Once);
        _mockKanbanService.Verify(s => s.CreateBoardAsync(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WhenTesterDoesNotHaveTesterRole_ShouldThrowDomainException()
    {
        // Arrange
        var testerId = Guid.NewGuid();
        var dto = new CreateProjectDto 
        { 
            Name = "New Project", 
            TesterIds = new List<Guid> { testerId }
        };
        
        var user = new User { Id = testerId, FullName = "Not A Tester" };
        // No Tester role added

        _mockProjectRepo.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Project, bool>>>())).ReturnsAsync(false);
        _mockUserRepo.Setup(r => r.GetByIdsWithRolesAsync(It.IsAny<List<Guid>>())).ReturnsAsync(new List<User> { user });

        var service = CreateService();

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
        ex.Message.Should().Contain("no tiene el rol de Tester");
    }

    [Fact]
    public async Task RegisterDevolutionAsync_WhenProjectExists_ShouldRegisterAndIncrementCounter()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var project = new Project { Id = projectId, DevolucionesCounter = 0 };
        var dto = new RegisterDevolutionDto { Notes = "Devolution notes" };

        _mockProjectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
        _mockExecRepo.Setup(r => r.GetByProjectAsync(projectId)).ReturnsAsync(new List<TestExecution>());
        _mockObservationRepo.Setup(r => r.CountAsync(It.IsAny<Expression<Func<ExecutionStepObservation, bool>>>())).ReturnsAsync(0);
        _mockMapper.Setup(m => m.Map<ProjectDevolutionDto>(It.IsAny<ProjectDevolution>())).Returns(new ProjectDevolutionDto());

        var service = CreateService();

        // Act
        await service.RegisterDevolutionAsync(projectId, userId, dto);

        // Assert
        project.DevolucionesCounter.Should().Be(1);
        project.ProjectStatusId.Should().Be(5); // DEVOLUCION status
        _mockDevolutionRepo.Verify(r => r.AddAsync(It.IsAny<ProjectDevolution>()), Times.Once);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_WhenProjectExists_ShouldUpdateAndReturnProjectDto()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var project = new Project { Id = projectId, Name = "Old Name" };
        var dto = new CreateProjectDto { Name = "New Name" };

        _mockProjectRepo.Setup(r => r.GetWithDetailsAsync(projectId)).ReturnsAsync(project);
        _mockMapper.Setup(m => m.Map<ProjectDto>(It.IsAny<Project>())).Returns(new ProjectDto { Name = dto.Name });

        var service = CreateService();

        // Act
        var result = await service.UpdateAsync(projectId, dto);

        // Assert
        project.Name.Should().Be(dto.Name);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_WhenProjectExists_ShouldDeactivate()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var project = new Project { Id = projectId, IsActive = true };

        _mockProjectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);

        var service = CreateService();

        // Act
        await service.DeleteAsync(projectId);

        // Assert
        project.IsActive.Should().BeFalse();
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
