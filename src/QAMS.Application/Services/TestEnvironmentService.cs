// src/QAMS.Application/Services/TestEnvironmentService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestEnvironments;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de Entornos de Prueba (ISTQB Cap. 5.4 — Gestión del entorno de pruebas).
    /// </summary>
    public class TestEnvironmentService(
        IGenericRepository<TestEnvironment> envRepo,
        IProjectRepository projectRepo,
        IUnitOfWork uow,
        ILogger<TestEnvironmentService> logger
    ) : ITestEnvironmentService
    {
        public async Task<List<TestEnvironmentDto>> GetByProjectAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo entornos de prueba del proyecto {ProjectId}.", projectId);
            var envs = await envRepo.FindAsync(e => e.ProjectId == projectId);
            return envs.Select(MapToDto).ToList();
        }

        public async Task<TestEnvironmentDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Obteniendo entorno de prueba {Id}.", id);
            var env = await envRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestEnvironment), id);
            return MapToDto(env);
        }

        public async Task<TestEnvironmentDto> CreateAsync(CreateTestEnvironmentDto dto)
        {
            logger.LogInformation("Creando entorno de prueba '{Name}' para proyecto {ProjectId}.", dto.Name, dto.ProjectId);

            _ = await projectRepo.GetByIdAsync(dto.ProjectId)
                ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            var env = new TestEnvironment
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                Description = dto.Description,
                BaseUrl = dto.BaseUrl,
                OperatingSystem = dto.OperatingSystem,
                Browser = dto.Browser,
                EnvironmentType = dto.EnvironmentType,
                SoftwareVersion = dto.SoftwareVersion,
                AdditionalConfig = dto.AdditionalConfig,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await envRepo.AddAsync(env);
            await uow.SaveChangesAsync();
            logger.LogInformation("Entorno de prueba {Id} creado.", env.Id);
            return MapToDto(env);
        }

        public async Task<TestEnvironmentDto> UpdateAsync(Guid id, UpdateTestEnvironmentDto dto)
        {
            logger.LogInformation("Actualizando entorno de prueba {Id}.", id);
            var env = await envRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestEnvironment), id);

            env.Name = dto.Name;
            env.Description = dto.Description;
            env.BaseUrl = dto.BaseUrl;
            env.OperatingSystem = dto.OperatingSystem;
            env.Browser = dto.Browser;
            env.EnvironmentType = dto.EnvironmentType;
            env.SoftwareVersion = dto.SoftwareVersion;
            env.AdditionalConfig = dto.AdditionalConfig;
            env.IsActive = dto.IsActive;
            env.UpdatedAt = DateTime.UtcNow;

            envRepo.Update(env);
            await uow.SaveChangesAsync();
            return MapToDto(env);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation("Eliminando entorno de prueba {Id}.", id);
            var env = await envRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestEnvironment), id);

            env.IsDeleted = true;
            env.DeletedAt = DateTime.UtcNow;
            envRepo.Update(env);
            await uow.SaveChangesAsync();
        }

        private static TestEnvironmentDto MapToDto(TestEnvironment e) => new()
        {
            Id = e.Id,
            ProjectId = e.ProjectId,
            ProjectName = e.Project?.Name ?? string.Empty,
            Name = e.Name,
            Description = e.Description,
            BaseUrl = e.BaseUrl,
            OperatingSystem = e.OperatingSystem,
            Browser = e.Browser,
            EnvironmentType = e.EnvironmentType,
            SoftwareVersion = e.SoftwareVersion,
            AdditionalConfig = e.AdditionalConfig,
            IsActive = e.IsActive,
            CreatedAt = e.CreatedAt,
            CreatedByUserName = e.CreatedBy?.FullName ?? string.Empty
        };
    }
}
