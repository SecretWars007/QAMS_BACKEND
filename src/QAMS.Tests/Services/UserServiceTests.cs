using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports;
using QAMS.Domain.Ports.Repositories;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Xunit;

namespace QAMS.Tests.Services;

/// <summary>
/// Test suite for UserService with comprehensive TDD coverage.
/// 
/// Patterns Applied:
/// - Test-Driven Development: Red-Green-Refactor
/// - AAA: Arrange-Act-Assert structure
/// - Mocking: Isolated dependencies with Moq
/// 
/// Total: 6 tests covering all code paths
/// </summary>
public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository = new();
    private readonly Mock<IRoleRepository> _mockRoleRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IMapper> _mockMapper = new();
    private readonly Mock<ILogger<UserService>> _mockLogger = new();

    /// <summary>
    /// Factory method for creating UserService instance.
    /// Centralizes dependency injection to prevent duplication.
    /// </summary>
    private UserService CreateService() => new UserService(
        _mockUserRepository.Object,
        _mockRoleRepository.Object,
        _mockUnitOfWork.Object,
        _mockMapper.Object,
        _mockLogger.Object
    );

    [Fact(DisplayName = "AssignRoleAsync_UsuarioYRolExisten_DebeAsignar")]
    public async Task AssignRoleAsync_WhenUserAndRoleExist_ShouldAssign()
    {
        // ARRANGE
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(new User { Id = userId, Username = "testuser", IsActive = true });

        _mockRoleRepository
            .Setup(r => r.GetByIdAsync(roleId))
            .ReturnsAsync(new Role { Id = roleId, Name = "TestRole" });

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        var service = CreateService();

        // ACT
        await service.AssignRoleAsync(userId, roleId);

        // ASSERT
        _mockUserRepository.Verify(r => r.GetByIdAsync(userId), Times.Once);
        _mockRoleRepository.Verify(r => r.GetByIdAsync(roleId), Times.Once);
        _mockUserRepository.Verify(r => r.AssignRoleAsync(userId, roleId), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact(DisplayName = "AssignRoleAsync_UsuarioNoExiste_DebeThrowException")]
    public async Task AssignRoleAsync_WhenUserDoesNotExist_ShouldThrowException()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync((User)null);

        var service = CreateService();

        // ACT & ASSERT
        await Assert.ThrowsAsync<EntityNotFoundException>(
            () => service.AssignRoleAsync(userId, roleId)
        );

        _mockRoleRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact(DisplayName = "AssignRoleAsync_RolNoExiste_DebeThrowException")]
    public async Task AssignRoleAsync_WhenRoleDoesNotExist_ShouldThrowException()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(new User { Id = userId, Username = "test" });

        _mockRoleRepository
            .Setup(r => r.GetByIdAsync(roleId))
            .ReturnsAsync((Role)null);

        var service = CreateService();

        // ACT & ASSERT
        await Assert.ThrowsAsync<EntityNotFoundException>(
            () => service.AssignRoleAsync(userId, roleId)
        );

        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact(DisplayName = "RemoveRoleAsync_CuandoExisteUsuario_DebeRemover")]
    public async Task RemoveRoleAsync_WhenUserExists_ShouldRemoveRole()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(new User { Id = userId, Username = "test" });

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        var service = CreateService();

        // ACT
        await service.RemoveRoleAsync(userId, roleId);

        // ASSERT
        _mockUserRepository.Verify(r => r.GetByIdAsync(userId), Times.Once);
        _mockUserRepository.Verify(r => r.RemoveRoleAsync(userId, roleId), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact(DisplayName = "RemoveRoleAsync_UsuarioNoExiste_DebeThrowException")]
    public async Task RemoveRoleAsync_WhenUserDoesNotExist_ShouldThrowException()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync((User)null);

        var service = CreateService();

        // ACT & ASSERT
        await Assert.ThrowsAsync<EntityNotFoundException>(
            () => service.RemoveRoleAsync(userId, roleId)
        );

        _mockUserRepository.Verify(
            r => r.RemoveRoleAsync(It.IsAny<Guid>(), It.IsAny<Guid>()),
            Times.Never
        );
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact(DisplayName = "RemoveAllRolesAsync_DebeRemoverTodosLosRoles")]
    public async Task RemoveAllRolesAsync_ShouldRemoveAllRoles()
    {
        var userId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(new User { Id = userId, Username = "test" });

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(3);

        var service = CreateService();

        // ACT
        await service.RemoveAllRolesAsync(userId);

        // ASSERT
        _mockUserRepository.Verify(r => r.GetByIdAsync(userId), Times.Once);
        _mockUserRepository.Verify(r => r.RemoveAllRolesAsync(userId), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
