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
using QAMS.Application.Mappings;
using QAMS.Domain.Entities;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/qams-.log", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

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
    var frontendUrl = builder.Configuration["FRONTEND_URL"] ?? "http://localhost:4200";
    o.AddPolicy(
        "AllowAngular",
        p =>
            p.WithOrigins(frontendUrl)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
    );
});


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Apply EF migrations (or create DB) and seed catalogs at startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<QamsDbContext>();
        // Try apply migrations; if none or fails, fall back to EnsureCreated
        try
        {
            db.Database.Migrate();
            Log.Information("Database migrations applied.");

            // Si no hay migrations aplicadas (proyecto usa EnsureCreated en dev), crear esquema
            var applied = db.Database.GetAppliedMigrations();
            if (applied == null || !applied.Any())
            {
                Log.Information("No applied migrations found; calling EnsureCreated() to create schema.");
                db.Database.EnsureCreated();
            }
        }
        catch (Exception migEx)
        {
            Log.Warning(migEx, "Migrations failed, attempting EnsureCreated().");
            try
            {
                db.Database.EnsureCreated();
            }
            catch (Exception ensureEx)
            {
                Log.Error(ensureEx, "EnsureCreated also failed.");
                throw;
            }
        }

    }
    catch (Exception ex)
    {
        // Registrar el error pero NO detener el arranque de la API.
        // Esto permite que Swagger y endpoints que no dependan de la BD funcionen
        // mientras se corrige la conexión a la base de datos en desarrollo.
        Log.Error(ex, "Error applying migrations. Continuing without DB initialization.");
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
app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

Log.Information("QAMS API iniciada en {Env}.", app.Environment.EnvironmentName);
app.Run();
