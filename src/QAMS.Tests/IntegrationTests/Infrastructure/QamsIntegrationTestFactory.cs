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

        // 2. Ejecutar EnsureCreated / Migraciones para que la DB esté lista para los tests
        using var scope = Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<QamsDbContext>();
        
        // EnsureCreated elimina restos si un test anterior falló gravemente, 
        // pero con un contenedor Docker fresco usualmente no hace falta.
        // Cambiamos a MigrateAsync() para asegurar que el esquema coincida con las migraciones,
        // incluyendo la columna 'documento_identidad'.
        await db.Database.MigrateAsync(); 
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        // Apagar el contenedor al terminar la suite entera de tests asociada al factory
        await _dbContainer.DisposeAsync().AsTask();
    }
}
