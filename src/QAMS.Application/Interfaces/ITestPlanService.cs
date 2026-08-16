using QAMS.Application.DTOs.TestPlans;

namespace QAMS.Application.Interfaces
{
    public interface ITestPlanService
    {
        Task<IEnumerable<TestPlanDto>> GetAllAsync();
        Task<IEnumerable<TestPlanDto>> GetByProjectAsync(Guid projectId);
        Task<IEnumerable<TestPlanDto>> GetBySutAsync(Guid sutId);
        Task<TestPlanDto> GetByIdAsync(Guid id);
        Task<TestPlanDto> CreateAsync(CreateTestPlanDto dto);
        Task<TestPlanDto> UpdateAsync(Guid id, UpdateTestPlanDto dto);
        Task ApproveAsync(Guid id, ApproveTestPlanDto dto);
        Task DeleteAsync(Guid id);
    }
}
