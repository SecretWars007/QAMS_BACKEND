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
        private readonly ICatalogRepository<TestType> _testTypeRepo;
        private readonly ICurrentUserService _currentUserService;
        private readonly IKanbanService _kanbanService;
        private readonly ITestExecutionService _execService;
        private readonly IKanbanBoardRepository _kanbanBoardRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<TestCaseService> _logger;

        public TestCaseService(
            ITestCaseRepository testCaseRepo,
            ICatalogRepository<TestCasePriority> priorityRepo,
            ICatalogRepository<TestType> testTypeRepo,
            ICurrentUserService currentUserService,
            IKanbanService kanbanService,
            ITestExecutionService execService,
            IKanbanBoardRepository kanbanBoardRepo,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<TestCaseService> logger
        )
        {
            _testCaseRepo = testCaseRepo;
            _priorityRepo = priorityRepo;
            _testTypeRepo = testTypeRepo;
            _currentUserService = currentUserService;
            _kanbanService = kanbanService;
            _execService = execService;
            _kanbanBoardRepo = kanbanBoardRepo;
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

        public async Task<List<TestCaseDto>> GetByProjectIdAsync(Guid projectId)
        {
            _logger.LogInformation("Obteniendo casos del proyecto {ProjectId}.", projectId);
            var cases = await _testCaseRepo.GetByProjectIdAsync(projectId);
            return _mapper.Map<List<TestCaseDto>>(cases);
        }

        public async Task<List<TestCaseDto>> GetByProjectAndSuiteAsync(Guid projectId, Guid suiteId)
        {
            _logger.LogInformation("Obteniendo casos del proyecto {ProjectId} y suite {SuiteId}.", projectId, suiteId);
            var cases = await _testCaseRepo.GetByProjectAndSuiteAsync(projectId, suiteId);
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
                ProjectId = dto.ProjectId,
                TestSuiteId = dto.TestSuiteId,
                Title = dto.Title,
                Description = dto.Description,
                Preconditions = dto.Preconditions,
                ExpectedResult = dto.ExpectedResult,
                PriorityId = dto.PriorityId,
                EstimatedTimeHours = dto.EstimatedTimeHours,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TestTypeId = dto.TestTypeId > 0 ? dto.TestTypeId : 1, // Default: Funcional Manual
                CreatedByUserId = _currentUserService.UserId,
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
                        CreatedByUserId = _currentUserService.UserId
                    }
                );
            }

            // Agregar certificadores
            foreach (var certifierId in dto.CertifierUserIds)
            {
                testCase.Certifiers.Add(
                    new TestCaseCertifier
                    {
                        TestCaseId = testCase.Id,
                        UserId = certifierId,
                        AssignedAt = DateTime.UtcNow
                    }
                );
            }

            await _testCaseRepo.AddAsync(testCase);
            await _uow.SaveChangesAsync();

            // Registrar automáticamente en Kanban como tarea
            try
            {
                var boards = await _kanbanBoardRepo.GetByProjectAsync(testCase.ProjectId);
                var board = boards.FirstOrDefault();
                if (board != null)
                {
                    // Recargar tablero completo para tener las columnas
                    var fullBoard = await _kanbanBoardRepo.GetFullBoardAsync(board.Id);
                    var todoColumn = fullBoard?.Columns.FirstOrDefault(c => c.Name == "Por Hacer");
                    
                    if (todoColumn != null)
                    {
                        await _kanbanService.CreateTaskAsync(new QAMS.Application.DTOs.Kanban.CreateKanbanTaskDto
                        {
                            KanbanColumnId = todoColumn.Id,
                            Title = testCase.Title,
                            Description = testCase.Description,
                            TestCaseId = testCase.Id,
                            PriorityId = 2, // Normal (suponiendo catálogo standard)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear tarea Kanban automática para el caso {TestCaseId}.", testCase.Id);
                // No lanzamos excepción para no romper la creación del TestCase
            }

            // Registrar automáticamente una ejecución con estado PENDIENTE
            try
            {
                await _execService.CreateAsync(_currentUserService.UserId ?? Guid.Empty, new QAMS.Application.DTOs.TestExecutions.CreateTestExecutionDto
                {
                    TestCaseId = testCase.Id,
                    Notes = "Ejecución automática al registrar caso de prueba."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear ejecución automática para el caso {TestCaseId}.", testCase.Id);
            }

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
            testCase.EstimatedTimeHours = dto.EstimatedTimeHours;
            testCase.StartDate = dto.StartDate;
            testCase.EndDate = dto.EndDate;
            testCase.TestTypeId = dto.TestTypeId;
            testCase.UpdatedAt = DateTime.UtcNow;

            // Reemplazar pasos: mezclar para evitar violaciones de clave única en TestSteps
            var existingSteps = testCase.TestSteps.OrderBy(s => s.StepOrder).ToList();
            var incomingSteps = dto.Steps.OrderBy(s => s.StepOrder).ToList();

            for (int i = 0; i < incomingSteps.Count; i++)
            {
                var incoming = incomingSteps[i];
                if (i < existingSteps.Count)
                {
                    var existing = existingSteps[i];
                    existing.Action = incoming.Action;
                    existing.ExpectedResult = incoming.ExpectedResult;
                    existing.StepOrder = incoming.StepOrder;
                }
                else
                {
                    testCase.TestSteps.Add(
                        new TestStep
                        {
                            Id = Guid.NewGuid(),
                            TestCaseId = testCase.Id,
                            StepOrder = incoming.StepOrder,
                            Action = incoming.Action,
                            ExpectedResult = incoming.ExpectedResult,
                            CreatedByUserId = _currentUserService.UserId
                        }
                    );
                }
            }

            // Eliminar los pasos sobrantes
            for (int i = incomingSteps.Count; i < existingSteps.Count; i++)
            {
                testCase.TestSteps.Remove(existingSteps[i]);
            }

            // Reemplazar certificadores de forma segura
            var existingCertifiersIds = testCase.Certifiers.Select(c => c.UserId).ToList();
            var incomingCertifiersIds = dto.CertifierUserIds;

            var toRemove = testCase.Certifiers.Where(c => !incomingCertifiersIds.Contains(c.UserId)).ToList();
            foreach (var c in toRemove)
            {
                testCase.Certifiers.Remove(c);
            }

            foreach (var userId in incomingCertifiersIds.Where(id => !existingCertifiersIds.Contains(id)))
            {
                testCase.Certifiers.Add(
                    new TestCaseCertifier
                    {
                        TestCaseId = testCase.Id,
                        UserId = userId,
                        AssignedAt = DateTime.UtcNow
                    }
                );
            }

            _testCaseRepo.Update(testCase);
            await _uow.SaveChangesAsync();

            var updated = await _testCaseRepo.GetWithStepsAsync(id);
            return _mapper.Map<TestCaseDto>(updated);
        }

        public async Task<List<TestStepDto>> GetStepsAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo pasos del caso {Id}.", id);
            var testCase = await _testCaseRepo.GetWithStepsAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);
                
            return _mapper.Map<List<TestStepDto>>(testCase.TestSteps);
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
