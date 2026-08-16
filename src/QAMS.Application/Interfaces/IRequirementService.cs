// src/QAMS.Application/Interfaces/IRequirementService.cs
using QAMS.Application.DTOs.Projects;

namespace QAMS.Application.Interfaces
{
    public interface IRequirementService
    {
        Task<List<RequirementDto>> GetByProjectIdAsync(Guid projectId);
        Task<RequirementDto> GetByIdAsync(Guid id);
        Task<RequirementDto> CreateAsync(Guid projectId, CreateRequirementDto dto);
        Task<RequirementDto> UpdateAsync(Guid id, UpdateRequirementDto dto);
        Task DeleteAsync(Guid id);

        /// <summary>Vincula un caso de prueba a un requisito (trazabilidad ISTQB)</summary>
        Task LinkTestCaseAsync(Guid requirementId, Guid testCaseId, Guid linkedByUserId);

        /// <summary>Desvincula un caso de prueba de un requisito</summary>
        Task UnlinkTestCaseAsync(Guid requirementId, Guid testCaseId);

        /// <summary>Retorna los IDs de casos de prueba vinculados a un requisito</summary>
        Task<List<Guid>> GetLinkedTestCaseIdsAsync(Guid requirementId);
    }
}
