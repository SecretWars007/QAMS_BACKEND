// src/QAMS.Api/Program.cs
using System;
using System.IO;
using System.Linq;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using QAMS.Api.Middleware;
using QAMS.Application;
using QAMS.Application.Interfaces;
using QAMS.Application.Services;
using QAMS.Infrastructure;
using QAMS.Infrastructure.Security;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Application.DTOs.Users;
using QAMS.Application.DTOs.Roles;
using QAMS.Domain.Entities;
using QAMS.Application.Mappings;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
// Cargar variables de entorno desde .env si existe (Desarrollo Local)
var dotEnv = Path.Combine(Directory.GetCurrentDirectory(), ".env");
if (File.Exists(dotEnv))
{
    foreach (var line in File.ReadAllLines(dotEnv))
    {
        var parts = line.Split('=', 2);
        if (parts.Length != 2) continue;
        Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
    }
}

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
        var dbPort = uri.Port > 0 ? uri.Port : 5432;
        var database = uri.AbsolutePath.TrimStart('/');

        // Reconstruir en formato estándar de .NET (Compatible con cualquier driver)
        var semicolonString = $"Host={host};Port={dbPort};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true;";
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

// Encryption
var encryptionSection = builder.Configuration.GetSection("EncryptionSettings");
builder.Services.Configure<EncryptionSettings>(encryptionSection);
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();

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

builder.Services.AddMemoryCache(); // ✅ Caché en memoria para permisos RBAC

// Health Checks: permite a Docker/Kubernetes verificar si la app está lista
builder.Services.AddHealthChecks()
    .AddNpgSql(
        builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty,
        name: "postgresql",
        tags: ["db", "ready"]
    );

// Application Services (registrar TODOS)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRbacService, RbacService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IRequirementService, RequirementService>();
builder.Services.AddScoped<ITestCaseService, TestCaseService>();
builder.Services.AddScoped<ITestSuiteService, TestSuiteService>();
builder.Services.AddScoped<ITestExecutionService, TestExecutionService>();
builder.Services.AddScoped<IKanbanService, KanbanService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IDefectService, DefectService>();
builder.Services.AddScoped<ISystemUnderTestService, SystemUnderTestService>();

// AutoMapper - Escaneo explícito de la capa de Application
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<MappingProfile>();

// Controllers + API Explorer + Swagger
builder.Services.AddControllers(options =>
{
    // Global filter to validate all inputs across the entire application
    options.Filters.Add<QAMS.Api.Filters.GlobalInputSanitizationFilter>();
});
builder.Services.AddEndpointsApiExplorer();

// Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("AuthLimit", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromMinutes(1);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 2;
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});
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

    // Incluir comentarios XML
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

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
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
    options.Cookie.Name = "XSRF-TOKEN";
    options.Cookie.HttpOnly = false; // Permite que Angular lo lea
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

builder.Services.AddCors(o =>
{
    o.AddPolicy(
        "AllowAngular",
        p =>
        {
            var frontendUrl = builder.Configuration["FRONTEND_URL"];
            List<string> origins = ["http://localhost:4200", "http://127.0.0.1:4200", "http://localhost", "http://127.0.0.1"];
            if (!string.IsNullOrEmpty(frontendUrl))
            {
                origins.Add(frontendUrl.TrimEnd('/'));
            }

            p.WithOrigins([.. origins])
            .SetIsOriginAllowed(origin =>
            {
                if (string.IsNullOrEmpty(origin)) return false;
                try
                {
                    var host = new Uri(origin).Host;
                    return host.EndsWith(".onrender.com", StringComparison.OrdinalIgnoreCase) ||
                           host.Equals("onrender.com", StringComparison.OrdinalIgnoreCase) ||
                           host.Equals("localhost", StringComparison.OrdinalIgnoreCase) ||
                           host.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase);
                }
                catch { return false; }
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
app.UseMiddleware<EncryptionMiddleware>();

// Middleware para enviar Token Antiforgery (XSRF) al frontend
app.Use((context, next) =>
{
    var tokens = context.RequestServices.GetRequiredService<Microsoft.AspNetCore.Antiforgery.IAntiforgery>();
    var tokenSet = tokens.GetAndStoreTokens(context);
    context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
        new CookieOptions { HttpOnly = false, Secure = !app.Environment.IsDevelopment(), SameSite = SameSiteMode.None });
    return next(context);
});

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
            var masked = string.Join(";", parts.Select(p =>
            {
                var trimmed = p.Trim();
                return trimmed.StartsWith("Password", StringComparison.OrdinalIgnoreCase) ? "Password=***" : trimmed;
            }));
            app.Logger.LogInformation("Cadena de conexión detectada y normalizada: {ConnectionString}", masked);
        }

        // En Producción, esperar un poco para asegurar que la base de datos de Render esté lista
        if (environment.IsProduction())
        {
            app.Logger.LogInformation("Ambiente de Producción detectado. Esperando 5 segundos para asegurar disponibilidad de DB...");
            await Task.Delay(5000); // ✅ No bloquea el thread pool (reemplaza Thread.Sleep)
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

// Habilitar Swagger sólo en Desarrollo o Testing
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Testing")
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QAMS API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseStaticFiles();
app.UseRouting();
app.UseRateLimiter();
app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health"); // ✅ Endpoint de Health Check para Docker/Kubernetes

app.Logger.LogInformation("QAMS API iniciada en {Env}.", app.Environment.EnvironmentName);
app.Run();

public partial class Program { }
