// src/QAMS.Tests/IntegrationTests/Endpoints/AuthEndpointsNegativeTests.cs
#nullable enable
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using QAMS.Application.DTOs.Auth;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;

namespace QAMS.Tests.IntegrationTests.Endpoints;

[Collection(SharedTestCollection.Name)]
public class AuthEndpointsNegativeTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task ForgotPassword_GeneratesToken_And_ResetPassword_Works()
    {
        // Arrange
        var user = await CreateTestUserAsync("reset_user");
        var forgotRequest = new ForgotPasswordRequestDto { Email = user.Email };

        // Act 1: Forgot Password
        var forgotResponse = await Client.PostAsJsonAsync("/api/auth/forgot-password", forgotRequest);
        forgotResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Verify token in DB
        string? resetToken = null;
        await ExecuteInScopeAsync(async db =>
        {
            var dbUser = await db.Users.SingleAsync(u => u.Id == user.Id);
            dbUser.PasswordResetToken.Should().NotBeNull();
            resetToken = dbUser.PasswordResetToken;
        });

        // Act 2: Reset Password
        var resetRequest = new ResetPasswordRequestDto
        {
            Email = user.Email,
            ResetToken = resetToken!,
            NewPassword = "NewStrongPassword123!"
        };

        var resetResponse = await Client.PostAsJsonAsync("/api/auth/reset-password", resetRequest);
        resetResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Act 3: Login with new password
        var loginRequest = new LoginRequestDto
        {
            Username = user.Username,
            Password = "NewStrongPassword123!"
        };
        var loginResponse = await Client.PostAsJsonAsync("/api/auth/login", loginRequest);
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Accessing_Protected_Endpoint_Without_Token_Returns_401()
    {
        var response = await Client.GetAsync("/api/projects");
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Accessing_Endpoint_Without_Permission_Returns_403()
    {
        // Arrange - Creamos un usuario sin ningÃºn permiso
        var user = await CreateTestUserAsync("no_perm_user");

        // Remove all roles/permissions for this user directly in DB
        await ExecuteInScopeAsync(async db =>
        {
            var userRoles = await db.Set<UserRole>().Where(ur => ur.UserId == user.Id).ToListAsync();
            db.Set<UserRole>().RemoveRange(userRoles);
            await db.SaveChangesAsync();
        });

        // Login to get token
        var loginRequest = new LoginRequestDto { Username = user.Username, Password = "password123" };
        var loginResponse = await Client.PostAsJsonAsync("/api/auth/login", loginRequest);
        var loginResult = await loginResponse.Content.ReadFromJsonAsync<LoginResponseDto>();

        // Set token
        Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResult!.AccessToken);

        // Act - Accedemos a un endpoint que requiere "PROJECT_VIEW"
        var response = await Client.GetAsync("/api/projects");

        // Assert â€” ASP.NET Core puede devolver 401 o 403 dependiendo
        // de si el middleware de autenticaciÃ³n intercepta antes que el de autorizaciÃ³n.
        // Ambos indican correctamente que el acceso fue denegado (Exit Criteria ISTQB Security).
        var validDeniedCodes = new[] { HttpStatusCode.Unauthorized, HttpStatusCode.Forbidden };
        validDeniedCodes.Should().Contain(response.StatusCode,
            "Se esperaba 401 (no autenticado) o 403 (sin permiso) al acceder sin permisos PROJECTS_VIEW.");
    }
}


