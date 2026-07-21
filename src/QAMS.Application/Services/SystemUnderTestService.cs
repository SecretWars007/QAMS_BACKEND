using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.SystemsUnderTest;
using QAMS.Application.Interfaces;
using QAMS.Domain.Constants;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    public class SystemUnderTestService(
        IGenericRepository<SystemUnderTest> sutRepo,
        IProjectRepository projectRepo,
        ICatalogRepository<PlatformType> platformTypeRepo,
        IUnitOfWork uow,
        ILogger<SystemUnderTestService> logger) : ISystemUnderTestService
    {
        public async Task<IReadOnlyList<SystemUnderTestDto>> GetByProjectIdAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo sistemas bajo prueba para el proyecto {ProjectId}.", projectId);
            var suts = await sutRepo.FindAsync(s => s.ProjectId == projectId);
            foreach (var sut in suts)
            {
                if (sut.PlatformType == null && sut.PlatformTypeId > 0)
                {
                    sut.PlatformType = await platformTypeRepo.GetByIdAsync(sut.PlatformTypeId);
                }
            }
            return suts.Select(MapToDto).ToList();
        }

        public async Task<SystemUnderTestDto?> GetByIdAsync(Guid id)
        {
            var sut = await sutRepo.GetByIdAsync(id);
            if (sut == null) return null;

            if (sut.Project == null)
            {
                sut.Project = await projectRepo.GetByIdAsync(sut.ProjectId)
                    ?? throw new DomainException($"El proyecto asociado {sut.ProjectId} no existe.");
            }

            if (sut.PlatformType == null && sut.PlatformTypeId > 0)
            {
                sut.PlatformType = await platformTypeRepo.GetByIdAsync(sut.PlatformTypeId);
            }

            return MapToDto(sut);
        }

        public async Task<SystemUnderTestDto> CreateAsync(CreateSystemUnderTestDto dto)
        {
            logger.LogInformation("Registrando sistema {SutName} en proyecto {ProjectId}.", dto.Name, dto.ProjectId);

            var project = await projectRepo.GetByIdAsync(dto.ProjectId)
                ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            var platformTypeId = dto.PlatformTypeId <= 0 ? 1 : dto.PlatformTypeId;
            var platformType = await platformTypeRepo.GetByIdAsync(platformTypeId)
                ?? throw new DomainException($"El tipo de plataforma con ID {platformTypeId} no existe.");

            ValidateAndAssignPlatformDetails(platformType, dto.BaseUrl, dto.ExecutablePath, dto.ProcessName,
                out var baseUrl, out var executablePath, out var processName);

            var sut = new SystemUnderTest
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                Description = dto.Description,
                Version = dto.Version,
                Environment = dto.Environment,
                PlatformTypeId = platformType.Id,
                BaseUrl = baseUrl,
                ExecutablePath = executablePath,
                ProcessName = processName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await sutRepo.AddAsync(sut);
            await uow.SaveChangesAsync();

            sut.Project = project;
            sut.PlatformType = platformType;
            return MapToDto(sut);
        }

        public async Task<SystemUnderTestDto> UpdateAsync(Guid id, UpdateSystemUnderTestDto dto)
        {
            logger.LogInformation("Actualizando sistema bajo prueba {Id}.", id);

            var sut = await sutRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(SystemUnderTest), id);

            if (dto.Name is not null) sut.Name = dto.Name;
            if (dto.Description is not null) sut.Description = dto.Description;
            if (dto.Version is not null) sut.Version = dto.Version;
            if (dto.Environment is not null) sut.Environment = dto.Environment;
            if (dto.IsActive.HasValue) sut.IsActive = dto.IsActive.Value;

            var targetPlatformTypeId = dto.PlatformTypeId ?? sut.PlatformTypeId;
            var platformType = await platformTypeRepo.GetByIdAsync(targetPlatformTypeId)
                ?? throw new DomainException($"El tipo de plataforma con ID {targetPlatformTypeId} no existe.");

            var newBaseUrl = dto.BaseUrl ?? sut.BaseUrl;
            var newExecutablePath = dto.ExecutablePath ?? sut.ExecutablePath;
            var newProcessName = dto.ProcessName ?? sut.ProcessName;

            ValidateAndAssignPlatformDetails(platformType, newBaseUrl, newExecutablePath, newProcessName,
                out var baseUrl, out var executablePath, out var processName);

            sut.PlatformTypeId = platformType.Id;
            sut.BaseUrl = baseUrl;
            sut.ExecutablePath = executablePath;
            sut.ProcessName = processName;
            sut.UpdatedAt = DateTime.UtcNow;

            sutRepo.Update(sut);
            await uow.SaveChangesAsync();

            if (sut.Project == null)
            {
                sut.Project = await projectRepo.GetByIdAsync(sut.ProjectId)
                    ?? throw new DomainException($"El proyecto asociado {sut.ProjectId} no existe.");
            }
            sut.PlatformType = platformType;

            return MapToDto(sut);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation("Eliminando sistema bajo prueba {Id}.", id);
            var sut = await sutRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(SystemUnderTest), id);

            sut.IsDeleted = true;
            sut.DeletedAt = DateTime.UtcNow;
            sut.IsActive = false;

            sutRepo.Update(sut);
            await uow.SaveChangesAsync();
        }

        private static void ValidateAndAssignPlatformDetails(
            PlatformType platformType,
            string? rawBaseUrl,
            string? rawExecutablePath,
            string? rawProcessName,
            out string? baseUrl,
            out string? executablePath,
            out string? processName)
        {
            baseUrl = null;
            executablePath = null;
            processName = null;

            var code = platformType.Code.ToUpperInvariant();
            if (code == CatalogConstants.PlatformType.Web || platformType.Id == 1)
            {
                if (string.IsNullOrWhiteSpace(rawBaseUrl))
                {
                    throw new DomainException("Para la plataforma de Aplicación Web, la URL de acceso es obligatoria.");
                }
                baseUrl = rawBaseUrl.Trim();
            }
            else if (code == CatalogConstants.PlatformType.Desktop || platformType.Id == 2)
            {
                if (string.IsNullOrWhiteSpace(rawExecutablePath))
                {
                    throw new DomainException("Para la plataforma de Aplicación de Escritorio, la ruta del ejecutable es obligatoria.");
                }
                executablePath = rawExecutablePath.Trim();
            }
            else if (code == CatalogConstants.PlatformType.DataProcessing || platformType.Id == 3)
            {
                if (string.IsNullOrWhiteSpace(rawProcessName))
                {
                    throw new DomainException("Para la plataforma de Procesamiento de Información, el nombre del proceso es obligatorio.");
                }
                processName = rawProcessName.Trim();
            }
            else
            {
                throw new DomainException($"Tipo de plataforma '{platformType.Name}' no soportado para validaciones.");
            }
        }

        private static SystemUnderTestDto MapToDto(SystemUnderTest sut) => new()
        {
            Id = sut.Id,
            ProjectId = sut.ProjectId,
            ProjectName = sut.Project?.Name ?? string.Empty,
            Name = sut.Name,
            Description = sut.Description,
            Version = sut.Version,
            Environment = sut.Environment,
            PlatformTypeId = sut.PlatformTypeId,
            PlatformTypeName = sut.PlatformType?.Name ?? string.Empty,
            PlatformTypeCode = sut.PlatformType?.Code ?? string.Empty,
            BaseUrl = sut.BaseUrl,
            ExecutablePath = sut.ExecutablePath,
            ProcessName = sut.ProcessName,
            IsActive = sut.IsActive,
            CreatedAt = sut.CreatedAt
        };
    }
}
