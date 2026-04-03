// src/QAMS.Application/Services/RequirementService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    public class RequirementService(
        IGenericRepository<Requirement> requirementRepo,
        IProjectRepository projectRepo,
        IUnitOfWork uow,
        IMapper mapper,
        ILogger<RequirementService> logger) : IRequirementService
    {
        public async Task<List<RequirementDto>> GetByProjectIdAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo requisitos para el proyecto {ProjectId}.", projectId);
            var requirements = await requirementRepo.FindAsync(r => r.ProjectId == projectId);
            return mapper.Map<List<RequirementDto>>(requirements.OrderBy(r => r.CreatedAt).ToList());
        }

        public async Task<RequirementDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Obteniendo requisito {RequirementId}.", id);
            var requirement = await requirementRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Requirement), id);
            return mapper.Map<RequirementDto>(requirement);
        }

        public async Task<RequirementDto> CreateAsync(Guid projectId, CreateRequirementDto dto)
        {
            logger.LogInformation("Agregando requisito al proyecto {ProjectId}.", projectId);
            
            var project = await projectRepo.GetByIdAsync(projectId)
                ?? throw new EntityNotFoundException(nameof(Project), projectId);

            var requirement = mapper.Map<Requirement>(dto);
            requirement.ProjectId = projectId;

            await requirementRepo.AddAsync(requirement);
            await uow.SaveChangesAsync();

            return mapper.Map<RequirementDto>(requirement);
        }

        public async Task<RequirementDto> UpdateAsync(Guid id, CreateRequirementDto dto)
        {
            logger.LogInformation("Actualizando requisito {RequirementId}.", id);
            
            var requirement = await requirementRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Requirement), id);

            requirement.Title = dto.Title;
            requirement.Description = dto.Description;
            requirement.Code = dto.Code;
            requirement.AcceptanceCriteria = dto.AcceptanceCriteria;
            requirement.RequirementTypeId = dto.RequirementTypeId;
            requirement.RequirementPriorityId = dto.RequirementPriorityId;
            requirement.RequirementComplexityId = dto.RequirementComplexityId;
            requirement.Source = dto.Source;

            requirementRepo.Update(requirement);
            await uow.SaveChangesAsync();

            return mapper.Map<RequirementDto>(requirement);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation("Eliminando requisito {RequirementId}.", id);
            
            var requirement = await requirementRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Requirement), id);

            requirementRepo.Delete(requirement);
            await uow.SaveChangesAsync();
        }
    }
}
