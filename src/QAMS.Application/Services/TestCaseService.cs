// src/QAMS.Application/Services/TestCaseService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    public class TestCaseService : ITestCaseService
    {
        private readonly ITestCaseRepository _testCaseRepo;
        private readonly ICatalogRepository<TestCasePriority> _priorityRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<TestCaseService> _logger;

        public TestCaseService(
            ITestCaseRepository testCaseRepo,
            ICatalogRepository<TestCasePriority> priorityRepo,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<TestCaseService> logger
        )
        {
            _testCaseRepo = testCaseRepo;
            _priorityRepo = priorityRepo;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TestCaseDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo caso de prueba {Id}.", id);
            var testCase =
                await _testCaseRepo.GetWithStepsAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);
            return _mapper.Map<TestCaseDto>(testCase);
        }

        public async Task<List<TestCaseDto>> GetBySuiteAsync(Guid suiteId)
        {
            _logger.LogInformation("Obteniendo casos de la suite {SuiteId}.", suiteId);
            var cases = await _testCaseRepo.GetBySuiteWithStepsAsync(suiteId);
            return _mapper.Map<List<TestCaseDto>>(cases);
        }

        public async Task<TestCaseDto> CreateAsync(CreateTestCaseDto dto)
        {
            _logger.LogInformation("Creando caso de prueba '{Title}'.", dto.Title);

            // Validar que la prioridad del catálogo exista
            var priority =
                await _priorityRepo.GetByIdAsync(dto.PriorityId)
                ?? throw new EntityNotFoundException(nameof(TestCasePriority), dto.PriorityId);

            var testCase = new TestCase
            {
                Id = Guid.NewGuid(),
                TestSuiteId = dto.TestSuiteId,
                Title = dto.Title,
                Description = dto.Description,
                Preconditions = dto.Preconditions,
                ExpectedResult = dto.ExpectedResult,
                PriorityId = dto.PriorityId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };

            // Agregar pasos secuenciales
            foreach (var stepDto in dto.Steps)
            {
                testCase.TestSteps.Add(
                    new TestStep
                    {
                        Id = Guid.NewGuid(),
                        TestCaseId = testCase.Id,
                        StepOrder = stepDto.StepOrder,
                        Action = stepDto.Action,
                        ExpectedResult = stepDto.ExpectedResult,
                    }
                );
            }

            await _testCaseRepo.AddAsync(testCase);
            await _uow.SaveChangesAsync();

            _logger.LogInformation(
                "Caso de prueba '{Title}' creado con {StepCount} pasos.",
                testCase.Title,
                testCase.TestSteps.Count
            );

            var created = await _testCaseRepo.GetWithStepsAsync(testCase.Id);
            return _mapper.Map<TestCaseDto>(created);
        }

        public async Task<TestCaseDto> UpdateAsync(Guid id, CreateTestCaseDto dto)
        {
            _logger.LogInformation("Actualizando caso {Id}.", id);

            var testCase =
                await _testCaseRepo.GetWithStepsAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);

            // Validar prioridad del catálogo
            _ = await _priorityRepo.GetByIdAsync(dto.PriorityId)
                ?? throw new EntityNotFoundException(nameof(TestCasePriority), dto.PriorityId);

            testCase.Title = dto.Title;
            testCase.Description = dto.Description;
            testCase.Preconditions = dto.Preconditions;
            testCase.ExpectedResult = dto.ExpectedResult;
            testCase.PriorityId = dto.PriorityId;
            testCase.UpdatedAt = DateTime.UtcNow;

            // Reemplazar pasos: limpiar y re-crear
            testCase.TestSteps.Clear();
            foreach (var stepDto in dto.Steps)
            {
                testCase.TestSteps.Add(
                    new TestStep
                    {
                        Id = Guid.NewGuid(),
                        TestCaseId = testCase.Id,
                        StepOrder = stepDto.StepOrder,
                        Action = stepDto.Action,
                        ExpectedResult = stepDto.ExpectedResult,
                    }
                );
            }

            _testCaseRepo.Update(testCase);
            await _uow.SaveChangesAsync();

            var updated = await _testCaseRepo.GetWithStepsAsync(id);
            return _mapper.Map<TestCaseDto>(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Desactivando caso {Id}.", id);
            var testCase =
                await _testCaseRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);

            testCase.IsActive = false;
            testCase.UpdatedAt = DateTime.UtcNow;
            _testCaseRepo.Update(testCase);
            await _uow.SaveChangesAsync();
        }
    }
}
