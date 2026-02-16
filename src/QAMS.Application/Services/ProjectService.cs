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
        private readonly IUserRepository _userRepo;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IProjectRepository projectRepo,
            IUserRepository userRepo,
            ICurrentUserService currentUserService,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<ProjectService> logger)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
            _currentUserService = currentUserService;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProjectDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo proyecto {ProjectId} con detalles.", id);
            var project = await _projectRepo.GetWithDetailsAsync(id)
                ?? throw new EntityNotFoundException(nameof(Project), id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todos los proyectos activos con detalles.");
            var projects = await _projectRepo.FindWithDetailsAsync(p => p.IsActive);
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            _logger.LogInformation("Creando proyecto '{Name}'. UserID: {UserId}", dto.Name, _currentUserService.UserId);

            if (await _projectRepo.AnyAsync(p => p.Name == dto.Name))
                throw new DomainException($"El proyecto '{dto.Name}' ya existe.");

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = _currentUserService.UserId,
                Priority = dto.Priority,
                ProjectStatusId = dto.ProjectStatusId > 0 ? dto.ProjectStatusId : 1 // Default: Pendiente
            };

            if (dto.TesterIds != null && dto.TesterIds.Any())
            {
                await AssignTestersAsync(project, dto.TesterIds);
            }

            await _projectRepo.AddAsync(project);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Proyecto '{Name}' creado con ID {Id}.", project.Name, project.Id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> UpdateAsync(Guid id, CreateProjectDto dto)
        {
            _logger.LogInformation("Actualizando proyecto {ProjectId}.", id);

            var project = await _projectRepo.GetWithDetailsAsync(id)
                ?? throw new EntityNotFoundException(nameof(Project), id);

            project.Name = dto.Name;
            project.Description = dto.Description;
            project.StartDate = dto.StartDate;
            project.EndDate = dto.EndDate;
            project.Priority = dto.Priority;
            project.ProjectStatusId = dto.ProjectStatusId;
            project.UpdatedAt = DateTime.UtcNow;

            if (dto.TesterIds != null)
            {
                // Sincronizar testers
                project.ProjectTesters.Clear();
                await AssignTestersAsync(project, dto.TesterIds);
            }

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

        private async Task AssignTestersAsync(Project project, List<Guid> testerIds)
        {
            foreach (var testerId in testerIds)
            {
                var user = await _userRepo.GetWithRolesAsync(testerId)
                    ?? throw new EntityNotFoundException(nameof(User), testerId);

                // Validar que el usuario tenga el rol de Tester
                // El ID del rol Tester está en SystemRoles.TesterRoleId
                if (!user.UserRoles.Any(ur => ur.RoleId == QAMS.Domain.Constants.SystemRoles.TesterRoleId))
                {
                    throw new DomainException($"El usuario {user.FullName} no tiene el rol de Tester.");
                }

                project.ProjectTesters.Add(new ProjectTester
                {
                    ProjectId = project.Id,
                    UserId = testerId,
                    AssignedAt = DateTime.UtcNow
                });
            }
        }
    }
}
