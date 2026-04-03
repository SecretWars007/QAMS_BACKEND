#nullable enable
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using QAMS.Application.DTOs.Auth;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.Services;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepo = new();
    private readonly Mock<IRbacService> _mockRbacService = new();
    private readonly Mock<IPasswordHasher> _mockHasher = new();
    private readonly Mock<IJwtTokenGenerator> _mockJwt = new();
    private readonly Mock<IUnitOfWork> _mockUow = new();
    private readonly Mock<IEmailService> _mockEmailService = new();
    private readonly Mock<ILogger<AuthService>> _mockLogger = new();

    private AuthService CreateService() => new(
        _mockUserRepo.Object,
        _mockRbacService.Object,
        _mockHasher.Object,
        _mockJwt.Object,
        _mockUow.Object,
        _mockEmailService.Object,
        _mockLogger.Object
    );

    [Fact]
    public async Task LoginAsync_WhenCredentialsValid_ShouldReturnTokens()
    {
        // Arrange
        var request = new LoginRequestDto { Username = "user", Password = "password" };
        var user = new User { Id = Guid.NewGuid(), Username = "user", PasswordHash = "hash", IsActive = true };
        IReadOnlyList<string> permissions = ["Perm1"];

        _mockUserRepo.Setup(r => r.GetWithRolesAndPermissionsAsync(request.Username)).ReturnsAsync(user);
        _mockHasher.Setup(h => h.VerifyPassword(request.Password, user.PasswordHash)).Returns(true);
        _mockRbacService.Setup(s => s.GetUserPermissionsAsync(user.Id)).ReturnsAsync(permissions);
        _mockJwt.Setup(j => j.GenerateAccessToken(user, permissions)).Returns("access-token");
        _mockJwt.Setup(j => j.GenerateRefreshToken()).Returns("refresh-token");

        var service = CreateService();

        // Act
        var result = await service.LoginAsync(request);

        // Assert
        result.AccessToken.Should().Be("access-token");
        result.RefreshToken.Should().Be("refresh-token");
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task LoginAsync_WhenUserNotFound_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var request = new LoginRequestDto { Username = "unknown", Password = "password" };
        _mockUserRepo.Setup(r => r.GetWithRolesAndPermissionsAsync(request.Username)).ReturnsAsync((User?)null);

        var service = CreateService();

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedException>(() => service.LoginAsync(request));
    }

    [Fact]
    public async Task RegisterAsync_WhenUserExists_ShouldThrowDomainException()
    {
        // Arrange
        var request = new RegisterRequestDto { Username = "existing", Email = "a@a.com" };
        _mockUserRepo.Setup(r => r.GetByUsernameAsync(request.Username)).ReturnsAsync(new User());

        var service = CreateService();

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.RegisterAsync(request));
    }

    [Fact]
    public async Task RegisterAsync_WhenAgeUnder18_ShouldThrowDomainException()
    {
        // Arrange
        var request = new RegisterRequestDto 
        { 
            Username = "young", 
            Email = "y@y.com", 
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-17)) 
        };
        var service = CreateService();

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.RegisterAsync(request));
        ex.Message.Should().Contain("18 y 80");
    }

    [Fact]
    public async Task RegisterAsync_WhenAgeOver80_ShouldThrowDomainException()
    {
        // Arrange
        var request = new RegisterRequestDto 
        { 
            Username = "old", 
            Email = "o@o.com", 
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Today.AddYears(-81)) 
        };
        var service = CreateService();

        // Act & Assert
        var ex = await Assert.ThrowsAsync<DomainException>(() => service.RegisterAsync(request));
        ex.Message.Should().Contain("18 y 80");
    }

    [Fact]
    public async Task ForgotPasswordAsync_WhenEmailExists_ShouldGenerateToken()
    {
        // Arrange
        var email = "user@test.com";
        var user = new User { Email = email, IsActive = true };
        _mockUserRepo.Setup(r => r.GetByEmailAsync(email)).ReturnsAsync(user);

        var service = CreateService();

        // Act
        var token = await service.ForgotPasswordAsync(new ForgotPasswordRequestDto { Email = email });

        // Assert
        token.Should().NotBeEmpty();
        user.PasswordResetToken.Should().Be(token);
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task ResetPasswordAsync_WhenTokenValid_ShouldUpdatePassword()
    {
        // Arrange
        var email = "user@test.com";
        var token = "123456";
        var user = new User 
        { 
            Email = email, 
            PasswordResetToken = token, 
            PasswordResetTokenExpiryTime = DateTime.UtcNow.AddMinutes(10) 
        };
        
        _mockUserRepo.Setup(r => r.GetByEmailAsync(email)).ReturnsAsync(user);
        _mockHasher.Setup(h => h.HashPassword("new-pass")).Returns("new-hash");

        var service = CreateService();

        // Act
        await service.ResetPasswordAsync(new ResetPasswordRequestDto 
        { 
            Email = email, 
            ResetToken = token, 
            NewPassword = "new-pass" 
        });

        // Assert
        user.PasswordHash.Should().Be("new-hash");
        user.PasswordResetToken.Should().BeNull();
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task RevokeRefreshTokenAsync_WhenUserExists_ShouldClearToken()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, RefreshToken = "token" };
        _mockUserRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);

        var service = CreateService();

        // Act
        await service.RevokeRefreshTokenAsync(userId);

        // Assert
        user.RefreshToken.Should().BeNull();
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task AdminResetPasswordAsync_WhenUserExists_ShouldUpdatePassword()
    {
        // Arrange
        var targetUserId = Guid.NewGuid();
        var user = new User 
        { 
            Id = targetUserId, 
            PasswordHash = "old-hash",
            PasswordResetToken = "some-token",
            PasswordResetTokenExpiryTime = DateTime.UtcNow.AddMinutes(5)
        };
        
        _mockUserRepo.Setup(r => r.GetByIdAsync(targetUserId)).ReturnsAsync(user);
        _mockHasher.Setup(h => h.HashPassword("new-admin-pass")).Returns("new-admin-hash");

        var service = CreateService();

        // Act
        await service.AdminResetPasswordAsync(targetUserId, "new-admin-pass");

        // Assert
        user.PasswordHash.Should().Be("new-admin-hash");
        user.PasswordResetToken.Should().BeNull();
        user.PasswordResetTokenExpiryTime.Should().BeNull();
        _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task AdminResetPasswordAsync_WhenUserNotFound_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var targetUserId = Guid.NewGuid();
        _mockUserRepo.Setup(r => r.GetByIdAsync(targetUserId)).ReturnsAsync((User?)null);

        var service = CreateService();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => 
            service.AdminResetPasswordAsync(targetUserId, "any-password"));
    }
}
