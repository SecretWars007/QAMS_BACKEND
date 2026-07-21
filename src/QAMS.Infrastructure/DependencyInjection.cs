// src/QAMS.Infrastructure/DependencyInjection.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.Interfaces;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;
using QAMS.Infrastructure.FileStorage;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Infrastructure.Repositories;
using QAMS.Infrastructure.Security;

namespace QAMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // PostgreSQL con reintentos
            services.AddDbContext<QamsDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    npgsql => npgsql.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null)
                )
            );

            // Repositorios genéricos
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICatalogRepository<>), typeof(CatalogRepository<>));

            // Repositorios específicos
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITestSuiteRepository, TestSuiteRepository>();
            services.AddScoped<ITestCaseRepository, TestCaseRepository>();
            services.AddScoped<ITestExecutionRepository, TestExecutionRepository>();
            services.AddScoped<IEvidenceRepository, EvidenceRepository>();
            services.AddScoped<IObservationRepository, ObservationRepository>();
            services.AddScoped<IKanbanBoardRepository, KanbanBoardRepository>();
            services.AddScoped<IDefectRepository, DefectRepository>();
            services.AddScoped<QAMS.Application.Interfaces.Repositories.ITestPlanRepository, TestPlanRepository>();
            services.AddScoped<QAMS.Application.Interfaces.Repositories.IApiKeyRepository, ApiKeyRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Servicios de infraestructura
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IFileStorageService, LocalFileStorageService>();
            services.AddScoped<IReportService, Services.PdfReportService>();

            // Email SMTP
            services.Configure<Email.SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.AddScoped<IEmailService, Email.SmtpEmailService>();

            return services;
        }
    }
}
