// src/QAMS.Application/Services/TestExecutionService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestExecutions;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio completo de ejecución de pruebas: crear ejecución,
    /// registrar resultados por paso, subir evidencias y completar ejecución.
    /// </summary>
    public class TestExecutionService(
        ITestExecutionRepository execRepo,
        ITestCaseRepository testCaseRepo,
        IProjectRepository projectRepo,
        IEvidenceRepository evidenceRepo,
        ICatalogRepository<ExecutionStatus> execStatusRepo,
        ICatalogRepository<StepResultStatus> stepStatusRepo,
        ICatalogRepository<EvidenceType> evidenceTypeRepo,
        IObservationRepository observationRepo,
        IGenericRepository<KanbanTask> kanbanTaskRepo,
        IGenericRepository<KanbanColumn> kanbanColumnRepo,
        IFileStorageService fileStorage,
        IUnitOfWork uow,
        IMapper mapper,
        ILogger<TestExecutionService> logger
    ) : ITestExecutionService
    {

        public async Task<TestExecutionDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Obteniendo ejecución {Id}.", id);
            var execution =
                await execRepo.GetFullExecutionAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestExecution), id);

            var dto = mapper.Map<TestExecutionDto>(execution);
            // Asignar URLs de evidencias globales
            foreach (var evidence in dto.Evidences)
            {
                var entity = execution.Evidences.First(e => e.Id == evidence.Id);
                evidence.FileUrl = fileStorage.GetFileUrl(entity.FilePath);
            }

            // Asignar URLs de evidencias por paso
            foreach (var stepResult in dto.StepResults)
            {
                var entityStep = execution.StepResults.First(sr => sr.Id == stepResult.Id);
                foreach (var evidence in stepResult.Evidences)
                {
                    var entityEv = entityStep.Evidences.First(e => e.Id == evidence.Id);
                    evidence.FileUrl = fileStorage.GetFileUrl(entityEv.FilePath);
                }
            }
            return dto;
        }

        public async Task<List<TestExecutionDto>> GetByTestCaseAsync(Guid testCaseId)
        {
            logger.LogInformation("Obteniendo ejecuciones del caso {TestCaseId}.", testCaseId);
            var executions = await execRepo.GetByTestCaseAsync(testCaseId);
            return mapper.Map<List<TestExecutionDto>>(executions);
        }

        public async Task<List<TestExecutionDto>> GetByTesterAsync(Guid testerId)
        {
            logger.LogInformation("Obteniendo ejecuciones del tester {TesterId}.", testerId);
            var executions = await execRepo.GetByTesterAsync(testerId);
            return mapper.Map<List<TestExecutionDto>>(executions);
        }

        public async Task<List<TestExecutionDto>> GetFilteredExecutionsAsync(Guid? testCaseId, Guid? projectId, Guid? testSuiteId, Guid? testPlanId)
        {
            logger.LogInformation("Obteniendo ejecuciones filtradas.");
            var executions = await execRepo.GetFilteredExecutionsAsync(testCaseId, projectId, testSuiteId, testPlanId);
            return mapper.Map<List<TestExecutionDto>>(executions);
        }

        /// <summary>
        /// Crea una nueva ejecución para un caso de prueba.
        /// Inicializa todos los pasos con estado NOT_EXECUTED.
        /// </summary>
        public async Task<TestExecutionDto> CreateAsync(Guid testerId, CreateTestExecutionDto dto)
        {
            logger.LogInformation(
                "Creando ejecución para caso {TestCaseId} por tester {TesterId}.",
                dto.TestCaseId,
                testerId
            );

            // Obtener el caso de prueba con sus pasos
            var testCase =
                await testCaseRepo.GetWithStepsAsync(dto.TestCaseId)
                ?? throw new EntityNotFoundException(nameof(TestCase), dto.TestCaseId);

            // Obtener el estado PENDING del catálogo
            var pendingStatus =
                await execStatusRepo.GetByCodeAsync("PENDING")
                ?? throw new DomainException("Estado 'PENDING' no encontrado en catálogo.");

            // Obtener el estado NOT_EXECUTED para los pasos
            var notExecutedStatus =
                await stepStatusRepo.GetByCodeAsync("NOT_EXECUTED")
                ?? throw new DomainException("Estado 'NOT_EXECUTED' no encontrado en catálogo.");

            // Calcular número de ciclo secuencial
            var executions = await execRepo.GetByTestCaseAsync(dto.TestCaseId);
            var nextCycleNumber = executions.Any() ? executions.Max(e => e.CycleNumber) + 1 : 1;

            var execution = new TestExecution
            {
                Id = Guid.NewGuid(),
                TestCaseId = dto.TestCaseId,
                TestPlanId = dto.TestPlanId,
                TesterId = (dto.TesterId.HasValue && dto.TesterId.Value != Guid.Empty) ? dto.TesterId.Value : testerId,
                StatusId = pendingStatus.Id,
                Notes = dto.Notes,
                ActualTimeHours = dto.ActualTimeHours ?? 0m,
                ExecutionDate = DateTime.UtcNow,
                CycleNumber = nextCycleNumber,
            };

            // Determinar si hay resultados proporcionados y su influencia en el estado
            var hasInputResults = dto.StepResults != null && dto.StepResults.Count > 0;
            var inputStepResults = dto.StepResults?.ToDictionary(sr => sr.TestStepId) ?? [];

            // Pre-crear resultado de cada paso
            foreach (var step in testCase.TestSteps)
            {
                var input = inputStepResults.GetValueOrDefault(step.Id);

                execution.StepResults.Add(
                    new ExecutionStepResult
                    {
                        Id = Guid.NewGuid(),
                        TestExecutionId = execution.Id,
                        TestStepId = step.Id,
                        StatusId = input?.StatusId ?? notExecutedStatus.Id,
                        ActualResult = input?.ActualResult,
                        Notes = input?.Notes,
                        EvaluatedAt = DateTime.UtcNow,
                    }
                );
            }

            // Si se pasaron resultados, cambiar el estado global a IN_PROGRESS (mínimo)
            if (hasInputResults)
            {
                var inProgressStatus = await execStatusRepo.GetByCodeAsync("IN_PROGRESS");
                execution.StatusId = inProgressStatus!.Id;

                // Opcional: Podríamos re-evaluar si ya terminó (PASSED/FAILED) 
                // pero por consistencia con el flujo normal de POST simple, lo dejamos en IN_PROGRESS
                // El endpoint /complete es el que hace la evaluación exhaustiva.
            }

            await execRepo.AddAsync(execution);

            // Actualizar el último ciclo en el caso de prueba
            testCase.LastCycleNumber = nextCycleNumber;
            testCaseRepo.Update(testCase);

            await uow.SaveChangesAsync();

            // Sincronizar estado con el TestCase y Kanban
            await SyncTestCaseStatusAsync(execution.TestCaseId, execution.StatusId);
            await SyncKanbanTaskAsync(execution.TestCaseId, execution.TesterId, execution.StatusId);

            logger.LogInformation(
                "Ejecución {ExecId} creada con {StepCount} pasos.",
                execution.Id,
                execution.StepResults.Count
            );

            var created = await execRepo.GetFullExecutionAsync(execution.Id);
            return mapper.Map<TestExecutionDto>(created);
        }

        /// <summary>
        /// Crea una ejecución completa con todos los resultados de pasos proporcionados.
        /// Valida que todos los TestStepId correspondan al TestCase.
        /// </summary>
        public async Task<TestExecutionDto> CreateCompleteAsync(Guid testerId, CreateCompleteExecutionDto dto)
        {
            logger.LogInformation(
                "Creando ejecución completa para caso {TestCaseId} por tester {TesterId} con {StepCount} resultados.",
                dto.TestCaseId,
                testerId,
                dto.StepResults.Count
            );

            // Obtener el caso de prueba con sus pasos
            var testCase =
                await testCaseRepo.GetWithStepsAsync(dto.TestCaseId)
                ?? throw new EntityNotFoundException(nameof(TestCase), dto.TestCaseId);

            // Validar que todos los TestStepId proporcionados existen en el TestCase
            var testStepIds = testCase.TestSteps.Select(s => s.Id).ToHashSet();
            var invalidStepIds = dto.StepResults
                .Select(sr => sr.TestStepId)
                .Where(id => !testStepIds.Contains(id))
                .ToList();

            if (invalidStepIds.Count > 0)
            {
                throw new DomainException(
                    $"Los siguientes TestStepId no pertenecen al caso de prueba: {string.Join(", ", invalidStepIds)}"
                );
            }

            // Validar que todos los StatusId existen en el catálogo
            var uniqueStatusIds = dto.StepResults.Select(sr => sr.StatusId).Distinct().ToList();
            foreach (var statusId in uniqueStatusIds)
            {
                _ = await stepStatusRepo.GetByIdAsync(statusId)
                    ?? throw new EntityNotFoundException(nameof(StepResultStatus), statusId);
            }

            // Determinar el estado de la ejecución basado en los resultados de los pasos
            var passedStatus = await stepStatusRepo.GetByCodeAsync("PASSED");
            var failedStatus = await stepStatusRepo.GetByCodeAsync("FAILED");

            var allPassed = dto.StepResults.All(sr => sr.StatusId == passedStatus!.Id);
            var anyFailed = dto.StepResults.Any(sr => sr.StatusId == failedStatus!.Id);

            var executionStatusCode =
                anyFailed ? "FAILED" :
                allPassed ? "PASSED" :
                "IN_PROGRESS";

            var executionStatus =
                await execStatusRepo.GetByCodeAsync(executionStatusCode)
                ?? throw new DomainException($"Estado '{executionStatusCode}' no encontrado en catálogo.");

            // Calcular número de ciclo secuencial
            var executionsComplete = await execRepo.GetByTestCaseAsync(dto.TestCaseId);
            var nextCycleNumberComplete = executionsComplete.Any() ? executionsComplete.Max(e => e.CycleNumber) + 1 : 1;

            var execution = new TestExecution
            {
                Id = Guid.NewGuid(),
                TestCaseId = dto.TestCaseId,
                TestPlanId = dto.TestPlanId,
                TesterId = (dto.TesterId.HasValue && dto.TesterId.Value != Guid.Empty) ? dto.TesterId.Value : testerId,
                StatusId = executionStatus.Id,
                Notes = dto.Notes,
                ActualTimeHours = dto.ActualTimeHours ?? 0m,
                ExecutionDate = DateTime.UtcNow,
                CompletedAt = (allPassed || anyFailed) ? DateTime.UtcNow : null,
                CycleNumber = nextCycleNumberComplete
            };

            if (allPassed || anyFailed)
            {
                // Si ya terminó al crearse (CreateComplete), actualizar horas del proyecto
                await SyncProjectHoursAsync(testCase.ProjectId);
            }

            // Crear resultados de pasos con los datos proporcionados
            foreach (var stepResult in dto.StepResults)
            {
                execution.StepResults.Add(
                    new ExecutionStepResult
                    {
                        Id = Guid.NewGuid(),
                        TestExecutionId = execution.Id,
                        TestStepId = stepResult.TestStepId,
                        StatusId = stepResult.StatusId,
                        ActualResult = stepResult.ActualResult,
                        Notes = stepResult.Notes,
                        EvaluatedAt = DateTime.UtcNow,
                    }
                );
            }

            await execRepo.AddAsync(execution);

            // Actualizar el último ciclo en el caso de prueba
            testCase.LastCycleNumber = nextCycleNumberComplete;
            testCaseRepo.Update(testCase);

            await uow.SaveChangesAsync();

            // Sincronizar estado con el TestCase y Kanban
            await SyncTestCaseStatusAsync(execution.TestCaseId, execution.StatusId);
            await SyncKanbanTaskAsync(execution.TestCaseId, execution.TesterId, execution.StatusId);

            logger.LogInformation(
                "Ejecución completa {ExecId} creada con estado {Status} y {StepCount} resultados.",
                execution.Id,
                executionStatusCode,
                execution.StepResults.Count
            );

            var created = await execRepo.GetFullExecutionAsync(execution.Id);
            return mapper.Map<TestExecutionDto>(created);
        }

        /// <summary>
        /// Actualiza el resultado de un paso específico durante la ejecución.
        /// Cambia el estado de la ejecución a IN_PROGRESS si estaba PENDING.
        /// </summary>
        public async Task<TestExecutionDto> UpdateStepResultAsync(
            Guid executionId,
            UpdateStepResultDto dto
        )
        {
            logger.LogInformation(
                "Actualizando paso {StepId} de ejecución {ExecId}.",
                dto.TestStepId,
                executionId
            );

            var execution =
                await execRepo.GetFullExecutionAsync(executionId)
                ?? throw new EntityNotFoundException(nameof(TestExecution), executionId);

            // Validar que el estado del catálogo existe
            _ = await stepStatusRepo.GetByIdAsync(dto.StatusId)
                ?? throw new EntityNotFoundException(nameof(StepResultStatus), dto.StatusId);

            // Buscar el resultado del paso en la ejecución
            var stepResult =
                execution.StepResults.FirstOrDefault(sr => sr.TestStepId == dto.TestStepId)
                ?? throw new DomainException(
                    $"Paso '{dto.TestStepId}' no encontrado en ejecución '{executionId}'."
                );

            // Actualizar resultado del paso
            stepResult.StatusId = dto.StatusId;
            stepResult.ActualResult = dto.ActualResult;
            stepResult.Notes = dto.Notes;
            stepResult.EvaluatedAt = DateTime.UtcNow;

            // Si la ejecución estaba PENDING, cambiarla a IN_PROGRESS
            var pendingStatus = await execStatusRepo.GetByCodeAsync("PENDING");
            if (execution.StatusId == pendingStatus!.Id)
            {
                var inProgressStatus = await execStatusRepo.GetByCodeAsync("IN_PROGRESS");
                execution.StatusId = inProgressStatus!.Id;
            }

            execRepo.Update(execution);
            await uow.SaveChangesAsync();

            // Sincronizar con Kanban
            await SyncKanbanTaskAsync(execution.TestCaseId, null, execution.StatusId);

            logger.LogInformation(
                "Paso {StepId} actualizado en ejecución {ExecId}.",
                dto.TestStepId,
                executionId
            );

            var updated = await execRepo.GetFullExecutionAsync(executionId);
            return mapper.Map<TestExecutionDto>(updated);
        }

        public async Task<TestExecutionDto> UpdateStatusAsync(Guid id, int statusId)
        {
            logger.LogInformation("Actualizando estado de ejecución {ExecId} a {StatusId}.", id, statusId);

            var execution = await execRepo.GetFullExecutionAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestExecution), id);

            var status = await execStatusRepo.GetByIdAsync(statusId)
                ?? throw new EntityNotFoundException(nameof(ExecutionStatus), statusId);

            execution.StatusId = statusId;

            // Manejar CompletedAt basado en el código del estado
            if (status.Code == "PASSED" || status.Code == "FAILED")
            {
                execution.CompletedAt = DateTime.UtcNow;
            }
            else
            {
                execution.CompletedAt = null;
            }

            execRepo.Update(execution);
            await uow.SaveChangesAsync();

            // Sincronizar estado con el TestCase y Kanban
            await SyncTestCaseStatusAsync(execution.TestCaseId, execution.StatusId);
            await SyncKanbanTaskAsync(execution.TestCaseId, null, execution.StatusId);

            if (status.Code == "PASSED" || status.Code == "FAILED")
            {
                if (execution.TestCase != null)
                {
                    await SyncProjectHoursAsync(execution.TestCase.ProjectId);
                }
            }

            return mapper.Map<TestExecutionDto>(execution);
        }

        /// <summary>
        /// Completa una ejecución con un estado final (PASSED, FAILED, etc.)
        /// </summary>
        public async Task<TestExecutionDto> CompleteExecutionAsync(
            Guid executionId,
            int finalStatusId
        )
        {
            logger.LogInformation(
                "Completando ejecución {ExecId} con status {StatusId}.",
                executionId,
                finalStatusId
            );

            var execution =
                await execRepo.GetFullExecutionAsync(executionId)
                ?? throw new EntityNotFoundException(nameof(TestExecution), executionId);

            _ = await execStatusRepo.GetByIdAsync(finalStatusId)
                ?? throw new EntityNotFoundException(nameof(ExecutionStatus), finalStatusId);

            execution.StatusId = finalStatusId;
            execution.CompletedAt = DateTime.UtcNow;

            execRepo.Update(execution);
            await uow.SaveChangesAsync();

            // Sincronizar estado con el TestCase y Kanban
            await SyncTestCaseStatusAsync(execution.TestCaseId, execution.StatusId);
            await SyncKanbanTaskAsync(execution.TestCaseId, null, execution.StatusId);

            // Sincronizar horas del proyecto
            if (execution.TestCase != null)
            {
                await SyncProjectHoursAsync(execution.TestCase.ProjectId);
            }

            logger.LogInformation("Ejecución {ExecId} completada.", executionId);

            var completed = await execRepo.GetFullExecutionAsync(executionId);
            return mapper.Map<TestExecutionDto>(completed);
        }

        /// <summary>
        /// Sube un archivo de evidencia (imagen o video) y lo asocia a una ejecución.
        /// Determina el tipo de evidencia automáticamente por el content type.
        /// </summary>
        public async Task<EvidenceDto> UploadEvidenceAsync(
            Guid executionId,
            Stream fileStream,
            string fileName,
            string contentType,
            string? description,
            Guid? stepResultId = null
        )
        {
            logger.LogInformation(
                "Subiendo evidencia '{FileName}' a ejecución {ExecId}.",
                fileName,
                executionId
            );

            // Verificar que la ejecución existe
            var execution =
                await execRepo.GetByIdAsync(executionId)
                ?? throw new EntityNotFoundException(nameof(TestExecution), executionId);

            // Determinar tipo de evidencia por content type
            var typeCode =
                contentType.StartsWith("image/") ? "IMAGE"
                : contentType.StartsWith("video/") ? "VIDEO"
                : contentType.StartsWith("application/pdf") ? "DOCUMENT"
                : "LOG_FILE";

            var evidenceType =
                await evidenceTypeRepo.GetByCodeAsync(typeCode)
                ?? throw new DomainException(
                    $"Tipo de evidencia '{typeCode}' no encontrado en catálogo."
                );

            // Guardar archivo en el sistema de archivos
            var filePath = await fileStorage.SaveFileAsync(
                fileStream,
                fileName,
                $"evidences/{executionId}"
            );

            // Obtener tamaño del archivo
            var fileSize = fileStream.Length;

            var evidence = new Evidence
            {
                Id = Guid.NewGuid(),
                TestExecutionId = executionId,
                ExecutionStepResultId = stepResultId,
                FileTypeId = evidenceType.Id,
                FileName = fileName,
                FilePath = filePath,
                FileSize = fileSize,
                ContentType = contentType,
                Description = description,
                UploadedAt = DateTime.UtcNow,
            };

            await evidenceRepo.AddAsync(evidence);
            await uow.SaveChangesAsync();

            logger.LogInformation(
                "Evidencia '{FileName}' guardada con ID {EvidenceId}.",
                fileName,
                evidence.Id
            );

            var dto = mapper.Map<EvidenceDto>(evidence);
            dto.FileUrl = fileStorage.GetFileUrl(evidence.FilePath);
            return dto;
        }

        public async Task<TestExecutionDto> UpdateCompleteAsync(Guid id, UpdateCompleteExecutionDto dto)
        {
            logger.LogInformation("Actualización completa de la ejecución {Id}.", id);

            var execution = await execRepo.GetFullExecutionAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestExecution), id);

            // 1. Actualizar datos generales
            execution.Notes = dto.Notes;
            execution.ActualTimeHours = dto.ActualTimeHours ?? 0m;
            if (dto.TestPlanId.HasValue)
            {
                execution.TestPlanId = dto.TestPlanId.Value == Guid.Empty ? null : dto.TestPlanId;
            }
            if (dto.TesterId.HasValue && dto.TesterId.Value != Guid.Empty)
            {
                execution.TesterId = dto.TesterId.Value;
            }

            // 2. Actualizar resultados de pasos
            foreach (var stepResultInput in dto.StepResults)
            {
                var existingStep = execution.StepResults.FirstOrDefault(sr => sr.TestStepId == stepResultInput.TestStepId);
                if (existingStep != null)
                {
                    existingStep.StatusId = stepResultInput.StatusId;
                    existingStep.ActualResult = stepResultInput.ActualResult;
                    existingStep.Notes = stepResultInput.Notes;
                    existingStep.EvaluatedAt = DateTime.UtcNow;
                }
            }

            // 3. Re-evaluar estado global automáticamente
            await ReEvaluateExecutionStatusAsync(execution);

            execRepo.Update(execution);
            await uow.SaveChangesAsync();

            // Sincronizar estado con el TestCase y Kanban
            await SyncTestCaseStatusAsync(execution.TestCaseId, execution.StatusId);
            await SyncKanbanTaskAsync(execution.TestCaseId, execution.TesterId, execution.StatusId);

            var status = await execStatusRepo.GetByIdAsync(execution.StatusId);
            if (status?.Code == "PASSED" || status?.Code == "FAILED")
            {
                if (execution.TestCase != null)
                {
                    await SyncProjectHoursAsync(execution.TestCase.ProjectId);
                }
            }

            return await GetByIdAsync(id);
        }

        private async Task ReEvaluateExecutionStatusAsync(TestExecution execution)
        {
            var pasoPassed = await stepStatusRepo.GetByCodeAsync("PASSED");
            var pasoFailed = await stepStatusRepo.GetByCodeAsync("FAILED");
            var pasoBlocked = await stepStatusRepo.GetByCodeAsync("BLOCKED");

            // Si no existen los códigos, la re-evaluación no puede continuar de forma segura
            if (pasoPassed == null || pasoFailed == null)
            {
                logger.LogWarning("Cólogos de estado 'PASSED' o 'FAILED' no encontrados en catálogo de pasos.");
                return;
            }

            var allPassed = execution.StepResults.All(sr => sr.StatusId == pasoPassed.Id);
            var anyFailed = execution.StepResults.Any(sr => sr.StatusId == pasoFailed.Id);
            var anyBlocked = pasoBlocked != null && execution.StepResults.Any(sr => sr.StatusId == pasoBlocked.Id);

            string newExecStatusCode;
            if (anyFailed) newExecStatusCode = "FAILED";
            else if (anyBlocked) newExecStatusCode = "FAILED";
            else if (allPassed) newExecStatusCode = "PASSED";
            else newExecStatusCode = "IN_PROGRESS";

            var newStatus = await execStatusRepo.GetByCodeAsync(newExecStatusCode);
            if (newStatus != null)
            {
                execution.StatusId = newStatus.Id;

                if (newExecStatusCode == "PASSED" || newExecStatusCode == "FAILED")
                {
                    execution.CompletedAt = DateTime.UtcNow;
                }
                else
                {
                    execution.CompletedAt = null;
                }
            }
        }

        public async Task<ObservationDto> AddObservationAsync(Guid createdByUserId, CreateObservationDto dto, Stream? fileStream = null, string? fileName = null, string? contentType = null)
        {
            logger.LogInformation("Agregando observación al resultado de paso {StepResultId}.", dto.ExecutionStepResultId);

            var observation = new ExecutionStepObservation
            {
                Id = Guid.NewGuid(),
                ExecutionStepResultId = dto.ExecutionStepResultId,
                Observation = dto.Observation,
                CreatedByUserId = createdByUserId,
                CreatedAt = DateTime.UtcNow
            };

            if (fileStream != null && fileName != null && contentType != null)
            {
                // Determinar tipo de evidencia por content type
                var typeCode =
                    contentType.StartsWith("image/") ? "IMAGE"
                    : contentType.StartsWith("video/") ? "VIDEO"
                    : contentType.StartsWith("application/pdf") ? "DOCUMENT"
                    : "LOG_FILE";

                var evidenceType = await evidenceTypeRepo.GetByCodeAsync(typeCode);

                // Guardar archivo
                var filePath = await fileStorage.SaveFileAsync(
                    fileStream,
                    fileName,
                    $"observations/{dto.ExecutionStepResultId}"
                );

                observation.FileTypeId = evidenceType?.Id;
                observation.FileName = fileName;
                observation.FilePath = filePath;
                observation.FileSize = fileStream.Length;
                observation.ContentType = contentType;
            }

            await observationRepo.AddAsync(observation);
            await uow.SaveChangesAsync();

            // Cargar con navegación para el DTO
            var created = await observationRepo.GetByIdAsync(observation.Id);
            return mapper.Map<ObservationDto>(created);
        }

        public async Task<ObservationDto> AddResponseToObservationAsync(Guid responderUserId, Guid observationId, ResponseObservationDto dto)
        {
            logger.LogInformation("Respondiendo a observación {ObservationId}.", observationId);

            var observation = await observationRepo.GetByIdAsync(observationId)
                ?? throw new EntityNotFoundException(nameof(ExecutionStepObservation), observationId);

            observation.Response = dto.Response;
            observation.RespondedByUserId = responderUserId;
            observation.RespondedAt = DateTime.UtcNow;

            observationRepo.Update(observation);
            await uow.SaveChangesAsync();

            return mapper.Map<ObservationDto>(observation);
        }

        private async Task SyncTestCaseStatusAsync(Guid testCaseId, int executionStatusId)
        {
            var testCase = await testCaseRepo.GetByIdAsync(testCaseId);
            if (testCase == null) return;

            var status = await execStatusRepo.GetByIdAsync(executionStatusId);
            if (status == null) return;

            // Lógica: Si la ejecución pasó o falló, podemos considerar el caso como 'afectado'
            // Por ahora, como TestCase no tiene un catálogo de estados explícito más allá de IsActive,
            // podríamos agregar lógica futura aquí. El usuario mencionó "actualizar su estado",
            // lo cual implica que TestCase debería tener un StatusId.

            // por ahora solo registramos la intención
            logger.LogInformation("Sincronizando estado de TestCase {TestCaseId} con ejecución {Status}.", testCaseId, status.Code);
        }

        private async Task SyncProjectHoursAsync(Guid projectId)
        {
            logger.LogInformation("Sincronizando horas del proyecto {ProjectId}.", projectId);

            var project = await projectRepo.GetByIdTrackedAsync(projectId);
            if (project == null) return;

            // 1. Horas Ejecutadas (Suma de ActualTimeHours de ejecuciones PASSED/FAILED)
            decimal totalExecuted = 0;
            foreach (var testCase in project.TestCases)
            {
                var relevantExecs = testCase.TestExecutions.Where(te =>
                    te.Status != null && (te.Status.Code == "PASSED" || te.Status.Code == "FAILED")
                );
                totalExecuted += relevantExecs.Sum(te => te.ActualTimeHours);
            }
            project.ExecutedHours = totalExecuted;

            // 2. Horas Remanentes (Total Estimado - Horas de casos ya PASSED)
            // Nota: Aquí el usuario pidió "remanentes", lo cual usualmente es suma de estimaciones de lo pendiente.
            decimal totalEstimated = 0;
            decimal alreadyPassedEstimation = 0;

            foreach (var testCase in project.TestCases)
            {
                totalEstimated += testCase.EstimatedTimeHours;
                var hasPassed = testCase.TestExecutions.Any(te => te.Status != null && te.Status.Code == "PASSED");
                if (hasPassed)
                {
                    alreadyPassedEstimation += testCase.EstimatedTimeHours;
                }
            }

            // El remanente es lo que falta por completar exitosamente
            project.RemainingHours = totalEstimated - alreadyPassedEstimation;

            projectRepo.Update(project);
            await uow.SaveChangesAsync();

            logger.LogInformation("Proyecto {ProjectId} actualizado: Ejecutadas {Executed}, Remanentes {Remaining}.",
                projectId, project.ExecutedHours, project.RemainingHours);
        }

        private async Task SyncKanbanTaskAsync(Guid testCaseId, Guid? testerId, int? executionStatusId)
        {
            try
            {
                var tasks = await kanbanTaskRepo.FindAsync(t => t.TestCaseId == testCaseId && !t.IsDeleted);
                if (!tasks.Any()) return;

                string? statusCode = null;
                if (executionStatusId.HasValue)
                {
                    var status = await execStatusRepo.GetByIdAsync(executionStatusId.Value);
                    statusCode = status?.Code;
                }

                foreach (var task in tasks)
                {
                    bool updated = false;

                    if (testerId.HasValue && testerId.Value != Guid.Empty && task.AssigneeId != testerId.Value)
                    {
                        task.AssigneeId = testerId.Value;
                        updated = true;
                    }

                    if (!string.IsNullOrEmpty(statusCode))
                    {
                        var currentColumn = await kanbanColumnRepo.GetByIdAsync(task.KanbanColumnId);
                        if (currentColumn != null)
                        {
                            var boardColumns = await kanbanColumnRepo.FindAsync(c => c.BoardId == currentColumn.BoardId && !c.IsDeleted);
                            KanbanColumn? targetColumn = statusCode switch
                            {
                                "PASSED" => boardColumns.FirstOrDefault(c => c.Name.Equals("Completado", StringComparison.OrdinalIgnoreCase) || c.Name.Equals("Done", StringComparison.OrdinalIgnoreCase)),
                                "FAILED" or "BLOCKED" => boardColumns.FirstOrDefault(c => c.Name.Equals("En Revisión", StringComparison.OrdinalIgnoreCase) || c.Name.Equals("In Review", StringComparison.OrdinalIgnoreCase) || c.Name.Equals("En Progreso", StringComparison.OrdinalIgnoreCase)),
                                "IN_PROGRESS" => boardColumns.FirstOrDefault(c => c.Name.Equals("En Progreso", StringComparison.OrdinalIgnoreCase) || c.Name.Equals("In Progress", StringComparison.OrdinalIgnoreCase)),
                                "PENDING" => boardColumns.FirstOrDefault(c => c.Name.Equals("Por Hacer", StringComparison.OrdinalIgnoreCase) || c.Name.Equals("Tareas Pendientes", StringComparison.OrdinalIgnoreCase) || c.Name.Equals("To Do", StringComparison.OrdinalIgnoreCase)),
                                _ => null
                            };

                            if (targetColumn != null && targetColumn.Id != task.KanbanColumnId)
                            {
                                task.KanbanColumnId = targetColumn.Id;
                                updated = true;
                            }
                        }
                    }

                    if (updated)
                    {
                        task.UpdatedAt = DateTime.UtcNow;
                        kanbanTaskRepo.Update(task);
                    }
                }

                await uow.SaveChangesAsync();
                logger.LogInformation("Sincronización de Kanban para caso {TestCaseId} completada.", testCaseId);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Error al sincronizar tarea Kanban para TestCase {TestCaseId}.", testCaseId);
            }
        }
    }
}
