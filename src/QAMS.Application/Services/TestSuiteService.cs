using AutoMapper;
using QAMS.Application.DTOs.TestSuites;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    public class TestSuiteService : ITestSuiteService
    {
        private readonly ITestSuiteRepository _testSuiteRepo;
        private readonly IProjectRepository _projectRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TestSuiteService(
            ITestSuiteRepository testSuiteRepo,
            IProjectRepository projectRepo,
            IUnitOfWork uow,
            IMapper mapper)
        {
            _testSuiteRepo = testSuiteRepo;
            _projectRepo = projectRepo;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TestSuiteDto> CreateAsync(CreateTestSuiteDto dto)
        {
            var project = await _projectRepo.GetByIdAsync(dto.ProjectId)
                ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            var suite = new TestSuite
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                Description = dto.Description,
                StatusId = dto.StatusId,
                CreatedAt = DateTime.UtcNow
            };

            await _testSuiteRepo.AddAsync(suite);
            await _uow.SaveChangesAsync();

            // Recargar para incluir el Status para el mapeo
            var createdSuite = await _testSuiteRepo.GetByIdAsync(suite.Id);
            return _mapper.Map<TestSuiteDto>(createdSuite);
        }

        public async Task<TestSuiteDto> GetByIdAsync(Guid id)
        {
            var suite = await _testSuiteRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestSuite), id);
            
            return _mapper.Map<TestSuiteDto>(suite);
        }

        public async Task<List<TestSuiteDto>> GetByProjectIdAsync(Guid projectId)
        {
            var suites = await _testSuiteRepo.GetByProjectWithTestCasesAsync(projectId);
            return _mapper.Map<List<TestSuiteDto>>(suites);
        }

        public async Task DeleteAsync(Guid id)
        {
            var suite = await _testSuiteRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestSuite), id);

            _testSuiteRepo.Delete(suite);
            await _uow.SaveChangesAsync();
        }

        public async Task<TestSuiteDto> UpdateAsync(Guid id, CreateTestSuiteDto dto)
        {
            var suite = await _testSuiteRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestSuite), id);

            suite.Name = dto.Name;
            suite.Description = dto.Description;
            suite.StatusId = dto.StatusId;

            _testSuiteRepo.Update(suite);
            await _uow.SaveChangesAsync();

            // Recargar para incluir el Status para el mapeo
            var updatedSuite = await _testSuiteRepo.GetByIdAsync(suite.Id);
            return _mapper.Map<TestSuiteDto>(updatedSuite);
        }
    }
}
