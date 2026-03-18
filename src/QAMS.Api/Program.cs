// src/QAMS.Api/Program.cs
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QAMS.Api.Middleware;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Infrastructure;
using QAMS.Infrastructure.Security;
using QAMS.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using QAMS.Application.DTOs.Users;
using QAMS.Application.DTOs.Roles;
using QAMS.Domain.Entities;
using Microsoft.AspNetCore.HttpOverrides;
var builder = WebApplication.CreateBuilder(args);
// builder.Host.UseSerilog(); // Removed to use standard ILogger


// Normalizar cadena de conexión de Render (URI -> Semicolon format)
var rawConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(rawConnectionString) && rawConnectionString.Contains("://"))
{
    try 
    {
        // Forzar prefijo para que System.Uri lo reconozca
        var uriString = rawConnectionString.Replace("postgresql://", "postgres://", StringComparison.OrdinalIgnoreCase);
        var uri = new Uri(uriString);
        var userInfo = uri.UserInfo.Split(':');
        var user = userInfo[0];
        var password = userInfo.Length > 1 ? userInfo[1] : "";
        var host = uri.Host;
        var port = uri.Port > 0 ? uri.Port : 5432;
        var database = uri.AbsolutePath.TrimStart('/');
        
        // Reconstruir en formato estándar de .NET (Compatible con cualquier driver)
        var semicolonString = $"Host={host};Port={port};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true;";
        builder.Configuration["ConnectionStrings:DefaultConnection"] = semicolonString;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error crítico al normalizar la URI de conexión: {ex.Message}");
    }
}

// Infrastructure (DbContext, Repos, PasswordHasher, JWT, FileStorage)
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// JWT
var jwtSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSection);
var jwt = jwtSection.Get<JwtSettings>()!;

builder
    .Services.AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret)),
            ClockSkew = TimeSpan.Zero,
        };
    });
builder.Services.AddAuthorization();

// Application Services (registrar TODOS)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRbacService, RbacService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITestCaseService, TestCaseService>();
builder.Services.AddScoped<ITestSuiteService, TestSuiteService>();
builder.Services.AddScoped<ITestExecutionService, TestExecutionService>();
builder.Services.AddScoped<IKanbanService, KanbanService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

// AutoMapper - Escaneo explícito de la capa de Application
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// FluentValidation
// builder.Services.AddValidatorsFromAssemblyContaining<MappingProfile>();

// Controllers + API Explorer + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "QAMS API",
        Version = "v1",
        Description = "Quality Assurance Management System API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "QAMS Support",
            Email = "support@qams.local"
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Internal Use Only"
        }
    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                Array.Empty<string>()
            },
        }
    );
});

// CORS
builder.Services.AddCors(o =>
{
    o.AddPolicy(
        "AllowAngular",
        p =>
        {
            var frontendUrl = builder.Configuration["FRONTEND_URL"];
            if (!string.IsNullOrEmpty(frontendUrl))
            {
                p.WithOrigins(frontendUrl.TrimEnd('/'));
            }

            p.SetIsOriginAllowed(origin => 
            {
                if (string.IsNullOrEmpty(origin)) return false;
                try {
                    var host = new Uri(origin).Host;
                    return host.EndsWith(".onrender.com", StringComparison.OrdinalIgnoreCase) || 
                           host.Equals("onrender.com", StringComparison.OrdinalIgnoreCase) ||
                           host.Equals("localhost", StringComparison.OrdinalIgnoreCase) ||
                           host.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase);
                } catch { return false; }
            })
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
            .WithExposedHeaders("Content-Disposition");
        }
    );
});
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Handle PORT environment variable for Render
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseForwardedHeaders();

// Apply EF migrations (or create DB) and seed catalogs at startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var environment = app.Environment;
    
    try
    {
        var db = services.GetRequiredService<QamsDbContext>();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            app.Logger.LogError("CRÍTICO: No se encontró la cadena de conexión 'DefaultConnection' en la configuración.");
        }
        else
        {
            // Enmascaramiento robusto (siempre será Semicolon después de la normalización)
            var parts = connectionString.Split(';');
            var masked = string.Join(";", parts.Select(p => {
                var trimmed = p.Trim();
                return trimmed.StartsWith("Password", StringComparison.OrdinalIgnoreCase) ? "Password=***" : trimmed;
            }));
            app.Logger.LogInformation("Cadena de conexión detectada y normalizada: {ConnectionString}", masked);
        }
        
        // En Producción, esperar un poco para asegurar que la base de datos de Render esté lista
        if (environment.IsProduction())
        {
            app.Logger.LogInformation("Ambiente de Producción detectado. Esperando 5 segundos para asegurar disponibilidad de DB...");
            Thread.Sleep(5000); 
        }

        app.Logger.LogInformation("Iniciando aplicación de migraciones...");

        // Try apply migrations; if none or fails, fall back to EnsureCreated
        try
        {
            var pendingMigrations = db.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                app.Logger.LogInformation("Se encontraron {Count} migraciones pendientes. Aplicando...", pendingMigrations.Count());
                db.Database.Migrate();
                app.Logger.LogInformation("Migraciones aplicadas exitosamente.");
            }
            else
            {
                app.Logger.LogInformation("No hay migraciones pendientes.");
                
                // Si no hay migrations aplicadas (proyecto usa EnsureCreated en dev o DB vacía sin historial), crear esquema
                var applied = db.Database.GetAppliedMigrations();
                if (applied == null || !applied.Any())
                {
                    app.Logger.LogInformation("No se encontraron migraciones aplicadas en el historial; intentando EnsureCreated().");
                    db.Database.EnsureCreated();
                }
            }
        }
        catch (Exception migEx)
        {
            app.Logger.LogWarning(migEx, "Migrate() falló. Intentando EnsureCreated() como fallback...");
            try
            {
                db.Database.EnsureCreated();
                app.Logger.LogInformation("EnsureCreated() completado exitosamente.");
            }
            catch (Exception ensureEx)
            {
                app.Logger.LogError(ensureEx, "CRÍTICO: EnsureCreated() también falló. No se pudieron crear las tablas.");
                if (environment.IsProduction())
                {
                    // En producción queremos saber si esto falla críticamente
                    throw; 
                }
            }
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "ERROR FATAL durante la inicialización de la base de datos.");
        if (environment.IsProduction())
        {
            app.Logger.LogCritical("La aplicación no puede iniciar en Producción sin una base de datos válida.");
            // Opcional: throw; // Descomentar si se prefiere que el pod de Render falle y se reinicie
        }
    }
}

// Habilitar Swagger siempre (facilita pruebas en Render y otros entornos)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QAMS API v1");
    c.RoutePrefix = "swagger";
});


app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Logger.LogInformation("QAMS API iniciada en {Env}.", app.Environment.EnvironmentName);
app.Run();
