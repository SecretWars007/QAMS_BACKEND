using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QAMS.Infrastructure.Persistence.Configurations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;
using Xunit;

namespace QAMS.Tests.IntegrationTests.Infrastructure;

public class QamsIntegrationTestFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;

    public QamsIntegrationTestFactory()
    {
        // Iniciar un contenedor de PostgreSQL usando Testcontainers
        _dbContainer = new PostgreSqlBuilder("postgres:15-alpine")
            .WithDatabase("qams_test_db")
            .WithUsername("postgres")
            .WithPassword("password123")
            .Build();
    }

    public string ConnectionString => _dbContainer.GetConnectionString();

    // Reemplazamos la configuración de DB y Auth antes de que la aplicación "arranque"
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureTestServices(services =>
        {
            // Remover la BD normal
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<QamsDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbConnection));

            if (dbConnectionDescriptor != null)
                services.Remove(dbConnectionDescriptor);

            // Inyectar el DbContext apuntando al contenedor de test dockerizado
            services.AddDbContext<QamsDbContext>(options =>
            {
                options.UseNpgsql(_dbContainer.GetConnectionString());
            });

            // Sobrescribir Autenticación JWT por nuestra Auth de Test
            services.AddAuthentication(TestAuthHandler.SchemeName)
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                        TestAuthHandler.SchemeName, options => { });

            services.Configure<Microsoft.AspNetCore.Authentication.AuthenticationOptions>(options =>
            {
                options.DefaultAuthenticateScheme = TestAuthHandler.SchemeName;
                options.DefaultChallengeScheme = TestAuthHandler.SchemeName;
                options.DefaultScheme = TestAuthHandler.SchemeName;
            });
        });
    }

    // Interfaz IAsyncLifetime (xUnit la ejecuta automáticamente)
    async Task IAsyncLifetime.InitializeAsync()
    {
        // 1. Iniciar contenedor DB
        await _dbContainer.StartAsync();

        // 2. Usar EnsureCreatedAsync() en lugar de MigrateAsync() para tests de integración.
        //    EnsureCreatedAsync aplica el schema COMPLETO desde OnModelCreating de una sola vez,
        //    respetando el orden de dependencias de FK (roles antes que role_permissions, etc.).
        //    MigrateAsync() re-ejecuta el historial de migraciones, donde UpdateData sobre
        //    role_permissions puede correr antes de que los roles existan → FK violation 23503.
        using var scope = Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<QamsDbContext>();
        await db.Database.EnsureCreatedAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        // Apagar el contenedor al terminar la suite entera de tests asociada al factory
        await _dbContainer.DisposeAsync().AsTask();
    }
}
