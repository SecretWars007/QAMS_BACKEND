using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.TestExecutions;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.Services;

public class TestExecutionServiceTests
{
    private readonly Mock<ITestExecutionRepository> _mockExecRepo = new();
    private readonly Mock<ITestCaseRepository> _mockTestCaseRepo = new();
    private readonly Mock<IProjectRepository> _mockProjectRepo = new();
    private readonly Mock<IEvidenceRepository> _mockEvidenceRepo = new();
    private readonly Mock<ICatalogRepository<ExecutionStatus>> _mockExecStatusRepo = new();
    private readonly Mock<ICatalogRepository<StepResultStatus>> _mockStepStatusRepo = new();
    private readonly Mock<ICatalogRepository<EvidenceType>> _mockEvidenceTypeRepo = new();
    private readonly Mock<IObservationRepository> _mockObservationRepo = new();
    private readonly Mock<IFileStorageService> _mockFileStorage = new();
    private readonly Mock<IUnitOfWork> _mockUow = new();
    private readonly Mock<IMapper> _mockMapper = new();
    private readonly Mock<ILogger<TestExecutionService>> _mockLogger = new();

    private TestExecutionService CreateService() => new(
        _mockExecRepo.Object,
        _mockTestCaseRepo.Object,
        _mockProjectRepo.Object,
        _mockEvidenceRepo.Object,
        _mockExecStatusRepo.Object,
        _mockStepStatusRepo.Object,
        _mockEvidenceTypeRepo.Object,
        _mockObservationRepo.Object,
        _mockFileStorage.Object,
        _mockUow.Object,
        _mockMapper.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task CreateAsync_ShouldInitializeExecutionWithPendingStatus()
    {
        // Arrange
        var testerId = Guid.NewGuid();
        var testCaseId = Guid.NewGuid();
        var testCase = new TestCase 
        { 
            Id = testCaseId, 
            TestSteps = [new() { Id = Guid.NewGuid() }] 
        };
        
        var pendingStatus = new ExecutionStatus { Id = 1, Code = "PENDING" };
        var notExecutedStatus = new StepResultStatus { Id = 1, Code = "NOT_EXECUTED" };

        _mockTestCaseRepo.Setup(r => r.GetWithStepsAsync(testCaseId)).ReturnsAsync(testCase);
        _mockExecStatusRepo.Setup(r => r.GetByCodeAsync("PENDING")).ReturnsAsync(pendingStatus);
        _mockStepStatusRepo.Setup(r => r.GetByCodeAsync("NOT_EXECUTED")).ReturnsAsync(notExecutedStatus);
        _mockExecRepo.Setup(r => r.GetFullExecutionAsync(It.IsAny<Guid>())).ReturnsAsync(new TestExecution());

        var service = CreateService();

        // Act
        await service.CreateAsync(testerId, new CreateTestExecutionDto { TestCaseId = testCaseId });

        // Assert
        _mockExecRepo.Verify(r => r.AddAsync(It.Is<TestExecution>(te => 
            te.TestCaseId == testCaseId && 
            te.StatusId == pendingStatus.Id &&
            te.StepResults.Count == 1)), Times.Once);
        
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task CreateCompleteAsync_WhenAllPassed_ShouldSetPassedStatus()
    {
        // Arrange
        var testerId = Guid.NewGuid();
        var testCaseId = Guid.NewGuid();
        var stepId = Guid.NewGuid();
        var testCase = new TestCase 
        { 
            Id = testCaseId, 
            ProjectId = Guid.NewGuid(),
            TestSteps = [new() { Id = stepId }] 
        };
        
        var passedStepStatus = new StepResultStatus { Id = 2, Code = "PASSED" };
        var failedStepStatus = new StepResultStatus { Id = 3, Code = "FAILED" };
        var passedExecStatus = new ExecutionStatus { Id = 2, Code = "PASSED" };
        
        var dto = new CreateCompleteExecutionDto
        {
            TestCaseId = testCaseId,
            StepResults = 
            [ 
                new() { TestStepId = stepId, StatusId = passedStepStatus.Id } 
            ]
        };

        _mockTestCaseRepo.Setup(r => r.GetWithStepsAsync(testCaseId)).ReturnsAsync(testCase);
        _mockStepStatusRepo.Setup(r => r.GetByIdAsync(passedStepStatus.Id)).ReturnsAsync(passedStepStatus);
        _mockStepStatusRepo.Setup(r => r.GetByCodeAsync("PASSED")).ReturnsAsync(passedStepStatus);
        _mockStepStatusRepo.Setup(r => r.GetByCodeAsync("FAILED")).ReturnsAsync(failedStepStatus);
        _mockExecStatusRepo.Setup(r => r.GetByCodeAsync("PASSED")).ReturnsAsync(passedExecStatus);
        _mockExecRepo.Setup(r => r.GetFullExecutionAsync(It.IsAny<Guid>())).ReturnsAsync(new TestExecution());
        _mockProjectRepo.Setup(r => r.GetByIdTrackedAsync(It.IsAny<Guid>())).ReturnsAsync(new Project());
        _mockMapper.Setup(m => m.Map<TestExecutionDto>(It.IsAny<TestExecution>())).Returns(new TestExecutionDto());

        var service = CreateService();

        // Act
        await service.CreateCompleteAsync(testerId, dto);

        // Assert
        _mockExecRepo.Verify(r => r.AddAsync(It.Is<TestExecution>(te => 
            te.StatusId == passedExecStatus.Id && 
            te.CompletedAt != null)), Times.Once);
    }

    [Fact]
    public async Task UpdateStepResultAsync_WhenPending_ShouldChangeToInProgress()
    {
        // Arrange
        var execId = Guid.NewGuid();
        var stepId = Guid.NewGuid();
        var pendingStatus = new ExecutionStatus { Id = 1, Code = "PENDING" };
        var inProgressStatus = new ExecutionStatus { Id = 2, Code = "IN_PROGRESS" };
        var stepStatus = new StepResultStatus { Id = 2, Code = "PASSED" };
        
        var execution = new TestExecution 
        { 
            Id = execId, 
            StatusId = pendingStatus.Id,
            StepResults = [new() { TestStepId = stepId }]
        };

        _mockExecRepo.Setup(r => r.GetFullExecutionAsync(execId)).ReturnsAsync(execution);
        _mockStepStatusRepo.Setup(r => r.GetByIdAsync(stepStatus.Id)).ReturnsAsync(stepStatus);
        _mockExecStatusRepo.Setup(r => r.GetByCodeAsync("PENDING")).ReturnsAsync(pendingStatus);
        _mockExecStatusRepo.Setup(r => r.GetByCodeAsync("IN_PROGRESS")).ReturnsAsync(inProgressStatus);

        var service = CreateService();

        // Act
        await service.UpdateStepResultAsync(execId, new UpdateStepResultDto { TestStepId = stepId, StatusId = stepStatus.Id });

        // Assert
        execution.StatusId.Should().Be(inProgressStatus.Id);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UploadEvidenceAsync_ShouldSaveFileAndAddEvidenceEntity()
    {
        // Arrange
        var execId = Guid.NewGuid();
        var stream = new MemoryStream([1, 2, 3]);
        var evidenceType = new EvidenceType { Id = 1, Code = "IMAGE" };

        _mockExecRepo.Setup(r => r.GetByIdAsync(execId)).ReturnsAsync(new TestExecution { Id = execId });
        _mockEvidenceTypeRepo.Setup(r => r.GetByCodeAsync("IMAGE")).ReturnsAsync(evidenceType);
        _mockFileStorage.Setup(s => s.SaveFileAsync(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync("path/to/file.jpg");
        _mockMapper.Setup(m => m.Map<EvidenceDto>(It.IsAny<Evidence>())).Returns(new EvidenceDto());

        var service = CreateService();

        // Act
        await service.UploadEvidenceAsync(execId, stream, "test.jpg", "image/jpeg", "Desc");

        // Assert
        _mockEvidenceRepo.Verify(r => r.AddAsync(It.Is<Evidence>(e => 
            e.TestExecutionId == execId && 
            e.FileTypeId == evidenceType.Id && 
            e.FileName == "test.jpg")), Times.Once);
        
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
