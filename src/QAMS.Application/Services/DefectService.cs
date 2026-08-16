// src/QAMS.Application/Services/DefectService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Defects;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de gestión de defectos.
    /// ISTQB: un defecto es la causa de un fallo en el software. Trazabilidad completa.
    /// SRP: sólo gestiona defectos.
    /// DIP: depende de IDefectRepository, no de implementaciones concretas.
    /// </summary>
    public class DefectService(
        IDefectRepository defectRepo,
        IFileStorageService fileStorage,
        IUnitOfWork uow,
        ILogger<DefectService> logger
    ) : IDefectService
    {
        public async Task<IReadOnlyList<DefectDto>> GetByProjectAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo defectos del proyecto {ProjectId}.", projectId);
            var defects = await defectRepo.GetByProjectAsync(projectId);
            return defects.Select(d => MapToDto(d, fileStorage)).ToList();
        }

        public async Task<IReadOnlyList<DefectDto>> GetByTestCaseAsync(Guid testCaseId)
        {
            logger.LogInformation("Obteniendo defectos del caso de prueba {TestCaseId}.", testCaseId);
            var defects = await defectRepo.GetByTestCaseAsync(testCaseId);
            return defects.Select(d => MapToDto(d, fileStorage)).ToList();
        }

        public async Task<DefectDto?> GetByIdAsync(Guid defectId)
        {
            var defect = await defectRepo.GetByIdAsync(defectId);
            return defect is null ? null : MapToDto(defect, fileStorage);
        }

        public async Task<DefectDto> CreateAsync(Guid reportedByUserId, CreateDefectDto dto)
        {
            logger.LogInformation("Creando defecto '{Title}' en proyecto {ProjectId}.", dto.Title, dto.ProjectId);

            var defect = new Defect
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                TestCaseId = dto.TestCaseId,
                TestExecutionId = dto.TestExecutionId,
                TestExecutionStepResultId = dto.TestExecutionStepResultId,
                Title = dto.Title,
                Description = dto.Description,
                StepsToReproduce = dto.StepsToReproduce,
                ActualResult = dto.ActualResult,
                ExpectedResult = dto.ExpectedResult,
                DefectPriorityId = dto.DefectPriorityId,
                DefectSeverityId = dto.DefectSeverityId,
                DefectStatusId = dto.DefectStatusId,
                EnvironmentInfo = dto.EnvironmentInfo,
                AttachmentUrl = dto.AttachmentUrl,
                AttachmentFileName = dto.AttachmentFileName,
                ReportedByUserId = reportedByUserId,
                AssignedToUserId = dto.AssignedToUserId,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = reportedByUserId
            };

            await defectRepo.AddAsync(defect);
            await uow.SaveChangesAsync();

            logger.LogInformation("Defecto {DefectId} creado correctamente.", defect.Id);

            // Reload con navegación
            var created = await defectRepo.GetByIdAsync(defect.Id)
                ?? throw new DomainException("Error al recuperar el defecto recién creado.");
            return MapToDto(created, fileStorage);
        }

        public async Task<DefectDto> UpdateAsync(Guid defectId, UpdateDefectDto dto)
        {
            logger.LogInformation("Actualizando defecto {DefectId}.", defectId);

            var defect = await defectRepo.GetByIdAsync(defectId)
                ?? throw new DomainException($"Defecto {defectId} no encontrado.");

            if (dto.Title is not null) defect.Title = dto.Title;
            if (dto.Description is not null) defect.Description = dto.Description;
            if (dto.StepsToReproduce is not null) defect.StepsToReproduce = dto.StepsToReproduce;
            if (dto.ActualResult is not null) defect.ActualResult = dto.ActualResult;
            if (dto.ExpectedResult is not null) defect.ExpectedResult = dto.ExpectedResult;
            if (dto.DefectPriorityId.HasValue) defect.DefectPriorityId = dto.DefectPriorityId.Value;
            if (dto.DefectSeverityId.HasValue) defect.DefectSeverityId = dto.DefectSeverityId.Value;
            if (dto.AssignedToUserId.HasValue) defect.AssignedToUserId = dto.AssignedToUserId;
            if (dto.EnvironmentInfo is not null) defect.EnvironmentInfo = dto.EnvironmentInfo;
            if (dto.AttachmentUrl is not null) defect.AttachmentUrl = dto.AttachmentUrl;
            if (dto.AttachmentFileName is not null) defect.AttachmentFileName = dto.AttachmentFileName;
            if (dto.ResolutionNotes is not null) defect.ResolutionNotes = dto.ResolutionNotes;

            // Transición de estado: si se resuelve, registramos la fecha
            if (dto.DefectStatusId.HasValue)
            {
                defect.DefectStatusId = dto.DefectStatusId.Value;
                if (dto.DefectStatusId.Value == 3) // RESOLVED
                    defect.ResolvedAt = DateTime.UtcNow;
            }

            defect.UpdatedAt = DateTime.UtcNow;

            defectRepo.Update(defect);
            await uow.SaveChangesAsync();

            var updated = await defectRepo.GetByIdAsync(defectId)
                ?? throw new DomainException("Error al recuperar el defecto actualizado.");
            return MapToDto(updated, fileStorage);
        }

        public async Task<DefectDto> UploadAttachmentAsync(Guid defectId, Stream fileStream, string fileName, string contentType)
        {
            logger.LogInformation("Subiendo adjunto para defecto {DefectId}.", defectId);

            var defect = await defectRepo.GetByIdAsync(defectId)
                ?? throw new DomainException($"Defecto {defectId} no encontrado.");

            var filePath = await fileStorage.SaveFileAsync(fileStream, fileName, $"defects/{defectId}");
            defect.AttachmentUrl = fileStorage.GetFileUrl(filePath);
            defect.AttachmentFileName = fileName;
            defect.UpdatedAt = DateTime.UtcNow;

            defectRepo.Update(defect);
            await uow.SaveChangesAsync();

            var updated = await defectRepo.GetByIdAsync(defectId)
                ?? throw new DomainException("Error al recuperar el defecto actualizado.");
            return MapToDto(updated, fileStorage);
        }

        public async Task DeleteAsync(Guid defectId)
        {
            logger.LogInformation("Eliminando defecto {DefectId}.", defectId);
            var defect = await defectRepo.GetByIdAsync(defectId)
                ?? throw new DomainException($"Defecto {defectId} no encontrado.");

            defect.IsDeleted = true;
            defect.DeletedAt = DateTime.UtcNow;
            defectRepo.Update(defect);
            await uow.SaveChangesAsync();
        }

        private static DefectDto MapToDto(Defect d, IFileStorageService fileStorage)
        {
            var attachmentUrl = d.AttachmentUrl;
            if (!string.IsNullOrEmpty(attachmentUrl) && !attachmentUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) && !attachmentUrl.StartsWith("/"))
            {
                attachmentUrl = fileStorage.GetFileUrl(attachmentUrl);
            }

            return new DefectDto
            {
                Id = d.Id,
                ProjectId = d.ProjectId,
                ProjectName = d.Project?.Name ?? string.Empty,
                TestCaseId = d.TestCaseId,
                TestCaseTitle = d.TestCase?.Title,
                TestExecutionId = d.TestExecutionId,
                TestExecutionStepResultId = d.TestExecutionStepResultId,
                Title = d.Title,
                Description = d.Description,
                StepsToReproduce = d.StepsToReproduce,
                ActualResult = d.ActualResult,
                ExpectedResult = d.ExpectedResult,
                DefectPriorityId = d.DefectPriorityId,
                DefectPriorityCode = d.DefectPriority?.Code ?? string.Empty,
                DefectPriorityName = d.DefectPriority?.Name ?? string.Empty,
                DefectSeverityId = d.DefectSeverityId,
                DefectSeverityCode = d.DefectSeverity?.Code ?? string.Empty,
                DefectSeverityName = d.DefectSeverity?.Name ?? string.Empty,
                EnvironmentInfo = d.EnvironmentInfo,
                AttachmentUrl = attachmentUrl,
                AttachmentFileName = d.AttachmentFileName,
                DefectStatusId = d.DefectStatusId,
                DefectStatusCode = d.DefectStatus?.Code ?? string.Empty,
                DefectStatusName = d.DefectStatus?.Name ?? string.Empty,
                ReportedByUserId = d.ReportedByUserId,
                ReportedByUserName = d.ReportedBy?.FullName ?? d.ReportedBy?.Username ?? string.Empty,
                AssignedToUserId = d.AssignedToUserId,
                AssignedToUserName = d.AssignedTo?.FullName ?? d.AssignedTo?.Username,
                ResolvedAt = d.ResolvedAt,
                ResolutionNotes = d.ResolutionNotes,
                CreatedAt = d.CreatedAt
            };
        }
    }
}
