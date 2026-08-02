// src/QAMS.Application/Services/ReviewService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Reviews;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    public class ReviewService(
        IReviewSessionRepository reviewRepo,
        IUserRepository userRepo,
        IProjectRepository projectRepo,
        ICatalogRepository<ReviewType> reviewTypeRepo,
        ICatalogRepository<FindingType> findingTypeRepo,
        ICatalogRepository<FindingSeverity> severityRepo,
        IEmailService emailService,
        IUnitOfWork uow,
        IMapper mapper,
        ILogger<ReviewService> logger
    ) : IReviewService
    {
        public async Task<ReviewSessionDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Obteniendo sesión de revisión {Id}.", id);
            var session = await reviewRepo.GetWithDetailsAsync(id)
                ?? throw new EntityNotFoundException(nameof(ReviewSession), id);
            return mapper.Map<ReviewSessionDto>(session);
        }

        public async Task<List<ReviewSessionDto>> GetByProjectIdAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo sesiones de revisión para proyecto {ProjectId}.", projectId);
            var sessions = await reviewRepo.GetByProjectWithDetailsAsync(projectId);
            return mapper.Map<List<ReviewSessionDto>>(sessions);
        }

        public async Task<ReviewSessionDto> CreateAsync(CreateReviewSessionDto dto)
        {
            logger.LogInformation("Creando sesión de revisión '{Title}' para proyecto {ProjectId}.", dto.Title, dto.ProjectId);

            // Validar que el proyecto exista
            var project = await projectRepo.GetByIdAsync(dto.ProjectId)
                ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            // Validar tipo de revisión
            _ = await reviewTypeRepo.GetByIdAsync(dto.ReviewTypeId)
                ?? throw new EntityNotFoundException(nameof(ReviewType), dto.ReviewTypeId);

            var session = new ReviewSession
                {
                    Id = Guid.NewGuid(),
                    ProjectId = dto.ProjectId,
                    Title = dto.Title,
                    Description = dto.Description,
                    ArtifactUnderReview = dto.ArtifactUnderReview,
                    ReviewTypeId = dto.ReviewTypeId,
                    StatusId = 1, // PLANNED
                    ScheduledDate = dto.ScheduledDate,
                    ModeratorId = dto.ModeratorId,
                    AuthorId = dto.AuthorId,
                    EntryCriteria = dto.EntryCriteria,
                    ExitCriteria = dto.ExitCriteria,
                    CreatedAt = DateTime.UtcNow
                };

            // Cargar participantes si existen
            if (dto.ParticipantUserIds != null && dto.ParticipantUserIds.Count > 0)
            {
                var users = await userRepo.GetByIdsWithRolesAsync(dto.ParticipantUserIds);
                foreach (var userId in dto.ParticipantUserIds)
                {
                    var user = users.FirstOrDefault(u => u.Id == userId)
                        ?? throw new EntityNotFoundException(nameof(User), userId);

                    session.Participants.Add(new ReviewParticipant
                    {
                        ReviewSessionId = session.Id,
                        UserId = userId,
                        Role = "Revisor",
                        Attended = false,
                        InvitedAt = DateTime.UtcNow
                    });
                }
            }

            await reviewRepo.AddAsync(session);
            await uow.SaveChangesAsync();

            // Enviar notificaciones por correo
            await SendNotificationEmailsAsync(session, "Sesión de Revisión Planificada", "Se ha programado una nueva sesión de revisión de calidad.");

            var created = await reviewRepo.GetWithDetailsAsync(session.Id);
            return mapper.Map<ReviewSessionDto>(created);
        }

        public async Task<ReviewSessionDto> StartSessionAsync(Guid id)
        {
            logger.LogInformation("Iniciando sesión de revisión {Id}.", id);
            var session = await reviewRepo.GetWithDetailsAsync(id)
                ?? throw new EntityNotFoundException(nameof(ReviewSession), id);

            if (session.StatusId != 1)
            {
                throw new DomainException("Solo se pueden iniciar sesiones en estado Planificado.");
            }

            session.StatusId = 2; // IN_PROGRESS
            session.UpdatedAt = DateTime.UtcNow;

            reviewRepo.Update(session);
            await uow.SaveChangesAsync();

            await SendNotificationEmailsAsync(session, "Sesión de Revisión Iniciada", "La sesión de revisión de calidad ha comenzado.");

            var updated = await reviewRepo.GetWithDetailsAsync(id);
            return mapper.Map<ReviewSessionDto>(updated);
        }

        public async Task<ReviewSessionDto> CompleteSessionAsync(Guid id, string conclusions, string exitCriteria)
        {
            logger.LogInformation("Completando sesión de revisión {Id}.", id);
            var session = await reviewRepo.GetWithDetailsAsync(id)
                ?? throw new EntityNotFoundException(nameof(ReviewSession), id);

            if (session.StatusId != 2)
            {
                throw new DomainException("Solo se pueden completar sesiones en estado En Progreso.");
            }

            session.StatusId = 3; // COMPLETED
            session.Conclusions = conclusions;
            session.ExitCriteria = exitCriteria;
            session.CompletedDate = DateTime.UtcNow;
            session.UpdatedAt = DateTime.UtcNow;

            reviewRepo.Update(session);
            await uow.SaveChangesAsync();

            await SendNotificationEmailsAsync(session, "Sesión de Revisión Completada", $"La sesión de revisión ha finalizado con éxito.\nConclusiones: {conclusions}");

            var updated = await reviewRepo.GetWithDetailsAsync(id);
            return mapper.Map<ReviewSessionDto>(updated);
        }

        public async Task<ReviewSessionDto> CancelSessionAsync(Guid id)
        {
            logger.LogInformation("Cancelando sesión de revisión {Id}.", id);
            var session = await reviewRepo.GetWithDetailsAsync(id)
                ?? throw new EntityNotFoundException(nameof(ReviewSession), id);

            if (session.StatusId == 3)
            {
                throw new DomainException("No se pueden cancelar sesiones ya completadas.");
            }

            session.StatusId = 4; // CANCELLED
            session.UpdatedAt = DateTime.UtcNow;

            reviewRepo.Update(session);
            await uow.SaveChangesAsync();

            await SendNotificationEmailsAsync(session, "Sesión de Revisión Cancelada", "La sesión de revisión de calidad ha sido cancelada.");

            var updated = await reviewRepo.GetWithDetailsAsync(id);
            return mapper.Map<ReviewSessionDto>(updated);
        }

        public async Task<ReviewFindingDto> AddFindingAsync(CreateReviewFindingDto dto)
        {
            logger.LogInformation("Agregando hallazgo a sesión de revisión {SessionId}.", dto.ReviewSessionId);

            var session = await reviewRepo.GetByIdAsync(dto.ReviewSessionId)
                ?? throw new EntityNotFoundException(nameof(ReviewSession), dto.ReviewSessionId);

            _ = await findingTypeRepo.GetByIdAsync(dto.FindingTypeId)
                ?? throw new EntityNotFoundException(nameof(FindingType), dto.FindingTypeId);

            _ = await severityRepo.GetByIdAsync(dto.SeverityId)
                ?? throw new EntityNotFoundException(nameof(FindingSeverity), dto.SeverityId);

            var finding = new ReviewFinding
            {
                Id = Guid.NewGuid(),
                ReviewSessionId = dto.ReviewSessionId,
                Description = dto.Description,
                Location = dto.Location,
                FindingTypeId = dto.FindingTypeId,
                SeverityId = dto.SeverityId,
                FindingStatusId = 1, // OPEN
                AssignedToId = dto.AssignedToId,
                CreatedAt = DateTime.UtcNow
            };

            await reviewRepo.AddFindingAsync(finding);
            await uow.SaveChangesAsync();

            // Enviar notificación a la persona asignada si existe
            if (finding.AssignedToId.HasValue)
            {
                var user = await userRepo.GetByIdAsync(finding.AssignedToId.Value);
                if (user != null)
                {
                    try
                    {
                        var subject = $"Nuevo Hallazgo de Revisión Asignado: {session.Title}";
                        var body = $@"<h2>Hallazgo de Revisión Asignado</h2>
                                     <p>Hola {user.FullName},</p>
                                     <p>Se te ha asignado un hallazgo durante la revisión estática.</p>
                                     <p><strong>Descripción:</strong> {finding.Description}</p>
                                     <p><strong>Ubicación:</strong> {finding.Location ?? "N/A"}</p>";
                        await emailService.SendEmailAsync(user.Email, subject, body);
                    }
                    catch (Exception ex)
                    {
                        logger.LogWarning(ex, "Error al enviar notificación de hallazgo.");
                    }
                }
            }

            var created = await reviewRepo.GetFindingByIdAsync(finding.Id);
            return mapper.Map<ReviewFindingDto>(created);
        }

        public async Task<ReviewFindingDto> UpdateFindingAsync(Guid findingId, UpdateReviewFindingDto dto)
        {
            logger.LogInformation("Actualizando hallazgo {FindingId}.", findingId);

            var finding = await reviewRepo.GetFindingByIdAsync(findingId)
                ?? throw new EntityNotFoundException(nameof(ReviewFinding), findingId);

            if (dto.Description != null) finding.Description = dto.Description;
            if (dto.Location != null) finding.Location = dto.Location;
            if (dto.FindingTypeId.HasValue) finding.FindingTypeId = dto.FindingTypeId.Value;
            if (dto.SeverityId.HasValue) finding.SeverityId = dto.SeverityId.Value;
            if (dto.FindingStatusId.HasValue) finding.FindingStatusId = dto.FindingStatusId.Value;
            if (dto.AssignedToId.HasValue) finding.AssignedToId = dto.AssignedToId;
            if (dto.Resolution != null) finding.Resolution = dto.Resolution;

            if (dto.IsResolved)
            {
                finding.FindingStatusId = 4; // RESOLVED
                finding.ResolvedAt = DateTime.UtcNow;
            }

            finding.UpdatedAt = DateTime.UtcNow;
            reviewRepo.UpdateFinding(finding);
            await uow.SaveChangesAsync();

            var updated = await reviewRepo.GetFindingByIdAsync(findingId);
            return mapper.Map<ReviewFindingDto>(updated);
        }

        public async Task DeleteFindingAsync(Guid findingId)
        {
            logger.LogInformation("Eliminando hallazgo {FindingId}.", findingId);
            var finding = await reviewRepo.GetFindingByIdAsync(findingId)
                ?? throw new EntityNotFoundException(nameof(ReviewFinding), findingId);

            reviewRepo.DeleteFinding(finding);
            await uow.SaveChangesAsync();
        }

        private async Task SendNotificationEmailsAsync(ReviewSession session, string subject, string messageContent)
        {
            try
            {
                var emails = new List<string>();
                
                // Moderator email
                if (session.ModeratorId.HasValue)
                {
                    var mod = await userRepo.GetByIdAsync(session.ModeratorId.Value);
                    if (mod != null) emails.Add(mod.Email);
                }

                // Author email
                if (session.AuthorId.HasValue)
                {
                    var aut = await userRepo.GetByIdAsync(session.AuthorId.Value);
                    if (aut != null) emails.Add(aut.Email);
                }

                // Participants emails
                if (session.Participants != null)
                {
                    foreach (var part in session.Participants)
                    {
                        if (part.User != null) emails.Add(part.User.Email);
                    }
                }

                var uniqueEmails = emails.Distinct().ToList();
                foreach (var email in uniqueEmails)
                {
                    var body = $@"<h2>Notificación de QAMS — Revisión Estática</h2>
                                 <p>{messageContent}</p>
                                 <div style='background:rgba(99,102,241,0.1);padding:15px;border-radius:8px;border-left:4px solid #6366f1;'>
                                     <p><strong>Sesión:</strong> {session.Title}</p>
                                     <p><strong>Artefacto:</strong> {session.ArtifactUnderReview ?? "N/A"}</p>
                                     <p><strong>Fecha Planificada:</strong> {session.ScheduledDate?.ToLocalTime().ToString() ?? "N/A"}</p>
                                 </div>
                                 <p><a href='https://qams-web.onrender.com/reviews'>Ver en el módulo de Revisiones QAMS</a></p>";
                    await emailService.SendEmailAsync(email, subject, body);
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Error al enviar correos de la sesión de revisión {SessionId}.", session.Id);
            }
        }
    }
}
