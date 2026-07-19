#nullable enable
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.Kanban;
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

[Collection("Integration tests")]
public class KanbanServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private IKanbanService GetService(IServiceScope scope)
        => scope.ServiceProvider.GetRequiredService<IKanbanService>();

    private async Task<(Guid projectId, Guid boardId)> CreateProjectWithBoardAsync(string suffix)
    {
        var projectId = Guid.NewGuid();
        var boardId = Guid.NewGuid();
        var user = await CreateTestUserAsync($"kanban_u_{suffix}");

        await ExecuteInScopeAsync(async db =>
        {
            var project = new Project
            {
                Id = projectId,
                Name = $"Kanban Project {suffix}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            };
            db.Projects.Add(project);

            var board = new KanbanBoard
            {
                Id = boardId,
                Name = $"Kanban Board {suffix}",
                ProjectId = projectId,
                Columns =
                [
                    new KanbanColumn { Id = Guid.NewGuid(), Name = "Por Hacer", OrderIndex = 0, BoardId = boardId },
                    new KanbanColumn { Id = Guid.NewGuid(), Name = "En Progreso", OrderIndex = 1, BoardId = boardId },
                    new KanbanColumn { Id = Guid.NewGuid(), Name = "Hecho", OrderIndex = 2, BoardId = boardId }
                ]
            };
            db.KanbanBoards.Add(board);
            await db.SaveChangesAsync();
        });

        return (projectId, boardId);
    }

    [Fact(DisplayName = "GetBoardAsync_CuandoExiste_DebeRetornarDto")]
    public async Task GetBoardAsync_WhenExists_ShouldReturnDto()
    {
        // Arrange
        var (_, boardId) = await CreateProjectWithBoardAsync("get");

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        var result = await service.GetBoardAsync(boardId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(boardId);
    }

    [Fact(DisplayName = "CreateBoardAsync_DebeCrearConColumnasDefecto")]
    public async Task CreateBoardAsync_ShouldCreateWithDefaultColumns()
    {
        // Arrange
        var user = await CreateTestUserAsync("kanban_board_create");
        var projectId = Guid.NewGuid();
        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"BoardCreateProject {Guid.NewGuid():N}",
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
        await service.CreateBoardAsync(projectId, "Mi Tablero");

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var board = await db.KanbanBoards
                .Include(b => b.Columns)
                .FirstOrDefaultAsync(b => b.ProjectId == projectId);

            board.Should().NotBeNull();
            board!.Columns.Should().HaveCountGreaterThanOrEqualTo(3);
        });
    }

    [Fact(DisplayName = "CreateTaskAsync_DebeAumentarOrderIndex")]
    public async Task CreateTaskAsync_ShouldIncreaseOrderIndex()
    {
        // Arrange
        var (_, boardId) = await CreateProjectWithBoardAsync("task_create");

        Guid columnId = Guid.Empty;
        int taskPriorityId = 0;

        await ExecuteInScopeAsync(async db =>
        {
            var board = await db.KanbanBoards.Include(b => b.Columns).FirstAsync(b => b.Id == boardId);
            columnId = board.Columns.First().Id;

            var priority = await db.Set<TaskPriority>().FirstOrDefaultAsync();
            if (priority == null)
            {
                priority = new TaskPriority { Name = "Media", Code = "MEDIUM", SortOrder = 1 };
                db.Set<TaskPriority>().Add(priority);
                await db.SaveChangesAsync();
            }
            taskPriorityId = priority.Id;

            // Add 2 existing tasks
            db.KanbanTasks.Add(new KanbanTask { KanbanColumnId = columnId, Title = "Task 0", OrderIndex = 0, PriorityId = taskPriorityId });
            db.KanbanTasks.Add(new KanbanTask { KanbanColumnId = columnId, Title = "Task 1", OrderIndex = 1, PriorityId = taskPriorityId });
            await db.SaveChangesAsync();
        });

        var dto = new CreateKanbanTaskDto
        {
            KanbanColumnId = columnId,
            Title = "New Task",
            PriorityId = taskPriorityId
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.CreateTaskAsync(dto);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var tasks = await db.KanbanTasks
                .Where(t => t.KanbanColumnId == columnId)
                .OrderBy(t => t.OrderIndex)
                .ToListAsync();

            tasks.Should().HaveCount(3);
            tasks.Last().OrderIndex.Should().Be(2);
            tasks.Last().Title.Should().Be("New Task");
        });
    }

    [Fact(DisplayName = "MoveTaskAsync_DebeReordenarColumnaDestino")]
    public async Task MoveTaskAsync_ShouldReorderDestinationColumn()
    {
        // Arrange
        var (_, boardId) = await CreateProjectWithBoardAsync("move_task");

        Guid taskId = Guid.NewGuid();
        Guid targetColumnId = Guid.Empty;
        int taskPriorityId = 0;

        await ExecuteInScopeAsync(async db =>
        {
            var board = await db.KanbanBoards.Include(b => b.Columns).FirstAsync(b => b.Id == boardId);
            var sourceColumn = board.Columns.First();
            targetColumnId = board.Columns.Skip(1).First().Id;

            var priority = await db.Set<TaskPriority>().FirstOrDefaultAsync();
            if (priority == null)
            {
                priority = new TaskPriority { Name = "Media", Code = "MEDIUM_MOVE", SortOrder = 1 };
                db.Set<TaskPriority>().Add(priority);
                await db.SaveChangesAsync();
            }
            taskPriorityId = priority.Id;

            db.KanbanTasks.Add(new KanbanTask
            {
                Id = taskId,
                KanbanColumnId = sourceColumn.Id,
                Title = "Task To Move",
                OrderIndex = 0,
                PriorityId = taskPriorityId
            });
            await db.SaveChangesAsync();
        });

        var dto = new MoveTaskDto { TargetColumnId = targetColumnId, NewOrderIndex = 0 };

        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        // Act
        await service.MoveTaskAsync(taskId, dto);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var task = await db.KanbanTasks.FindAsync(taskId);
            task!.KanbanColumnId.Should().Be(targetColumnId);
        });
    }
}
