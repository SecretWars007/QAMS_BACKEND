// src/QAMS.Application/Services/ExploratoryService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Exploratory;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de Sesiones Exploratorias (ISTQB Cap. 4.4 — Técnicas basadas en experiencia).
    /// Implementa prueba exploratoria con charter, time-boxing y registro de hallazgos.
    /// </summary>
    public class ExploratoryService(
        IGenericRepository<ExploratorySession> sessionRepo,
        IGenericRepository<ExploratoryFinding> findingRepo,
        IProjectRepository projectRepo,
        IUnitOfWork uow,
        ILogger<ExploratoryService> logger
    ) : IExploratoryService
    {
        private static string GetStatusName(int statusId) => statusId switch
        {
            1 => "Planificada",
            2 => "En Progreso",
            3 => "Completada",
            _ => "Desconocido"
        };

        private static string GetFindingTypeName(int typeId) => typeId switch
        {
            1 => "Bug",
            2 => "Nota",
            3 => "Pregunta",
            _ => "Otro"
        };

        public async Task<List<ExploratorySessionDto>> GetByProjectAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo sesiones exploratorias del proyecto {ProjectId}.", projectId);
            var sessions = await sessionRepo.FindAsync(s => s.ProjectId == projectId);
            return sessions.Select(MapToDto).ToList();
        }

        public async Task<ExploratorySessionDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Obteniendo sesión exploratoria {Id}.", id);
            var session = await sessionRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(ExploratorySession), id);

            var findings = await findingRepo.FindAsync(f => f.SessionId == id);
            var dto = MapToDto(session);
            dto.Findings = findings.Select(f => new ExploratoryFindingDto
            {
                Id = f.Id,
                SessionId = f.SessionId,
                TypeId = f.TypeId,
                TypeName = GetFindingTypeName(f.TypeId),
                Description = f.Description,
                CreatedAt = f.CreatedAt
            }).ToList();
            return dto;
        }

        public async Task<ExploratorySessionDto> CreateAsync(CreateExploratorySessionDto dto)
        {
            logger.LogInformation("Creando sesión exploratoria para proyecto {ProjectId}.", dto.ProjectId);

            _ = await projectRepo.GetByIdAsync(dto.ProjectId)
                ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            var session = new ExploratorySession
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                TesterId = dto.TesterId,
                Charter = dto.Charter,
                StatusId = 1, // Planificada
                StartTime = dto.StartTime,
                Notes = dto.Notes,
                CreatedAt = DateTime.UtcNow
            };

            await sessionRepo.AddAsync(session);
            await uow.SaveChangesAsync();
            logger.LogInformation("Sesión exploratoria {Id} creada.", session.Id);
            return MapToDto(session);
        }

        public async Task<ExploratorySessionDto> StartSessionAsync(Guid id)
        {
            logger.LogInformation("Iniciando sesión exploratoria {Id}.", id);
            var session = await sessionRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(ExploratorySession), id);

            if (session.StatusId != 1)
                throw new DomainException("Solo se pueden iniciar sesiones en estado Planificada.");

            session.StatusId = 2; // En Progreso
            session.StartTime ??= DateTime.UtcNow;
            session.UpdatedAt = DateTime.UtcNow;

            sessionRepo.Update(session);
            await uow.SaveChangesAsync();
            return MapToDto(session);
        }

        public async Task<ExploratorySessionDto> CompleteSessionAsync(Guid id, UpdateExploratorySessionDto dto)
        {
            logger.LogInformation("Completando sesión exploratoria {Id}.", id);
            var session = await sessionRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(ExploratorySession), id);

            session.StatusId = 3; // Completada
            session.EndTime = dto.EndTime ?? DateTime.UtcNow;
            session.Notes = dto.Notes ?? session.Notes;
            session.DurationMinutes = dto.DurationMinutes
                ?? (session.StartTime.HasValue
                    ? (int)(session.EndTime.Value - session.StartTime.Value).TotalMinutes
                    : null);
            session.UpdatedAt = DateTime.UtcNow;

            sessionRepo.Update(session);
            await uow.SaveChangesAsync();
            return MapToDto(session);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation("Eliminando sesión exploratoria {Id}.", id);
            var session = await sessionRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(ExploratorySession), id);

            session.IsDeleted = true;
            session.DeletedAt = DateTime.UtcNow;
            sessionRepo.Update(session);
            await uow.SaveChangesAsync();
        }

        public async Task<ExploratoryFindingDto> AddFindingAsync(CreateExploratoryFindingDto dto)
        {
            logger.LogInformation("Agregando hallazgo a sesión {SessionId}.", dto.SessionId);

            _ = await sessionRepo.GetByIdAsync(dto.SessionId)
                ?? throw new EntityNotFoundException(nameof(ExploratorySession), dto.SessionId);

            var finding = new ExploratoryFinding
            {
                Id = Guid.NewGuid(),
                SessionId = dto.SessionId,
                TypeId = dto.TypeId,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await findingRepo.AddAsync(finding);
            await uow.SaveChangesAsync();

            return new ExploratoryFindingDto
            {
                Id = finding.Id,
                SessionId = finding.SessionId,
                TypeId = finding.TypeId,
                TypeName = GetFindingTypeName(finding.TypeId),
                Description = finding.Description,
                CreatedAt = finding.CreatedAt
            };
        }

        public async Task DeleteFindingAsync(Guid findingId)
        {
            logger.LogInformation("Eliminando hallazgo {FindingId}.", findingId);
            var finding = await findingRepo.GetByIdAsync(findingId)
                ?? throw new EntityNotFoundException(nameof(ExploratoryFinding), findingId);

            findingRepo.Delete(finding);
            await uow.SaveChangesAsync();
        }

        private static ExploratorySessionDto MapToDto(ExploratorySession s) => new()
        {
            Id = s.Id,
            ProjectId = s.ProjectId,
            ProjectName = s.Project?.Name ?? string.Empty,
            TesterId = s.TesterId,
            TesterName = s.Tester?.FullName ?? string.Empty,
            Charter = s.Charter,
            StatusId = s.StatusId,
            StatusName = GetStatusName(s.StatusId),
            StartTime = s.StartTime,
            EndTime = s.EndTime,
            DurationMinutes = s.DurationMinutes,
            Notes = s.Notes,
            CreatedAt = s.CreatedAt
        };
    }
}
