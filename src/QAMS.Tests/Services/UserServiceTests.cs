using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;
using Microsoft.Extensions.Logging;
using AutoMapper;
using QAMS.Application.Interfaces;
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
    private readonly Mock<IPasswordHasher> _mockPasswordHasher = new();
    private readonly Mock<ICurrentUserService> _mockCurrentUserService = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IMapper> _mockMapper = new();
    private readonly Mock<ILogger<UserService>> _mockLogger = new();
    private readonly Mock<IEmailService> _mockEmailService = new();

    /// <summary>
    /// Factory method for creating UserService instance.
    /// Centralizes dependency injection to prevent duplication.
    /// </summary>
    private UserService CreateService() => new(
        _mockUserRepository.Object,
        roleRepo: _mockRoleRepository.Object,
        hasher: _mockPasswordHasher.Object,
        currentUserService: _mockCurrentUserService.Object,
        uow: _mockUnitOfWork.Object,
        mapper: _mockMapper.Object,
        emailService: _mockEmailService.Object,
        logger: _mockLogger.Object
    );

    [Fact(DisplayName = "AssignRoleAsync_UsuarioYRolExisten_DebeAsignar")]
    public async Task AssignRoleAsync_WhenUserAndRoleExist_ShouldAssign()
    {
        // ARRANGE
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(new User { Id = userId, IsActive = true });

        _mockRoleRepository
            .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Role, bool>>>()))
            .ReturnsAsync(true);

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        var service = CreateService();

        // ACT
        await service.AssignRoleAsync(userId, roleId);

        // ASSERT
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

        _mockRoleRepository.Verify(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Role, bool>>>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact(DisplayName = "AssignRoleAsync_RolNoExiste_DebeThrowException")]
    public async Task AssignRoleAsync_WhenRoleDoesNotExist_ShouldThrowException()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(new User { Id = userId, IsActive = true });

        _mockRoleRepository
            .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Role, bool>>>()))
            .ReturnsAsync(false);

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
            .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(true);
            
        _mockRoleRepository
            .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Role, bool>>>()))
            .ReturnsAsync(true);

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        var service = CreateService();

        // ACT
        await service.RemoveRoleAsync(userId, roleId);

        // ASSERT
        _mockUserRepository.Verify(r => r.RemoveRoleAsync(userId, roleId), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact(DisplayName = "RemoveRoleAsync_UsuarioNoExiste_DebeThrowException")]
    public async Task RemoveRoleAsync_WhenUserDoesNotExist_ShouldThrowException()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(false);

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
            .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(true);

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(3);

        var service = CreateService();

        // ACT
        await service.RemoveAllRolesAsync(userId);

        // ASSERT
        _mockUserRepository.Verify(r => r.RemoveAllRolesAsync(userId), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact(DisplayName = "DeleteAsync_UsuarioExistenteYNoEsElMismo_DebeDesactivar")]
    public async Task DeleteAsync_WhenUserExistsAndIsNotSelf_ShouldDeactivate()
    {
        // ARRANGE
        var currentUserId = Guid.NewGuid();
        var targetUserId = Guid.NewGuid();
        var user = new User { Id = targetUserId, Username = "test", IsActive = true };

        _mockCurrentUserService.Setup(s => s.UserId).Returns(currentUserId);
        _mockUserRepository.Setup(r => r.GetWithRolesAsync(targetUserId)).ReturnsAsync(user);

        var service = CreateService();

        // ACT
        await service.DeleteAsync(targetUserId);

        // ASSERT
        user.IsActive.Should().BeFalse();
        _mockUserRepository.Verify(r => r.Update(user), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact(DisplayName = "DeleteAsync_AutoEliminacion_DebeLanzarDomainException")]
    public async Task DeleteAsync_WhenSelfDeletionAttempt_ShouldThrowDomainException()
    {
        // ARRANGE
        var userId = Guid.NewGuid();
        _mockCurrentUserService.Setup(s => s.UserId).Returns(userId);

        var service = CreateService();

        // ACT & ASSERT
        await Assert.ThrowsAsync<DomainException>(() => service.DeleteAsync(userId));
    }

    [Fact(DisplayName = "DeleteAsync_UsuarioConRoles_DebeLanzarDomainException")]
    public async Task DeleteAsync_WhenUserHasRoles_ShouldThrowDomainException()
    {
        // ARRANGE
        var currentUserId = Guid.NewGuid();
        var targetUserId = Guid.NewGuid();
        var user = new User 
        { 
            Id = targetUserId, 
            Username = "test", 
            IsActive = true,
            UserRoles = [new() { RoleId = Guid.NewGuid(), UserId = targetUserId }]
        };

        _mockCurrentUserService.Setup(s => s.UserId).Returns(currentUserId);
        _mockUserRepository.Setup(r => r.GetWithRolesAsync(targetUserId)).ReturnsAsync(user);

        var service = CreateService();

        // ACT & ASSERT
        var act = () => service.DeleteAsync(targetUserId);
        await act.Should().ThrowAsync<DomainException>()
            .WithMessage("No se puede eliminar el usuario porque tiene roles asignados. Primero remueve sus roles.");

        _mockUserRepository.Verify(r => r.Update(It.IsAny<User>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact(DisplayName = "GetAllAsync_DebeRetornarTodosLosUsuarios")]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        // ARRANGE
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), IsActive = true, Username = "active" },
            new() { Id = Guid.NewGuid(), IsActive = false, Username = "inactive" }
        };

        _mockUserRepository.Setup(r => r.GetAllWithRolesAsync()).ReturnsAsync(users);
        _mockMapper.Setup(m => m.Map<List<UserDto>>(It.IsAny<List<User>>()))
                   .Returns((List<User> src) => [.. src.Select(u => new UserDto { Username = u.Username })]);

        var service = CreateService();

        // ACT
        var result = await service.GetAllAsync();

        // ASSERT
        result.Should().HaveCount(2);
        result[0].Username.Should().Be("active");
        result[1].Username.Should().Be("inactive");
    }

    [Fact(DisplayName = "UpdateAsync_EmailYaEnUso_DebeLanzarDomainException")]
    public async Task UpdateAsync_WhenEmailAlreadyInUseByAnotherUser_ShouldThrowDomainException()
    {
        // ARRANGE
        var userId = Guid.NewGuid();
        var existingUser = new User { Id = userId, Email = "old@test.com" };
        var otherUserId = Guid.NewGuid();
        var dto = new UpdateUserDto { Email = "taken@test.com", FullName = "New Name", IsActive = true, RoleIds = [] };

        _mockUserRepository.Setup(r => r.GetWithRolesAsync(userId)).ReturnsAsync(existingUser);
        _mockUserRepository.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                           .ReturnsAsync(true); // Taken by another

        var service = CreateService();

        // ACT & ASSERT
        await Assert.ThrowsAsync<DomainException>(() => service.UpdateAsync(userId, dto));
    }

    [Fact(DisplayName = "CreateAsync_EdadInvalida_DebeLanzarDomainException")]
    public async Task CreateAsync_WhenAgeIsInvalid_ShouldThrowDomainException()
    {
        // ARRANGE
        var dto = new CreateUserDto 
        { 
            Username = "young", 
            Email = "y@y.com", 
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-17)),
            RoleIds = []
        };
        
        var service = CreateService();

        // ACT & ASSERT
        var act = () => service.CreateAsync(dto);
        await act.Should().ThrowAsync<DomainException>().WithMessage("*entre 18 y 80*");
    }

    [Fact(DisplayName = "UpdateAsync_EdadInvalida_DebeLanzarDomainException")]
    public async Task UpdateAsync_WhenAgeIsInvalid_ShouldThrowDomainException()
    {
        // ARRANGE
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)) };
        var dto = new UpdateUserDto 
        { 
            Email = "u@u.com", 
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-85)),
            RoleIds = []
        };

        _mockUserRepository.Setup(r => r.GetWithRolesAsync(userId)).ReturnsAsync(user);
        
        var service = CreateService();

        // ACT & ASSERT
        var act = () => service.UpdateAsync(userId, dto);
        await act.Should().ThrowAsync<DomainException>().WithMessage("*entre 18 y 80*");
    }

    [Fact(DisplayName = "ResetPasswordAsync_UsuarioExistente_DebeActualizarHash")]
    public async Task ResetPasswordAsync_WhenUserExists_ShouldUpdateHash()
    {
        // ARRANGE
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Email = "test@example.com", FullName = "Test User" };
        var newPassword = "newPassword123";
        var hashedPass = "hashedValue";

        _mockUserRepository.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
        _mockPasswordHasher.Setup(h => h.HashPassword(newPassword)).Returns(hashedPass);

        var service = CreateService();

        // ACT
        await service.ResetPasswordAsync(userId, newPassword);

        // ASSERT
        user.PasswordHash.Should().Be(hashedPass);
        _mockUserRepository.Verify(r => r.Update(user), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        _mockEmailService.Verify(e => e.SendEmailAsync("test@example.com", It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}
