#nullable enable
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Domain.Entities;
using QAMS.Infrastructure.Persistence.Configurations;
using Xunit;

namespace QAMS.Tests.IntegrationTests.Infrastructure;

public abstract class IntegrationTestBase(QamsIntegrationTestFactory factory) : IClassFixture<QamsIntegrationTestFactory>
{
    protected readonly QamsIntegrationTestFactory Factory = factory;
    protected readonly HttpClient Client = factory.CreateClient();

    /// <summary>
    /// Configura el HttpClient para simular autenticación con el ID de usuario proporcionado.
    /// Esto es capturado por el TestAuthHandler.
    /// </summary>
    protected void Authenticate(Guid userId)
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TestAuthHandler.SchemeName);
        Client.DefaultRequestHeaders.Remove("X-Test-UserId");
        Client.DefaultRequestHeaders.Add("X-Test-UserId", userId.ToString());
    }

    /// <summary>
    /// Crea un usuario real en la base de datos de test y devuelve su ID para usar en Authenticate() o aserciones.
    /// </summary>
    protected async Task<User> CreateTestUserAsync(string username = "testuser", string? roleName = null)
    {
        using var scope = Factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<QamsDbContext>();

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = $"{username}@qams.test",
            FullName = $"Test User {username}",
            IsActive = true,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123") // Hash correcto usando BCrypt
        };

        db.Users.Add(user);

        if (!string.IsNullOrEmpty(roleName))
        {
            var role = await db.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role == null)
            {
                role = new Role { Id = Guid.NewGuid(), Name = roleName, Description = "Test Role" };
                db.Roles.Add(role);
            }

            db.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = role.Id });
        }

        await db.SaveChangesAsync();
        return user;
    }

    /// <summary>
    /// Ejecuta una acción directamente dentro de un Scope contra el DbContext.
    /// Útil para la fase Arrange o para verificar en el Assert esquivando la API.
    /// </summary>
    protected async Task ExecuteInScopeAsync(Func<QamsDbContext, Task> action)
    {
        using var scope = Factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<QamsDbContext>();
        await action(db);
    }

}
