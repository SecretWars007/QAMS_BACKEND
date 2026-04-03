using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QAMS.Application.DTOs.Auth;
using QAMS.Tests.IntegrationTests.Infrastructure;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace QAMS.Tests.IntegrationTests.Endpoints;

[Collection("Integration tests")]
public class AuthEndpointsTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Register_WithValidData_ReturnsCreatedAndSavesToDb()
    {
        // Arrange
        var uniqueId = Guid.NewGuid().ToString("N")[..8];
        var request = new RegisterRequestDto
        {
            Username = $"user_{uniqueId}",
            Email = $"test_{uniqueId}@qams.test",
            Password = "StrongPassword123!",
            FullName = "Integration Test User",
            DocumentoIdentidad = $"DOC-{uniqueId}",
            FechaNacimiento = new System.DateOnly(1995, 5, 20),
            Telefono = "+59171234567"
        };

        // Act
        var response = await Client.PostAsJsonAsync("/api/auth/register", request);

        // Assert HTTP Response
        var body = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.Created, $"Response body: {body}");

        var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
        result.Should().NotBeNull();
        result!.AccessToken.Should().NotBeNullOrEmpty();
        result.FullName.Should().Be(request.FullName);

        // Assert Database State (Real Verification)
        await ExecuteInScopeAsync(async db =>
        {
            var userInDb = await db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            userInDb.Should().NotBeNull("El usuario debe de haber sido creado en la base de datos");
            userInDb!.Username.Should().Be(request.Username);
            userInDb.IsActive.Should().BeTrue();
            // Verify default role assignment (Trainee/Tester usually) assuming Roles seed worked
        });
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsToken()
    {
        // Arrange
        // Usamos el helper base para inyectar un usuario directo en la BD
        var user = await CreateTestUserAsync("login_user");

        var request = new LoginRequestDto
        {
            Username = user.Username,
            Password = "password123" // Esta es la clave por defecto que crea CreateTestUserAsync
        };

        // Act
        var response = await Client.PostAsJsonAsync("/api/auth/login", request);

        // Assert HTTP
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
        result.Should().NotBeNull();
        result!.AccessToken.Should().NotBeNullOrEmpty();
        result.FullName.Should().Be(user.FullName);
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        await CreateTestUserAsync("invalid_login_user");

        var request = new LoginRequestDto
        {
            Username = "invalid_login_user",
            Password = "wrongPassword!"
        };

        // Act
        var response = await Client.PostAsJsonAsync("/api/auth/login", request);

        // Assert HTTP
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
