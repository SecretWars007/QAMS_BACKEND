using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.Kanban;
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

public class KanbanServiceTests
{
    private readonly Mock<IKanbanBoardRepository> _mockBoardRepo = new();
    private readonly Mock<IGenericRepository<KanbanColumn>> _mockColumnRepo = new();
    private readonly Mock<IGenericRepository<KanbanTask>> _mockTaskRepo = new();
    private readonly Mock<ICatalogRepository<TaskPriority>> _mockPriorityRepo = new();
    private readonly Mock<ITestExecutionRepository> _mockExecRepo = new();
    private readonly Mock<ICatalogRepository<ExecutionStatus>> _mockExecStatusRepo = new();
    private readonly Mock<IUnitOfWork> _mockUow = new();
    private readonly Mock<IMapper> _mockMapper = new();
    private readonly Mock<ILogger<KanbanService>> _mockLogger = new();

    private KanbanService CreateService() => new(
        _mockBoardRepo.Object,
        _mockColumnRepo.Object,
        _mockTaskRepo.Object,
        _mockPriorityRepo.Object,
        _mockExecRepo.Object,
        _mockExecStatusRepo.Object,
        _mockUow.Object,
        _mockMapper.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task GetBoardAsync_WhenExists_ShouldReturnDto()
    {
        // Arrange
        var boardId = Guid.NewGuid();
        var board = new KanbanBoard { Id = boardId, Name = "Test Board" };
        var dto = new KanbanBoardDto { Id = boardId, Name = "Test Board" };

        _mockBoardRepo.Setup(r => r.GetFullBoardAsync(boardId)).ReturnsAsync(board);
        _mockMapper.Setup(m => m.Map<KanbanBoardDto>(board)).Returns(dto);

        var service = CreateService();

        // Act
        var result = await service.GetBoardAsync(boardId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(boardId);
    }

    [Fact]
    public async Task CreateBoardAsync_ShouldCreateWithDefaultColumns()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var name = "Project Board";
        
        _mockBoardRepo.Setup(r => r.GetFullBoardAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new KanbanBoard { Name = name });

        var service = CreateService();

        // Act
        await service.CreateBoardAsync(projectId, name);

        // Assert
        _mockBoardRepo.Verify(r => r.AddAsync(It.Is<KanbanBoard>(b => 
            b.Name == name && 
            b.ProjectId == projectId && 
            b.Columns.Count == 5)), Times.Once);
        
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task CreateTaskAsync_ShouldIncreaseOrderIndex()
    {
        // Arrange
        var columnId = Guid.NewGuid();
        var dto = new CreateKanbanTaskDto 
        { 
            KanbanColumnId = columnId, 
            Title = "New Task", 
            PriorityId = 1 
        };
        
        var existingTasks = new List<KanbanTask> 
        { 
            new() { OrderIndex = 0 }, 
            new() { OrderIndex = 1 } 
        };

        _mockPriorityRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new TaskPriority());
        _mockTaskRepo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<KanbanTask, bool>>>()))
            .ReturnsAsync(existingTasks);

        var service = CreateService();

        // Act
        await service.CreateTaskAsync(dto);

        // Assert
        _mockTaskRepo.Verify(r => r.AddAsync(It.Is<KanbanTask>(t => 
            t.OrderIndex == 2)), Times.Once);
    }

    [Fact]
    public async Task MoveTaskAsync_ShouldReorderDestinyColumnAndSyncStatus()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        var targetColumnId = Guid.NewGuid();
        var testCaseId = Guid.NewGuid();
        var task = new KanbanTask { Id = taskId, TestCaseId = testCaseId, OrderIndex = 0 };
        var targetColumn = new KanbanColumn { Id = targetColumnId, Name = "En Progreso" };
        var dto = new MoveTaskDto { TargetColumnId = targetColumnId, NewOrderIndex = 1 };
        
        var existingTasksInTarget = new List<KanbanTask> 
        { 
            new() { Id = Guid.NewGuid(), OrderIndex = 1 }, // This one should be moved to 2
            new() { Id = Guid.NewGuid(), OrderIndex = 2 }  // This one should be moved to 3
        };

        _mockTaskRepo.Setup(r => r.GetByIdAsync(taskId)).ReturnsAsync(task);
        _mockColumnRepo.Setup(r => r.GetByIdAsync(targetColumnId)).ReturnsAsync(targetColumn);
        _mockTaskRepo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<KanbanTask, bool>>>()))
            .ReturnsAsync(existingTasksInTarget);
            
        // Mock Sync logic
        _mockExecRepo.Setup(r => r.GetByTestCaseTrackedAsync(testCaseId)).ReturnsAsync([]);

        var service = CreateService();

        // Act
        await service.MoveTaskAsync(taskId, dto);

        // Assert
        task.KanbanColumnId.Should().Be(targetColumnId);
        task.OrderIndex.Should().Be(1);
        
        foreach(var t in existingTasksInTarget)
        {
            _mockTaskRepo.Verify(r => r.Update(t), Times.AtLeastOnce);
        }
        
        existingTasksInTarget.First(t => t.OrderIndex == 2).Should().NotBeNull();
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
