using Moq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.Services;
using QAMS.Application.Interfaces;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;
using QAMS.Domain.Entities;
using Xunit;
using System;
using System.Threading.Tasks;

namespace QAMS.Tests.Services
{
    public class TestSuiteServiceTests
    {
        private readonly Mock<ITestSuiteRepository> _testSuiteRepoMock;
        private readonly Mock<IProjectRepository> _projectRepoMock;
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<TestSuiteService>> _loggerMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly TestSuiteService _service;

        public TestSuiteServiceTests()
        {
            _testSuiteRepoMock = new Mock<ITestSuiteRepository>();
            _projectRepoMock = new Mock<IProjectRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<TestSuiteService>>();
            _emailServiceMock = new Mock<IEmailService>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _userRepoMock = new Mock<IUserRepository>();

            _service = new TestSuiteService(
                _testSuiteRepoMock.Object,
                _projectRepoMock.Object,
                _uowMock.Object,
                _mapperMock.Object,
                _loggerMock.Object,
                _emailServiceMock.Object,
                _currentUserServiceMock.Object,
                _userRepoMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenExists_ReturnsDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var suite = new TestSuite { Id = id, Name = "Suite 1" };
            _testSuiteRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(suite);
            _mapperMock.Setup(m => m.Map<QAMS.Application.DTOs.TestSuites.TestSuiteDto>(suite))
                .Returns(new QAMS.Application.DTOs.TestSuites.TestSuiteDto { Id = id, Name = "Suite 1" });

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
    }
}
