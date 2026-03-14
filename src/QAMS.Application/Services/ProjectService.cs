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
        private readonly IGenericRepository<ProjectDevolution> _devolutionRepo;
        private readonly IKanbanService _kanbanService;
        private readonly ITestExecutionRepository _execRepo;
        private readonly IObservationRepository _observationRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IProjectRepository projectRepo,
            IUserRepository userRepo,
            ICurrentUserService currentUserService,
            IKanbanService kanbanService,
            IGenericRepository<ProjectDevolution> devolutionRepo,
            ITestExecutionRepository execRepo,
            IObservationRepository observationRepo,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<ProjectService> logger)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
            _currentUserService = currentUserService;
            _kanbanService = kanbanService;
            _devolutionRepo = devolutionRepo;
            _execRepo = execRepo;
            _observationRepo = observationRepo;
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
            try
            {
                var projects = await _projectRepo.FindWithDetailsAsync(p => p.IsActive);
                return _mapper.Map<List<ProjectDto>>(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener proyectos.");
                return new List<ProjectDto>();
            }
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

            // Crear Tablero Kanban automáticamente
            await _kanbanService.CreateBoardAsync(project.Id, $"Tablero - {project.Name}");

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

        public async Task<ProjectDevolutionDto> RegisterDevolutionAsync(Guid projectId, Guid createdByUserId, RegisterDevolutionDto dto)
        {
            _logger.LogInformation("Registrando devolución para el proyecto {ProjectId}.", projectId);

            var project = await _projectRepo.GetByIdAsync(projectId)
                ?? throw new EntityNotFoundException(nameof(Project), projectId);

            // Incrementar contador
            project.DevolucionesCounter++;
            
            // Cambiar estado a DEVOLUCION (ID 5 según configuration)
            project.ProjectStatusId = 5;
            project.UpdatedAt = DateTime.UtcNow;

            // Calcular cantidad de observaciones para el reporte histórico
            var executions = await _execRepo.GetByProjectAsync(projectId);
            var executionIds = executions.Select(e => e.Id).ToList();
            var observationsCount = await _observationRepo.CountAsync(o => 
                executionIds.Contains(o.ExecutionStepResult.TestExecutionId));

            var devolution = new ProjectDevolution
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Notes = dto.Notes,
                ObservationsCount = observationsCount,
                CreatedByUserId = createdByUserId,
                CreatedAt = DateTime.UtcNow,
                DevolutionDate = DateTime.UtcNow
            };

            await _devolutionRepo.AddAsync(devolution);
            _projectRepo.Update(project);
            await _uow.SaveChangesAsync();

            var result = await _devolutionRepo.GetByIdAsync(devolution.Id);
            return _mapper.Map<ProjectDevolutionDto>(result);
        }

        public async Task<ProjectDevolutionDto> RespondToDevolutionAsync(Guid devolutionId, RespondDevolutionDto dto)
        {
            _logger.LogInformation("Respondiendo a devolución {DevolutionId}.", devolutionId);

            var devolution = await _devolutionRepo.GetByIdAsync(devolutionId)
                ?? throw new EntityNotFoundException(nameof(ProjectDevolution), devolutionId);

            devolution.ResponseNotes = dto.Response;
            devolution.ResponseDate = DateTime.UtcNow;

            _devolutionRepo.Update(devolution);
            await _uow.SaveChangesAsync();

            return _mapper.Map<ProjectDevolutionDto>(devolution);
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
