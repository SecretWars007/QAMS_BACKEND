using AutoMapper;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TestSuiteService> _logger;

        public TestSuiteService(
            ITestSuiteRepository testSuiteRepo,
            IProjectRepository projectRepo,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<TestSuiteService> logger)
        {
            _testSuiteRepo = testSuiteRepo;
            _projectRepo = projectRepo;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TestSuiteDto> CreateAsync(CreateTestSuiteDto dto)
        {
            _logger.LogInformation("Creando suite de pruebas '{Name}' para el proyecto {ProjectId}.", dto.Name, dto.ProjectId);
            
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
            _logger.LogInformation("Obteniendo suite de pruebas {SuiteId}.", id);
            
            var suite = await _testSuiteRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestSuite), id);
            
            return _mapper.Map<TestSuiteDto>(suite);
        }

        public async Task<List<TestSuiteDto>> GetByProjectIdAsync(Guid projectId)
        {
            _logger.LogInformation("Obteniendo suites de pruebas para proyecto {ProjectId}.", projectId);
            
            var suites = await _testSuiteRepo.GetByProjectWithTestCasesAsync(projectId);
            return _mapper.Map<List<TestSuiteDto>>(suites);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Eliminando suite de pruebas {SuiteId}.", id);
            
            var suite = await _testSuiteRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestSuite), id);

            _testSuiteRepo.Delete(suite);
            await _uow.SaveChangesAsync();
        }

        public async Task<TestSuiteDto> UpdateAsync(Guid id, CreateTestSuiteDto dto)
        {
            _logger.LogInformation("Actualizando suite de pruebas {SuiteId}.", id);
            
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
