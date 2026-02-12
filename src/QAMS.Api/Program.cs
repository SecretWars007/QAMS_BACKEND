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
builder.Services.AddScoped<ITestExecutionService, TestExecutionService>();
builder.Services.AddScoped<IKanbanService, KanbanService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

    c.AddSecurityDefinition(
        "Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
        }
    );

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
    o.AddPolicy(
        "AllowAngular",
        p =>
            p.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
    )
);

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
        }
        catch (Exception migEx)
        {
            Log.Warning(migEx, "Migrations failed, attempting EnsureCreated().");
            db.Database.EnsureCreated();
        }

        var catalogService = services.GetRequiredService<ICatalogService>();

        // Seed helper
        async Task SeedIfEmpty(string name, List<string> codes)
        {
            var existing = await catalogService.GetAllByCatalogNameAsync(name);
            if (existing == null || existing.Count == 0)
            {
                int order = 1;
                foreach (var code in codes)
                {
                    await catalogService.CreateAsync(name, new QAMS.Application.DTOs.Catalogs.CreateCatalogItemDto
                    {
                        Code = code,
                        Name = code,
                        Description = null,
                        SortOrder = order++,
                        IsActive = true
                    });
                }
                Log.Information("Seeded catalog {Catalog} with {Count} items.", name, codes.Count);
            }
        }

        // Seed known catalogs
        SeedIfEmpty("executionstatus", new List<string>{"PENDING","IN_PROGRESS","PASSED","FAILED","BLOCKED","SKIPPED"}).GetAwaiter().GetResult();
        SeedIfEmpty("evidencetype", new List<string>{"IMAGE","VIDEO","DOCUMENT","LOG_FILE"}).GetAwaiter().GetResult();
        SeedIfEmpty("stepresultstatus", new List<string>{"NOT_EXECUTED","PASSED","FAILED","BLOCKED"}).GetAwaiter().GetResult();
        SeedIfEmpty("taskpriority", new List<string>{"LOW","MEDIUM","HIGH","CRITICAL"}).GetAwaiter().GetResult();
        SeedIfEmpty("testcasepriority", new List<string>{"LOW","MEDIUM","HIGH","CRITICAL"}).GetAwaiter().GetResult();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Error applying migrations or seeding data.");
        throw;
    }
}

if (app.Environment.IsDevelopment() || string.Equals(app.Environment.EnvironmentName, "Docker", StringComparison.OrdinalIgnoreCase))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QAMS API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseStaticFiles();
app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

Log.Information("QAMS API iniciada en {Env}.", app.Environment.EnvironmentName);
app.Run();
