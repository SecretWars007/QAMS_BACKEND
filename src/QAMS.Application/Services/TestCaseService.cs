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
    public class TestCaseService(
        ITestCaseRepository testCaseRepo,
        ICatalogRepository<TestCasePriority> priorityRepo,
        ICurrentUserService currentUserService,
        IKanbanService kanbanService,
        ITestExecutionService execService,
        IKanbanBoardRepository kanbanBoardRepo,
        IUnitOfWork uow,
        IMapper mapper,
        ILogger<TestCaseService> logger
    ) : ITestCaseService
    {

        public async Task<TestCaseDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Obteniendo caso de prueba {Id}.", id);
            var testCase =
                await testCaseRepo.GetWithStepsAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);
            return mapper.Map<TestCaseDto>(testCase);
        }

        public async Task<List<TestCaseDto>> GetBySuiteAsync(Guid suiteId)
        {
            logger.LogInformation("Obteniendo casos de la suite {SuiteId}.", suiteId);
            var cases = await testCaseRepo.GetBySuiteWithStepsAsync(suiteId);
            return mapper.Map<List<TestCaseDto>>(cases);
        }

        public async Task<List<TestCaseDto>> GetByProjectIdAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo casos del proyecto {ProjectId}.", projectId);
            var cases = await testCaseRepo.GetByProjectIdAsync(projectId);
            return mapper.Map<List<TestCaseDto>>(cases);
        }

        public async Task<List<TestCaseDto>> GetByProjectAndSuiteAsync(Guid projectId, Guid suiteId)
        {
            logger.LogInformation("Obteniendo casos del proyecto {ProjectId} y suite {SuiteId}.", projectId, suiteId);
            var cases = await testCaseRepo.GetByProjectAndSuiteAsync(projectId, suiteId);
            return mapper.Map<List<TestCaseDto>>(cases);
        }

        public async Task<TestCaseDto> CreateAsync(CreateTestCaseDto dto)
        {
            logger.LogInformation("Creando caso de prueba '{Title}'.", dto.Title);

            // Validar que la prioridad del catálogo exista
            var priority =
                await priorityRepo.GetByIdAsync(dto.PriorityId)
                ?? throw new EntityNotFoundException(nameof(TestCasePriority), dto.PriorityId);

            var testCase = new TestCase
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                TestSuiteId = dto.TestSuiteId,
                Title = dto.Title,
                Description = dto.Description,
                Preconditions = dto.Preconditions ?? string.Empty,
                ExpectedResult = dto.ExpectedResult,
                Postconditions = dto.Postconditions,
                PriorityId = dto.PriorityId,
                EstimatedTimeHours = dto.EstimatedTimeHours,
                IsBdd = dto.IsBdd,
                BddScenario = dto.BddScenario,
                ImpactLevel = dto.ImpactLevel > 0 ? dto.ImpactLevel : 3,
                LikelihoodLevel = dto.LikelihoodLevel > 0 ? dto.LikelihoodLevel : 3,
                TestTypeId = dto.TestTypeId > 0 ? dto.TestTypeId : 1, // Default: Funcional Manual
                DesignTechniqueId = dto.DesignTechniqueId,
                CreatedByUserId = currentUserService.UserId,
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
                        CreatedByUserId = currentUserService.UserId
                    }
                );
            }



            // Asociar Requisitos (trazabilidad)
            if (dto.RequirementIds != null)
            {
                foreach (var reqId in dto.RequirementIds)
                {
                    testCase.RequirementTestCases.Add(new RequirementTestCase
                    {
                        RequirementId = reqId,
                        TestCaseId = testCase.Id
                    });
                }
            }

            await testCaseRepo.AddAsync(testCase);
            await uow.SaveChangesAsync();

            // Registrar automáticamente en Kanban como tarea
            try
            {
                var boards = await kanbanBoardRepo.GetByProjectAsync(testCase.ProjectId);
                var board = boards is { Count: > 0 } ? boards[0] : null;
                if (board != null)
                {
                    // Recargar tablero completo para tener las columnas
                    var fullBoard = await kanbanBoardRepo.GetFullBoardAsync(board.Id);
                    var todoColumn = fullBoard?.Columns.FirstOrDefault(c => c.Name == "Por Hacer");

                    if (todoColumn != null)
                    {
                        await kanbanService.CreateTaskAsync(new QAMS.Application.DTOs.Kanban.CreateKanbanTaskDto
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
                logger.LogError(ex, "Error al crear tarea Kanban automática para el caso {TestCaseId}.", testCase.Id);
                // No lanzamos excepción para no romper la creación del TestCase
            }

            // Registrar automáticamente una ejecución con estado PENDIENTE
            try
            {
                await execService.CreateAsync(currentUserService.UserId ?? Guid.Empty, new QAMS.Application.DTOs.TestExecutions.CreateTestExecutionDto
                {
                    TestCaseId = testCase.Id,
                    Notes = "Ejecución automática al registrar caso de prueba."
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear ejecución automática para el caso {TestCaseId}.", testCase.Id);
            }

            logger.LogInformation(
                "Caso de prueba '{Title}' creado con {StepCount} pasos.",
                testCase.Title,
                testCase.TestSteps.Count
            );

            var created = await testCaseRepo.GetWithStepsAsync(testCase.Id);
            return mapper.Map<TestCaseDto>(created);
        }

        public async Task<TestCaseDto> UpdateAsync(Guid id, CreateTestCaseDto dto)
        {
            logger.LogInformation("Actualizando caso {Id}.", id);

            var oldTestCase =
                await testCaseRepo.GetWithStepsAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);

            // Validar prioridad del catálogo
            _ = await priorityRepo.GetByIdAsync(dto.PriorityId)
                ?? throw new EntityNotFoundException(nameof(TestCasePriority), dto.PriorityId);

            // Marcar versión antigua como obsoleta y solo lectura
            oldTestCase.IsLatestVersion = false;
            oldTestCase.IsActive = false; // Se desactiva la versión antigua
            oldTestCase.UpdatedAt = DateTime.UtcNow;
            oldTestCase.UpdatedByUserId = currentUserService.UserId;
            testCaseRepo.Update(oldTestCase);

            // Crear nueva versión clonando datos
            var newTestCase = new TestCase
            {
                Id = Guid.NewGuid(),
                ParentTestCaseId = oldTestCase.Id,
                VersionNumber = oldTestCase.VersionNumber + 1,
                IsLatestVersion = true,
                ProjectId = oldTestCase.ProjectId,
                TestSuiteId = oldTestCase.TestSuiteId,
                Title = dto.Title,
                Description = dto.Description,
                Preconditions = dto.Preconditions ?? string.Empty,
                ExpectedResult = dto.ExpectedResult,
                Postconditions = dto.Postconditions,
                PriorityId = dto.PriorityId,
                EstimatedTimeHours = dto.EstimatedTimeHours,
                IsBdd = dto.IsBdd,
                BddScenario = dto.BddScenario,
                ImpactLevel = dto.ImpactLevel > 0 ? dto.ImpactLevel : oldTestCase.ImpactLevel,
                LikelihoodLevel = dto.LikelihoodLevel > 0 ? dto.LikelihoodLevel : oldTestCase.LikelihoodLevel,
                TestTypeId = dto.TestTypeId > 0 ? dto.TestTypeId : oldTestCase.TestTypeId,
                DesignTechniqueId = dto.DesignTechniqueId,
                IsActive = oldTestCase.IsActive,
                CreatedByUserId = currentUserService.UserId,
                CreatedAt = DateTime.UtcNow
            };

            // Asociar Requisitos (trazabilidad)
            var reqIdsToUse = dto.RequirementIds != null && dto.RequirementIds.Count > 0
                ? dto.RequirementIds
                : oldTestCase.RequirementTestCases?.Select(rtc => rtc.RequirementId).ToList() ?? [];

            foreach (var reqId in reqIdsToUse)
            {
                newTestCase.RequirementTestCases.Add(new RequirementTestCase
                {
                    RequirementId = reqId,
                    TestCaseId = newTestCase.Id
                });
            }

            // Copiar pasos
            var incomingSteps = dto.Steps.OrderBy(s => s.StepOrder).ToList();
            foreach (var incoming in incomingSteps)
            {
                newTestCase.TestSteps.Add(
                    new TestStep
                    {
                        TestCaseId = newTestCase.Id,
                        StepOrder = incoming.StepOrder,
                        Action = incoming.Action,
                        ExpectedResult = incoming.ExpectedResult,
                        CreatedByUserId = currentUserService.UserId
                    }
                );
            }



            await testCaseRepo.AddAsync(newTestCase);
            await uow.SaveChangesAsync();

            // Registrar automáticamente en Kanban la nueva versión
            try
            {
                var boards = await kanbanBoardRepo.GetByProjectAsync(newTestCase.ProjectId);
                var board = boards is { Count: > 0 } ? boards[0] : null;
                if (board != null)
                {
                    var fullBoard = await kanbanBoardRepo.GetFullBoardAsync(board.Id);
                    var todoColumn = fullBoard?.Columns.FirstOrDefault(c => c.Name == "Por Hacer");

                    if (todoColumn != null)
                    {
                        await kanbanService.CreateTaskAsync(new QAMS.Application.DTOs.Kanban.CreateKanbanTaskDto
                        {
                            KanbanColumnId = todoColumn.Id,
                            Title = newTestCase.Title + " (v" + newTestCase.VersionNumber + ")",
                            Description = newTestCase.Description,
                            TestCaseId = newTestCase.Id,
                            PriorityId = 2,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear tarea Kanban para la nueva versión {TestCaseId}.", newTestCase.Id);
            }

            // Registrar ejecución automática
            try
            {
                await execService.CreateAsync(currentUserService.UserId ?? Guid.Empty, new QAMS.Application.DTOs.TestExecutions.CreateTestExecutionDto
                {
                    TestCaseId = newTestCase.Id,
                    Notes = "Ejecución automática al generar nueva versión."
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear ejecución automática para la versión {TestCaseId}.", newTestCase.Id);
            }

            var created = await testCaseRepo.GetWithStepsAsync(newTestCase.Id);
            return mapper.Map<TestCaseDto>(created);
        }

        public async Task<List<TestStepDto>> GetStepsAsync(Guid id)
        {
            logger.LogInformation("Obteniendo pasos del caso {Id}.", id);
            var testCase = await testCaseRepo.GetWithStepsAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);

            return mapper.Map<List<TestStepDto>>(testCase.TestSteps);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation("Desactivando caso {Id}.", id);
            var testCase =
                await testCaseRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestCase), id);

            testCaseRepo.Delete(testCase);
            await uow.SaveChangesAsync();
        }
    }
}
