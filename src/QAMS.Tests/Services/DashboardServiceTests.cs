using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.Services;

public class DashboardServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepo = new();
    private readonly Mock<ITestCaseRepository> _mockTestCaseRepo = new();
    private readonly Mock<ITestExecutionRepository> _mockExecRepo = new();
    private readonly Mock<IKanbanBoardRepository> _mockBoardRepo = new();
    private readonly Mock<ICatalogRepository<ExecutionStatus>> _mockStatusRepo = new();
    private readonly Mock<ILogger<DashboardService>> _mockLogger = new();

    private DashboardService CreateService() => new DashboardService(
        _mockProjectRepo.Object,
        _mockTestCaseRepo.Object,
        _mockExecRepo.Object,
        _mockBoardRepo.Object,
        _mockStatusRepo.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task GetSummaryAsync_ShouldCalculateCorrectMetrics()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var testCaseId = Guid.NewGuid();
        
        var project = new Project { Id = projectId, IsActive = true };
        var testCase = new TestCase { Id = testCaseId, ProjectId = projectId };
        project.TestCases.Add(testCase);
        
        var executions = new List<TestExecution> 
        { 
            new TestExecution { TestCaseId = testCaseId, StatusId = 3, Status = new ExecutionStatus { Code = "PASSED", Name = "Aprobado" } } 
        };

        _mockProjectRepo.Setup(r => r.FindWithDetailsAsync(It.IsAny<Expression<Func<Project, bool>>>()))
            .ReturnsAsync(new List<Project> { project });
        
        _mockExecRepo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TestExecution, bool>>>()))
            .ReturnsAsync(executions);
        
        _mockStatusRepo.Setup(r => r.GetAllActiveAsync())
            .ReturnsAsync(new List<ExecutionStatus> 
            { 
                new ExecutionStatus { Id = 3, Code = "PASSED", Name = "Aprobado" },
                new ExecutionStatus { Id = 4, Code = "FAILED", Name = "Fallido" }
            });

        var service = CreateService();

        // Act
        var result = await service.GetSummaryAsync(userId);

        // Assert
        result.TotalProjects.Should().Be(1);
        result.TotalTestCases.Should().Be(1);
        result.PassedExecutions.Should().Be(1);
        result.PassRate.Should().Be(100);
        result.ExecutionsByStatus.Should().HaveCount(1);
        result.ExecutionsByStatus.First().StatusCode.Should().Be("PASSED");
    }

    [Fact]
    public async Task GetProjectTimelineAsync_ShouldApplyCorrectColors()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var execs = new List<TestExecution>
        {
            new TestExecution 
            { 
                Id = Guid.NewGuid(), 
                ExecutionDate = DateTime.Now, 
                StatusId = 3, 
                Status = new ExecutionStatus { Code = "PASSED" },
                TestCase = new TestCase { Title = "T1" }
            },
            new TestExecution 
            { 
                Id = Guid.NewGuid(), 
                ExecutionDate = DateTime.Now.AddHours(1), 
                StatusId = 4, 
                Status = new ExecutionStatus { Code = "FAILED" },
                TestCase = new TestCase { Title = "T2" }
            }
        };

        _mockProjectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(new Project { Id = projectId });
        _mockExecRepo.Setup(r => r.GetByProjectAsync(projectId)).ReturnsAsync(execs);

        var service = CreateService();

        // Act
        var result = await service.GetProjectTimelineAsync(projectId);

        // Assert
        result.Should().HaveCount(2);
        result.First(e => e.TestCaseTitle == "T1").StatusColor.Should().Be("#4CAF50"); // Green for Passed
        result.First(e => e.TestCaseTitle == "T2").StatusColor.Should().Be("#F44336"); // Red for Failed
    }

    [Fact]
    public async Task GetBurndownDataAsync_ShouldCalculateIdealAndActualHours()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var monday = DateTime.Now.Date;
        while (monday.DayOfWeek != DayOfWeek.Monday) monday = monday.AddDays(1);
        
        var project = new Project 
        { 
            Id = projectId, 
            StartDate = monday, 
            EndDate = monday.AddDays(10),
            WorkHoursPerDay = 8
        };
        
        var tc1 = new TestCase { Id = Guid.NewGuid(), EstimatedTimeHours = 10 };
        project.TestCases.Add(tc1);

        var execs = new List<TestExecution>
        {
            new TestExecution { TestCaseId = tc1.Id, ExecutionDate = monday, StatusId = 3, Status = new ExecutionStatus { Code = "PASSED" }, TestCase = tc1 }
        };

        _mockProjectRepo.Setup(r => r.FindWithDetailsAsync(It.IsAny<Expression<Func<Project, bool>>>()))
            .ReturnsAsync(new List<Project> { project });
        _mockExecRepo.Setup(r => r.GetByProjectAsync(projectId)).ReturnsAsync(execs);

        var service = CreateService();

        // Act
        var result = await service.GetBurndownDataAsync(projectId);

        // Assert
        result.Should().NotBeEmpty();
        var firstPoint = result.First();
        firstPoint.IdealHours.Should().Be(72); // 9 working days * 8 hours
        firstPoint.ActualHours.Should().Be(72);
        
        if (result.Count > 1)
        {
            result[1].ActualHours.Should().Be(62); // 72 - 10 = 62
        }
    }
}
