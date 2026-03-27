using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.Services;

public class TestCaseServiceTests
{
    private readonly Mock<ITestCaseRepository> _mockTestCaseRepo = new();
    private readonly Mock<ICatalogRepository<TestCasePriority>> _mockPriorityRepo = new();
    private readonly Mock<ICurrentUserService> _mockCurrentUserService = new();
    private readonly Mock<IKanbanService> _mockKanbanService = new();
    private readonly Mock<ITestExecutionService> _mockExecService = new();
    private readonly Mock<IKanbanBoardRepository> _mockKanbanBoardRepo = new();
    private readonly Mock<IUnitOfWork> _mockUow = new();
    private readonly Mock<IMapper> _mockMapper = new();
    private readonly Mock<ILogger<TestCaseService>> _mockLogger = new();

    private TestCaseService CreateService() => new(
        _mockTestCaseRepo.Object,
        _mockPriorityRepo.Object,
        _mockCurrentUserService.Object,
        _mockKanbanService.Object,
        _mockExecService.Object,
        _mockKanbanBoardRepo.Object,
        _mockUow.Object,
        _mockMapper.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task GetByIdAsync_WhenExists_ShouldReturnDto()
    {
        // Arrange
        var id = Guid.NewGuid();
        var testCase = new TestCase { Id = id, Title = "Test Case" };
        var dto = new TestCaseDto { Id = id, Title = "Test Case" };

        _mockTestCaseRepo.Setup(r => r.GetWithStepsAsync(id)).ReturnsAsync(testCase);
        _mockMapper.Setup(m => m.Map<TestCaseDto>(testCase)).Returns(dto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(id);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddTestCaseAndKanbanTaskAndExecution()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var currentUserId = Guid.NewGuid();
        var dto = new CreateTestCaseDto 
        { 
            ProjectId = projectId, 
            Title = "New Case", 
            PriorityId = 1,
            Steps = [new() { Action = "Action", StepOrder = 1 }],
            CertifierUserIds = [Guid.NewGuid()]
        };

        _mockPriorityRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new TestCasePriority());
        _mockCurrentUserService.Setup(s => s.UserId).Returns(currentUserId);
        
        // Mock Kanban Logic
        var boardId = Guid.NewGuid();
        var boards = new List<KanbanBoard> { new() { Id = boardId } };
        var fullBoard = new KanbanBoard { Id = boardId, Columns = [new() { Id = Guid.NewGuid(), Name = "Por Hacer" }] };
        
        _mockKanbanBoardRepo.Setup(r => r.GetByProjectAsync(projectId)).ReturnsAsync(boards);
        _mockKanbanBoardRepo.Setup(r => r.GetFullBoardAsync(boardId)).ReturnsAsync(fullBoard);
        
        _mockTestCaseRepo.Setup(r => r.GetWithStepsAsync(It.IsAny<Guid>())).ReturnsAsync(new TestCase());

        var service = CreateService();

        // Act
        await service.CreateAsync(dto);

        // Assert
        _mockTestCaseRepo.Verify(r => r.AddAsync(It.Is<TestCase>(tc => 
            tc.Title == dto.Title && 
            tc.TestSteps.Count == 1 &&
            tc.Certifiers.Count == 1)), Times.Once);
        
        _mockKanbanService.Verify(s => s.CreateTaskAsync(It.IsAny<QAMS.Application.DTOs.Kanban.CreateKanbanTaskDto>()), Times.Once);
        _mockExecService.Verify(s => s.CreateAsync(It.IsAny<Guid>(), It.IsAny<QAMS.Application.DTOs.TestExecutions.CreateTestExecutionDto>()), Times.Once);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldSyncStepsAndCertifiers()
    {
        // Arrange
        var id = Guid.NewGuid();
        var existingStepId = Guid.NewGuid();
        var testCase = new TestCase 
        { 
            Id = id, 
            TestSteps = [new() { Id = existingStepId, StepOrder = 1, Action = "Old Action" }],
            Certifiers = [new() { UserId = Guid.NewGuid() }]
        };
        
        var dto = new CreateTestCaseDto 
        { 
            Title = "Updated Title",
            PriorityId = 1,
            Steps = 
            [ 
                new() { Action = "Updated Action", StepOrder = 1 }, // Update existing
                new() { Action = "New Action", StepOrder = 2 }     // Add new
            ],
            CertifierUserIds = [Guid.NewGuid()] // One new certifier (total 1, removes old)
        };

        _mockTestCaseRepo.Setup(r => r.GetWithStepsAsync(id)).ReturnsAsync(testCase);
        _mockPriorityRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new TestCasePriority());
        _mockTestCaseRepo.Setup(r => r.GetWithStepsAsync(id)).ReturnsAsync(testCase);

        var service = CreateService();

        // Act
        await service.UpdateAsync(id, dto);

        // Assert
        testCase.Title.Should().Be(dto.Title);
        testCase.TestSteps.Count.Should().Be(2);
        testCase.TestSteps.First(s => s.StepOrder == 1).Action.Should().Be("Updated Action");
        testCase.Certifiers.Count.Should().Be(1);
        testCase.Certifiers.First().UserId.Should().Be(dto.CertifierUserIds[0]);
        
        _mockTestCaseRepo.Verify(r => r.Update(testCase), Times.Once);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeactivate()
    {
        // Arrange
        var id = Guid.NewGuid();
        var testCase = new TestCase { Id = id, IsActive = true };

        _mockTestCaseRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(testCase);

        var service = CreateService();

        // Act
        await service.DeleteAsync(id);

        // Assert
        testCase.IsActive.Should().BeFalse();
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
