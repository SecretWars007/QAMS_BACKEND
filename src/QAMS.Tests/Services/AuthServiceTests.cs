#nullable enable
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.Auth;
using QAMS.Application.Interfaces;
using QAMS.Domain.Exceptions;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Tests.IntegrationTests.Infrastructure;
using Xunit;

namespace QAMS.Tests.Services;

[Collection("Integration tests")]
public class AuthServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private static IAuthService GetAuthService(IServiceScope scope)
    {
        return scope.ServiceProvider.GetRequiredService<IAuthService>();
    }

    [Fact(DisplayName = "LoginAsync_WhenCredentialsValid_ShouldReturnTokens")]
    public async Task LoginAsync_WhenCredentialsValid_ShouldReturnTokens()
    {
        // Arrange
        var user = await CreateTestUserAsync("validloginuser");
        var request = new LoginRequestDto { Username = user.Username, Password = "password123" };

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act
        var result = await service.LoginAsync(request);

        // Assert
        result.AccessToken.Should().NotBeNullOrEmpty();
        result.RefreshToken.Should().NotBeNullOrEmpty();
    }

    [Fact(DisplayName = "LoginAsync_WhenUserNotFound_ShouldThrowUnauthorizedException")]
    public async Task LoginAsync_WhenUserNotFound_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var request = new LoginRequestDto { Username = "unknown_user", Password = "password123" };

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedException>(() => service.LoginAsync(request));
    }

    [Fact(DisplayName = "RegisterAsync_WhenUserExists_ShouldThrowDomainException")]
    public async Task RegisterAsync_WhenUserExists_ShouldThrowDomainException()
    {
        // Arrange
        var user = await CreateTestUserAsync("existinguser");
        var request = new RegisterRequestDto
        {
            Username = user.Username, // Mismo username
            Email = "another@test.com",
            Password = "Password123!",
            DocumentoIdentidad = "12345678",
            FullName = "New User",
            FechaNacimiento = new DateOnly(1995, 1, 1),
            Telefono = "+12345678"
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.RegisterAsync(request));
    }

    [Fact(DisplayName = "RegisterAsync_WhenAgeUnder18_ShouldThrowDomainException")]
    public async Task RegisterAsync_WhenAgeUnder18_ShouldThrowDomainException()
    {
        // Arrange
        var uniqueId = Guid.NewGuid().ToString("N")[..8];
        var request = new RegisterRequestDto
        {
            Username = $"young_{uniqueId}",
            Email = $"young_{uniqueId}@test.com",
            Password = "Password123!",
            FullName = "Young User",
            DocumentoIdentidad = $"DOC-{uniqueId}",
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-17)),
            Telefono = "+12345678"
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.RegisterAsync(request));
        ex.Message.Should().Contain("18 y 80");
    }

    [Fact(DisplayName = "RegisterAsync_WhenAgeOver80_ShouldThrowDomainException")]
    public async Task RegisterAsync_WhenAgeOver80_ShouldThrowDomainException()
    {
        // Arrange
        var uniqueId = Guid.NewGuid().ToString("N")[..8];
        var request = new RegisterRequestDto
        {
            Username = $"old_{uniqueId}",
            Email = $"old_{uniqueId}@test.com",
            Password = "Password123!",
            FullName = "Old User",
            DocumentoIdentidad = $"DOC-{uniqueId}",
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-81)),
            Telefono = "+12345678"
        };

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.RegisterAsync(request));
        ex.Message.Should().Contain("18 y 80");
    }

    [Fact(DisplayName = "ForgotPasswordAsync_WhenEmailExists_ShouldGenerateToken")]
    public async Task ForgotPasswordAsync_WhenEmailExists_ShouldGenerateToken()
    {
        // Arrange
        var user = await CreateTestUserAsync("forgotuser");

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act
        var token = await service.ForgotPasswordAsync(new ForgotPasswordRequestDto { Email = user.Email });

        // Assert
        token.Should().NotBeNullOrEmpty();

        await ExecuteInScopeAsync(async db =>
        {
            var dbUser = await db.Users.FindAsync(user.Id);
            dbUser.Should().NotBeNull();
            dbUser!.PasswordResetToken.Should().Be(token);
        });
    }

    [Fact(DisplayName = "ResetPasswordAsync_WhenTokenValid_ShouldUpdatePassword")]
    public async Task ResetPasswordAsync_WhenTokenValid_ShouldUpdatePassword()
    {
        // Arrange
        var user = await CreateTestUserAsync("resetuser");
        string token = "";

        using (var scope = Factory.Services.CreateScope())
        {
            var service = GetAuthService(scope);
            token = await service.ForgotPasswordAsync(new ForgotPasswordRequestDto { Email = user.Email });
        }

        using (var scope = Factory.Services.CreateScope())
        {
            var service = GetAuthService(scope);

            // Act
            await service.ResetPasswordAsync(new ResetPasswordRequestDto
            {
                Email = user.Email,
                ResetToken = token,
                NewPassword = "NewPassword123!"
            });
        }

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var dbUser = await db.Users.FindAsync(user.Id);
            dbUser.Should().NotBeNull();
            dbUser!.PasswordResetToken.Should().BeNull(); // Token limpiado
        });

        // Comprobar que el login con nueva contraseña funciona
        using (var scope = Factory.Services.CreateScope())
        {
            var service = GetAuthService(scope);
            var result = await service.LoginAsync(new LoginRequestDto { Username = user.Username, Password = "NewPassword123!" });
            result.AccessToken.Should().NotBeNullOrEmpty();
        }
    }

    [Fact(DisplayName = "RevokeRefreshTokenAsync_WhenUserExists_ShouldClearToken")]
    public async Task RevokeRefreshTokenAsync_WhenUserExists_ShouldClearToken()
    {
        // Arrange
        var user = await CreateTestUserAsync("revokeuser");

        // Asignar un refresh token manualmente
        await ExecuteInScopeAsync(async db =>
        {
            var dbUser = await db.Users.FindAsync(user.Id);
            dbUser!.RefreshToken = "some-refresh-token";
            await db.SaveChangesAsync();
        });

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act
        await service.RevokeRefreshTokenAsync(user.Id);

        // Assert
        await ExecuteInScopeAsync(async db =>
        {
            var dbUser = await db.Users.FindAsync(user.Id);
            dbUser!.RefreshToken.Should().BeNull();
        });
    }

    [Fact(DisplayName = "AdminResetPasswordAsync_WhenUserExists_ShouldUpdatePassword")]
    public async Task AdminResetPasswordAsync_WhenUserExists_ShouldUpdatePassword()
    {
        // Arrange
        var user = await CreateTestUserAsync("adminresetuser");

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act
        await service.AdminResetPasswordAsync(user.Id, "AdminNewPass123!");

        // Assert
        // Comprobar que el login con nueva contraseña funciona
        using var loginScope = Factory.Services.CreateScope();
        var loginService = GetAuthService(loginScope);
        var result = await loginService.LoginAsync(new LoginRequestDto { Username = user.Username, Password = "AdminNewPass123!" });
        result.AccessToken.Should().NotBeNullOrEmpty();
    }

    [Fact(DisplayName = "AdminResetPasswordAsync_WhenUserNotFound_ShouldThrowEntityNotFoundException")]
    public async Task AdminResetPasswordAsync_WhenUserNotFound_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var fakeId = Guid.NewGuid();

        using var scope = Factory.Services.CreateScope();
        var service = GetAuthService(scope);

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() =>
            service.AdminResetPasswordAsync(fakeId, "any-password"));
    }
}
