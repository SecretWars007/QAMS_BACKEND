// src/QAMS.Application/Services/ProjectService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using System.Linq;

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
        private readonly QAMS.Domain.Ports.Services.IEmailService _emailService;
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
            QAMS.Domain.Ports.Services.IEmailService emailService,
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
            _emailService = emailService;
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
            
            // Send email notification to testers and creator
            await NotifyProjectTestersAsync(project, "Creado", "GetProjectCreatedEmailHtml");

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

            // Send update notification
            await NotifyProjectTestersAsync(project, "Actualizado", "GetProjectUpdatedEmailHtml");

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

            // Send delete notification BEFORE saving changes isn't strictly necessary, 
            // but we send it to alert them it is inactive via DB
            await NotifyProjectTestersAsync(project, "Desactivado/Eliminado", "GetProjectDeletedEmailHtml");
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

            // Send devolution notification to creator
            try 
            {
                if (project.CreatedByUserId.HasValue)
                {
                    var creator = await _userRepo.GetByIdAsync(project.CreatedByUserId.Value);
                    if (creator != null) 
                    {
                        var subject = $"Nueva Devolución en el proyecto: {project.Name}";
                        var body = $@"<h2>Devolución Registrada</h2>
                                    <p>Se ha registrado una nueva devolución en tu proyecto <strong>{project.Name}</strong>.</p>
                                    <p><strong>Notas:</strong> {dto.Notes}</p>
                                    <p><a href='https://qams-web.onrender.com/dashboard'>Ver en QAMS</a></p>";
                        await _emailService.SendEmailAsync(creator.Email, subject, body);
                    }
                }
            }
            catch(Exception ex) { _logger.LogWarning(ex, "Error sending devolution email"); }

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

            // Send response notification
            try 
            {
                var responder = await _userRepo.GetByIdAsync(devolution.CreatedByUserId);
                if (responder != null) 
                {
                    var project = await _projectRepo.GetByIdAsync(devolution.ProjectId);
                    var subject = $"Respuesta a Devolución: {project?.Name}";
                    var body = $@"<h2>Respuesta de Devolución</h2>
                                <p>Se ha respondido a la devolución en el proyecto <strong>{project?.Name}</strong>.</p>
                                <p><strong>Respuesta:</strong> {dto.Response}</p>";
                    await _emailService.SendEmailAsync(responder.Email, subject, body);
                }
            }
            catch(Exception ex) { _logger.LogWarning(ex, "Error sending devolution response email"); }

            return _mapper.Map<ProjectDevolutionDto>(devolution);
        }

        private async Task AssignTestersAsync(Project project, List<Guid> testerIds)
        {
            var testers = await _userRepo.GetByIdsWithRolesAsync(testerIds);
            
            foreach (var testerId in testerIds)
            {
                var user = testers.FirstOrDefault(u => u.Id == testerId)
                    ?? throw new EntityNotFoundException(nameof(User), testerId);

                // Validar que el usuario tenga el rol de Tester
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

        public async Task<List<ProjectDto>> GetMyProjectsAsync(Guid userId)
        {
            _logger.LogInformation("Obteniendo mis proyectos para UserId {UserId}", userId);
            // Proyectos donde el usuario es el creador o es un tester asignado
            var projects = await _projectRepo.FindWithDetailsAsync(p => 
                p.IsActive && (p.CreatedByUserId == userId || p.ProjectTesters.Any(pt => pt.UserId == userId)));
            
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        private async Task NotifyProjectTestersAsync(Project project, string actionName, string templateName)
        {
            try
            {
                var testerIds = project.ProjectTesters.Select(pt => pt.UserId).ToList();
                
                if (project.CreatedByUserId.HasValue)
                {
                    testerIds.Add(project.CreatedByUserId.Value);
                }

                var uniqueTesterIds = testerIds.Distinct().ToList();

                var users = await _userRepo.GetByIdsWithRolesAsync(uniqueTesterIds);

                foreach (var user in users)
                {
                    string htmlBody = templateName switch
                    {
                        "GetProjectCreatedEmailHtml" => QAMS.Application.Templates.EmailTemplates.GetProjectCreatedEmailHtml(user.FullName, project.Name, project.Id.ToString()),
                        "GetProjectUpdatedEmailHtml" => QAMS.Application.Templates.EmailTemplates.GetProjectUpdatedEmailHtml(user.FullName, project.Name),
                        "GetProjectDeletedEmailHtml" => QAMS.Application.Templates.EmailTemplates.GetProjectDeletedEmailHtml(user.FullName, project.Name),
                        _ => string.Empty
                    };

                    if (!string.IsNullOrEmpty(htmlBody))
                    {
                        var subject = templateName switch
                        {
                            "GetProjectCreatedEmailHtml" => $"Nuevo Proyecto Asignado: {project.Name}",
                            _ => $"Proyecto {actionName}: {project.Name}"
                        };
                        await _emailService.SendEmailAsync(user.Email, subject, htmlBody);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send project notification emails for Project {ProjectId}", project.Id);
            }
        }
    }
}
