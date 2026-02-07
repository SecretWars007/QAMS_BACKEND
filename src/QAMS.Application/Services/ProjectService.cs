// src/QAMS.Application/Services/ProjectService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IProjectRepository projectRepo, IUnitOfWork uow,
            IMapper mapper, ILogger<ProjectService> logger)
        {
            _projectRepo = projectRepo;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProjectDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo proyecto {ProjectId}.", id);
            var project = await _projectRepo.GetWithTestSuitesAsync(id)
                ?? throw new EntityNotFoundException(nameof(Project), id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todos los proyectos.");
            var projects = await _projectRepo.GetAllAsync();
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            _logger.LogInformation("Creando proyecto '{Name}'.", dto.Name);

            if (await _projectRepo.AnyAsync(p => p.Name == dto.Name))
                throw new DomainException($"El proyecto '{dto.Name}' ya existe.");

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _projectRepo.AddAsync(project);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Proyecto '{Name}' creado con ID {Id}.", project.Name, project.Id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> UpdateAsync(Guid id, CreateProjectDto dto)
        {
            _logger.LogInformation("Actualizando proyecto {ProjectId}.", id);

            var project = await _projectRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Project), id);

            project.Name = dto.Name;
            project.Description = dto.Description;
            project.UpdatedAt = DateTime.UtcNow;

            _projectRepo.Update(project);
            await _uow.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Desactivando proyecto {ProjectId}.", id);
            var project = await _projectRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Project), id);

            project.IsActive = false;
            project.UpdatedAt = DateTime.UtcNow;
            _projectRepo.Update(project);
            await _uow.SaveChangesAsync();
        }
    }
}
