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
        IRequirementRepository requirementRepo,
        IProjectRepository projectRepo,
        IGenericRepository<TestCase> testCaseRepo,
        IGenericRepository<RequirementTestCase> reqTestCaseRepo,
        IUnitOfWork uow,
        IMapper mapper,
        ILogger<RequirementService> logger) : IRequirementService
    {
        public async Task<List<RequirementDto>> GetByProjectIdAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo requisitos para el proyecto {ProjectId}.", projectId);
            var requirements = await requirementRepo.GetByProjectWithCatalogsAsync(projectId);
            return mapper.Map<List<RequirementDto>>(requirements);
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

            var existingReqs = await requirementRepo.FindAsync(r => r.ProjectId == projectId && r.Code.ToLower() == dto.Code.Trim().ToLower());
            if (existingReqs.Any())
            {
                throw new DomainException($"El código '{dto.Code}' ya está en uso en este proyecto.");
            }

            var requirement = mapper.Map<Requirement>(dto);
            requirement.ProjectId = projectId;

            await requirementRepo.AddAsync(requirement);
            await uow.SaveChangesAsync();

            return mapper.Map<RequirementDto>(requirement);
        }

        public async Task<RequirementDto> UpdateAsync(Guid id, UpdateRequirementDto dto)
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
            requirement.RequirementStatusId = dto.RequirementStatusId;
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

        public async Task LinkTestCaseAsync(Guid requirementId, Guid testCaseId, Guid linkedByUserId)
        {
            logger.LogInformation("Vinculando caso de prueba {TestCaseId} al requisito {RequirementId}.", testCaseId, requirementId);

            var requirement = await requirementRepo.GetByIdAsync(requirementId)
                ?? throw new EntityNotFoundException(nameof(Requirement), requirementId);

            var testCase = await testCaseRepo.GetByIdAsync(testCaseId)
                ?? throw new EntityNotFoundException(nameof(TestCase), testCaseId);

            // Verificar si ya existe
            var existingLink = (await reqTestCaseRepo.FindAsync(rt => rt.RequirementId == requirementId && rt.TestCaseId == testCaseId)).FirstOrDefault();

            if (existingLink == null)
            {
                var link = new RequirementTestCase
                {
                    RequirementId = requirementId,
                    TestCaseId = testCaseId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = linkedByUserId
                };

                await reqTestCaseRepo.AddAsync(link);
                await uow.SaveChangesAsync();
                logger.LogInformation("Vinculación exitosa.");
            }
        }

        public async Task UnlinkTestCaseAsync(Guid requirementId, Guid testCaseId)
        {
            logger.LogInformation("Desvinculando caso de prueba {TestCaseId} del requisito {RequirementId}.", testCaseId, requirementId);

            var existingLink = (await reqTestCaseRepo.FindAsync(rt => rt.RequirementId == requirementId && rt.TestCaseId == testCaseId)).FirstOrDefault();

            if (existingLink != null)
            {
                reqTestCaseRepo.Delete(existingLink);
                await uow.SaveChangesAsync();
                logger.LogInformation("Desvinculación exitosa.");
            }
        }

        public async Task<List<Guid>> GetLinkedTestCaseIdsAsync(Guid requirementId)
        {
            var links = await reqTestCaseRepo.FindAsync(rt => rt.RequirementId == requirementId);
            return links.Select(rt => rt.TestCaseId).ToList();
        }
    }
}
