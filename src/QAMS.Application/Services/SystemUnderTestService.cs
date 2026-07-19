// src/QAMS.Application/Services/SystemUnderTestService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.SystemsUnderTest;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    public class SystemUnderTestService(
        IGenericRepository<SystemUnderTest> sutRepo,
        IProjectRepository projectRepo,
        IUnitOfWork uow,
        ILogger<SystemUnderTestService> logger) : ISystemUnderTestService
    {
        public async Task<IReadOnlyList<SystemUnderTestDto>> GetByProjectIdAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo sistemas bajo prueba para el proyecto {ProjectId}.", projectId);
            var suts = await sutRepo.FindAsync(s => s.ProjectId == projectId);
            return suts.Select(MapToDto).ToList();
        }

        public async Task<SystemUnderTestDto?> GetByIdAsync(Guid id)
        {
            var sut = await sutRepo.GetByIdAsync(id);
            if (sut == null) return null;

            // Para obtener el ProjectName necesitamos cargar la entidad Project si no está incluida
            if (sut.Project == null)
            {
                sut.Project = await projectRepo.GetByIdAsync(sut.ProjectId)
                    ?? throw new DomainException($"El proyecto asociado {sut.ProjectId} no existe.");
            }

            return MapToDto(sut);
        }

        public async Task<SystemUnderTestDto> CreateAsync(CreateSystemUnderTestDto dto)
        {
            logger.LogInformation("Registrando sistema {SutName} en proyecto {ProjectId}.", dto.Name, dto.ProjectId);

            var project = await projectRepo.GetByIdAsync(dto.ProjectId)
                ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            var sut = new SystemUnderTest
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                Description = dto.Description,
                Version = dto.Version,
                Environment = dto.Environment,
                BaseUrl = dto.BaseUrl,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await sutRepo.AddAsync(sut);
            await uow.SaveChangesAsync();

            sut.Project = project; // para el MapToDto
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
            if (dto.BaseUrl is not null) sut.BaseUrl = dto.BaseUrl;
            if (dto.IsActive.HasValue) sut.IsActive = dto.IsActive.Value;

            sut.UpdatedAt = DateTime.UtcNow;

            sutRepo.Update(sut);
            await uow.SaveChangesAsync();

            if (sut.Project == null)
            {
                sut.Project = await projectRepo.GetByIdAsync(sut.ProjectId)
                    ?? throw new DomainException($"El proyecto asociado {sut.ProjectId} no existe.");
            }

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

        private static SystemUnderTestDto MapToDto(SystemUnderTest sut) => new()
        {
            Id = sut.Id,
            ProjectId = sut.ProjectId,
            ProjectName = sut.Project?.Name ?? string.Empty,
            Name = sut.Name,
            Description = sut.Description,
            Version = sut.Version,
            Environment = sut.Environment,
            BaseUrl = sut.BaseUrl,
            IsActive = sut.IsActive,
            CreatedAt = sut.CreatedAt
        };
    }
}
