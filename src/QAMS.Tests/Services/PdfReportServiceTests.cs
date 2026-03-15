using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.Reports;
using QAMS.Application.Interfaces;
using QAMS.Infrastructure.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.Services;

public class PdfReportServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepo = new();
    private readonly Mock<ITestExecutionRepository> _mockExecRepo = new();
    private readonly Mock<IObservationRepository> _mockObservationRepo = new();
    private readonly Mock<IEvidenceRepository> _mockEvidenceRepo = new();
    private readonly Mock<ILogger<PdfReportService>> _mockLogger = new();

    private PdfReportService CreateService() => new PdfReportService(
        _mockProjectRepo.Object,
        _mockExecRepo.Object,
        _mockObservationRepo.Object,
        _mockEvidenceRepo.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task GenerateProjectReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var project = new Project { Id = projectId, Name = "Test Project" };
        
        _mockProjectRepo.Setup(r => r.FindWithDetailsAsync(It.IsAny<Expression<Func<Project, bool>>>()))
            .ReturnsAsync(new List<Project> { project });
        _mockExecRepo.Setup(r => r.GetByProjectAsync(projectId))
            .ReturnsAsync(new List<TestExecution>());

        var service = CreateService();

        // Act
        var result = await service.GenerateProjectReportAsync(new ProjectReportFilterDto { ProjectId = projectId });

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GenerateProjectObservationsReportAsync_ShouldReturnNonEmptyByteArray()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var project = new Project { Id = projectId, Name = "Test Project" };
        
        _mockProjectRepo.Setup(r => r.FindWithDetailsAsync(It.IsAny<Expression<Func<Project, bool>>>()))
            .ReturnsAsync(new List<Project> { project });
        _mockExecRepo.Setup(r => r.GetByProjectAsync(projectId))
            .ReturnsAsync(new List<TestExecution>());
        _mockObservationRepo.Setup(r => r.GetByProjectAsync(It.IsAny<List<Guid>>()))
            .ReturnsAsync(new List<ExecutionStepObservation>());
        _mockEvidenceRepo.Setup(r => r.GetByStepResultsAsync(It.IsAny<List<Guid>>()))
            .ReturnsAsync(new List<Evidence>());

        var service = CreateService();

        // Act
        var result = await service.GenerateProjectObservationsReportAsync(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
    }
}
