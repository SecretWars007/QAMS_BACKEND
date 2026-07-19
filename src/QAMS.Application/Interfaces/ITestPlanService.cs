using QAMS.Application.DTOs.TestPlans;

namespace QAMS.Application.Interfaces
{
    public interface ITestPlanService
    {
        Task<IEnumerable<TestPlanDto>> GetAllAsync();
        Task<IEnumerable<TestPlanDto>> GetByProjectAsync(Guid projectId);
        Task<TestPlanDto> GetByIdAsync(Guid id);
        Task<TestPlanDto> CreateAsync(CreateTestPlanDto dto);
        Task<TestPlanDto> UpdateAsync(Guid id, UpdateTestPlanDto dto);
        Task DeleteAsync(Guid id);
    }
}
