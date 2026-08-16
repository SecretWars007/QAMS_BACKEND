#nullable enable
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace QAMS.Tests.Services;

[Collection(SharedTestCollection.Name)]
public class UserServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private IUserService GetUserService(IServiceScope scope, Guid? currentUserId = null)
    {
        if (currentUserId.HasValue)
        {
            var httpContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, currentUserId.Value.ToString())
            }, "TestAuth");
            context.User = new ClaimsPrincipal(identity);
            httpContextAccessor.HttpContext = context;
        }
        return scope.ServiceProvider.GetRequiredService<IUserService>();
    }

    [Fact(DisplayName = "AssignRoleAsync_UsuarioYRolExisten_DebeAsignar")]
    public async Task AssignRoleAsync_WhenUserAndRoleExist_ShouldAssign()
    {
        // Arrange
        var user = await CreateTestUserAsync("assignuser");
        Guid roleId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Roles.Add(new Role { Id = roleId, Name = "TestRoleAssign", Description = "Desc" });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act
        await service.AssignRoleAsync(user.Id, roleId);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var userRole = await db.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == roleId);
            userRole.Should().NotBeNull();
        });
    }

    [Fact(DisplayName = "AssignRoleAsync_UsuarioNoExiste_DebeThrowException")]
    public async Task AssignRoleAsync_WhenUserDoesNotExist_ShouldThrowException()
    {
        // Arrange
        Guid fakeUserId = Guid.NewGuid();
        Guid roleId = Guid.NewGuid();

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => service.AssignRoleAsync(fakeUserId, roleId));
    }

    [Fact(DisplayName = "AssignRoleAsync_RolNoExiste_DebeThrowException")]
    public async Task AssignRoleAsync_WhenRoleDoesNotExist_ShouldThrowException()
    {
        // Arrange
        var user = await CreateTestUserAsync("assignuser2");
        Guid fakeRoleId = Guid.NewGuid();

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => service.AssignRoleAsync(user.Id, fakeRoleId));
    }

    [Fact(DisplayName = "RemoveRoleAsync_CuandoExisteUsuario_DebeRemover")]
    public async Task RemoveRoleAsync_WhenUserExists_ShouldRemoveRole()
    {
        // Arrange
        var user = await CreateTestUserAsync("removerole");
        Guid roleId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Roles.Add(new Role { Id = roleId, Name = "TestRoleRemove", Description = "Desc" });
            db.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = roleId });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act
        await service.RemoveRoleAsync(user.Id, roleId);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var userRole = await db.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == roleId && !ur.IsDeleted);
            userRole.Should().BeNull();
        });
    }

    [Fact(DisplayName = "RemoveAllRolesAsync_DebeRemoverTodosLosRoles")]
    public async Task RemoveAllRolesAsync_ShouldRemoveAllRoles()
    {
        // Arrange
        var user = await CreateTestUserAsync("removeall");
        Guid roleId1 = Guid.NewGuid();
        Guid roleId2 = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Roles.Add(new Role { Id = roleId1, Name = "R1", Description = "Desc" });
            db.Roles.Add(new Role { Id = roleId2, Name = "R2", Description = "Desc" });
            db.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = roleId1 });
            db.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = roleId2 });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act
        await service.RemoveAllRolesAsync(user.Id);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var count = await db.UserRoles.CountAsync(ur => ur.UserId == user.Id && !ur.IsDeleted);
            count.Should().Be(0);
        });
    }

    [Fact(DisplayName = "DeleteAsync_UsuarioExistenteYNoEsElMismo_DebeDesactivar")]
    public async Task DeleteAsync_WhenUserExistsAndIsNotSelf_ShouldDeactivate()
    {
        // Arrange
        var targetUser = await CreateTestUserAsync("targetdelete");
        var currentUser = await CreateTestUserAsync("currentuser");

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope, currentUserId: currentUser.Id);

        // Act
        await service.DeleteAsync(targetUser.Id);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var updatedUser = await db.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == targetUser.Id);
            updatedUser!.IsActive.Should().BeFalse();
            updatedUser.IsDeleted.Should().BeTrue();
        });
    }

    [Fact(DisplayName = "DeleteAsync_AutoEliminacion_DebeLanzarDomainException")]
    public async Task DeleteAsync_WhenSelfDeletionAttempt_ShouldThrowDomainException()
    {
        // Arrange
        var user = await CreateTestUserAsync("selfdelete");

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope, currentUserId: user.Id);

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.DeleteAsync(user.Id));
    }

    [Fact(DisplayName = "DeleteAsync_UsuarioConRoles_DebeLanzarDomainException")]
    public async Task DeleteAsync_WhenUserHasRoles_ShouldThrowDomainException()
    {
        // Arrange
        var targetUser = await CreateTestUserAsync("targetdelete2");
        var currentUser = await CreateTestUserAsync("currentuser2");

        await ExecuteInScopeAsync(async db =>
        {
            var roleId = Guid.NewGuid();
            db.Roles.Add(new Role { Id = roleId, Name = "RoleForDeleteTest", Description = "Desc" });
            db.UserRoles.Add(new UserRole { UserId = targetUser.Id, RoleId = roleId });
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope, currentUserId: currentUser.Id);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.DeleteAsync(targetUser.Id));
        ex.Message.Should().Contain("roles asignados");
    }

    [Fact(DisplayName = "GetAllAsync_DebeRetornarTodosLosUsuarios")]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        // Arrange
        await CreateTestUserAsync("getall1");
        await CreateTestUserAsync("getall2");

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeEmpty();
        result.Count.Should().BeGreaterThanOrEqualTo(2);
    }

    [Fact(DisplayName = "UpdateAsync_EmailYaEnUso_DebeLanzarDomainException")]
    public async Task UpdateAsync_WhenEmailAlreadyInUseByAnotherUser_ShouldThrowDomainException()
    {
        // Arrange
        var user1 = await CreateTestUserAsync("user1");
        var user2 = await CreateTestUserAsync("user2");

        var dto = new UpdateUserDto
        {
            Email = user1.Email, // Usar el email del user1
            FullName = "New Name",
            IsActive = true,
            RoleIds = []
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.UpdateAsync(user2.Id, dto));
    }

    [Fact(DisplayName = "CreateAsync_EdadInvalida_DebeLanzarDomainException")]
    public async Task CreateAsync_WhenAgeIsInvalid_ShouldThrowDomainException()
    {
        // Arrange
        var uniqueId = Guid.NewGuid().ToString("N")[..8];
        var dto = new CreateUserDto
        {
            Username = $"young_create_{uniqueId}",
            Email = $"young_create_{uniqueId}@y.com",
            DocumentoIdentidad = $"DOC-{uniqueId}",
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-17)),
            RoleIds = []
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
        ex.Message.Should().Contain("18 y 80");
    }

    [Fact(DisplayName = "UpdateAsync_EdadInvalida_DebeLanzarDomainException")]
    public async Task UpdateAsync_WhenAgeIsInvalid_ShouldThrowDomainException()
    {
        // Arrange
        var user = await CreateTestUserAsync("updateage");
        var dto = new UpdateUserDto
        {
            Email = user.Email,
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-85)),
            RoleIds = []
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.UpdateAsync(user.Id, dto));
        ex.Message.Should().Contain("18 y 80");
    }

    [Fact(DisplayName = "ResetPasswordAsync_UsuarioExistente_DebeActualizarHash")]
    public async Task ResetPasswordAsync_WhenUserExists_ShouldUpdateHash()
    {
        // Arrange
        var user = await CreateTestUserAsync("resetpasstest");
        var oldHash = user.PasswordHash;

        using var scope = Factory.Services.CreateScope();
        var service = GetUserService(scope);

        // Act
        await service.ResetPasswordAsync(user.Id, "NewPassword123!");

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var dbUser = await db.Users.FindAsync(user.Id);
            dbUser!.PasswordHash.Should().NotBe(oldHash); // El hash debe haber cambiado
        });
    }
}


