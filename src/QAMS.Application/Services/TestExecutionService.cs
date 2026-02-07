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
    public class TestExecutionService : ITestExecutionService
    {
        private readonly ITestExecutionRepository _execRepo;
        private readonly ITestCaseRepository _testCaseRepo;
        private readonly IEvidenceRepository _evidenceRepo;
        private readonly ICatalogRepository<ExecutionStatus> _execStatusRepo;
        private readonly ICatalogRepository<StepResultStatus> _stepStatusRepo;
        private readonly ICatalogRepository<EvidenceType> _evidenceTypeRepo;
        private readonly IFileStorageService _fileStorage;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<TestExecutionService> _logger;

        public TestExecutionService(
            ITestExecutionRepository execRepo,
            ITestCaseRepository testCaseRepo,
            IEvidenceRepository evidenceRepo,
            ICatalogRepository<ExecutionStatus> execStatusRepo,
            ICatalogRepository<StepResultStatus> stepStatusRepo,
            ICatalogRepository<EvidenceType> evidenceTypeRepo,
            IFileStorageService fileStorage,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<TestExecutionService> logger
        )
        {
            _execRepo = execRepo;
            _testCaseRepo = testCaseRepo;
            _evidenceRepo = evidenceRepo;
            _execStatusRepo = execStatusRepo;
            _stepStatusRepo = stepStatusRepo;
            _evidenceTypeRepo = evidenceTypeRepo;
            _fileStorage = fileStorage;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TestExecutionDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo ejecución {Id}.", id);
            var execution =
                await _execRepo.GetFullExecutionAsync(id)
                ?? throw new EntityNotFoundException(nameof(TestExecution), id);

            var dto = _mapper.Map<TestExecutionDto>(execution);
            // Asignar URLs de evidencias
            foreach (var evidence in dto.Evidences)
            {
                var entity = execution.Evidences.First(e => e.Id == evidence.Id);
                evidence.FileUrl = _fileStorage.GetFileUrl(entity.FilePath);
            }
            return dto;
        }

        public async Task<List<TestExecutionDto>> GetByTestCaseAsync(Guid testCaseId)
        {
            _logger.LogInformation("Obteniendo ejecuciones del caso {TestCaseId}.", testCaseId);
            var executions = await _execRepo.GetByTestCaseAsync(testCaseId);
            return _mapper.Map<List<TestExecutionDto>>(executions);
        }

        public async Task<List<TestExecutionDto>> GetByTesterAsync(Guid testerId)
        {
            _logger.LogInformation("Obteniendo ejecuciones del tester {TesterId}.", testerId);
            var executions = await _execRepo.GetByTesterAsync(testerId);
            return _mapper.Map<List<TestExecutionDto>>(executions);
        }

        /// <summary>
        /// Crea una nueva ejecución para un caso de prueba.
        /// Inicializa todos los pasos con estado NOT_EXECUTED.
        /// </summary>
        public async Task<TestExecutionDto> CreateAsync(Guid testerId, CreateTestExecutionDto dto)
        {
            _logger.LogInformation(
                "Creando ejecución para caso {TestCaseId} por tester {TesterId}.",
                dto.TestCaseId,
                testerId
            );

            // Obtener el caso de prueba con sus pasos
            var testCase =
                await _testCaseRepo.GetWithStepsAsync(dto.TestCaseId)
                ?? throw new EntityNotFoundException(nameof(TestCase), dto.TestCaseId);

            // Obtener el estado PENDING del catálogo
            var pendingStatus =
                await _execStatusRepo.GetByCodeAsync("PENDING")
                ?? throw new DomainException("Estado 'PENDING' no encontrado en catálogo.");

            // Obtener el estado NOT_EXECUTED para los pasos
            var notExecutedStatus =
                await _stepStatusRepo.GetByCodeAsync("NOT_EXECUTED")
                ?? throw new DomainException("Estado 'NOT_EXECUTED' no encontrado en catálogo.");

            var execution = new TestExecution
            {
                Id = Guid.NewGuid(),
                TestCaseId = dto.TestCaseId,
                TesterId = testerId,
                StatusId = pendingStatus.Id,
                Notes = dto.Notes,
                ExecutionDate = DateTime.UtcNow,
            };

            // Pre-crear resultado de cada paso con estado NOT_EXECUTED
            foreach (var step in testCase.TestSteps)
            {
                execution.StepResults.Add(
                    new ExecutionStepResult
                    {
                        Id = Guid.NewGuid(),
                        TestExecutionId = execution.Id,
                        TestStepId = step.Id,
                        StatusId = notExecutedStatus.Id,
                        EvaluatedAt = DateTime.UtcNow,
                    }
                );
            }

            await _execRepo.AddAsync(execution);
            await _uow.SaveChangesAsync();

            _logger.LogInformation(
                "Ejecución {ExecId} creada con {StepCount} pasos.",
                execution.Id,
                execution.StepResults.Count
            );

            var created = await _execRepo.GetFullExecutionAsync(execution.Id);
            return _mapper.Map<TestExecutionDto>(created);
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
            _logger.LogInformation(
                "Actualizando paso {StepId} de ejecución {ExecId}.",
                dto.TestStepId,
                executionId
            );

            var execution =
                await _execRepo.GetFullExecutionAsync(executionId)
                ?? throw new EntityNotFoundException(nameof(TestExecution), executionId);

            // Validar que el estado del catálogo existe
            _ = await _stepStatusRepo.GetByIdAsync(dto.StatusId)
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
            var pendingStatus = await _execStatusRepo.GetByCodeAsync("PENDING");
            if (execution.StatusId == pendingStatus!.Id)
            {
                var inProgressStatus = await _execStatusRepo.GetByCodeAsync("IN_PROGRESS");
                execution.StatusId = inProgressStatus!.Id;
            }

            _execRepo.Update(execution);
            await _uow.SaveChangesAsync();

            _logger.LogInformation(
                "Paso {StepId} actualizado en ejecución {ExecId}.",
                dto.TestStepId,
                executionId
            );

            var updated = await _execRepo.GetFullExecutionAsync(executionId);
            return _mapper.Map<TestExecutionDto>(updated);
        }

        /// <summary>
        /// Completa una ejecución con un estado final (PASSED, FAILED, etc.)
        /// </summary>
        public async Task<TestExecutionDto> CompleteExecutionAsync(
            Guid executionId,
            int finalStatusId
        )
        {
            _logger.LogInformation(
                "Completando ejecución {ExecId} con status {StatusId}.",
                executionId,
                finalStatusId
            );

            var execution =
                await _execRepo.GetFullExecutionAsync(executionId)
                ?? throw new EntityNotFoundException(nameof(TestExecution), executionId);

            _ = await _execStatusRepo.GetByIdAsync(finalStatusId)
                ?? throw new EntityNotFoundException(nameof(ExecutionStatus), finalStatusId);

            execution.StatusId = finalStatusId;
            execution.CompletedAt = DateTime.UtcNow;

            _execRepo.Update(execution);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Ejecución {ExecId} completada.", executionId);

            var completed = await _execRepo.GetFullExecutionAsync(executionId);
            return _mapper.Map<TestExecutionDto>(completed);
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
            string? description
        )
        {
            _logger.LogInformation(
                "Subiendo evidencia '{FileName}' a ejecución {ExecId}.",
                fileName,
                executionId
            );

            // Verificar que la ejecución existe
            var execution =
                await _execRepo.GetByIdAsync(executionId)
                ?? throw new EntityNotFoundException(nameof(TestExecution), executionId);

            // Determinar tipo de evidencia por content type
            var typeCode =
                contentType.StartsWith("image/") ? "IMAGE"
                : contentType.StartsWith("video/") ? "VIDEO"
                : contentType.StartsWith("application/pdf") ? "DOCUMENT"
                : "LOG_FILE";

            var evidenceType =
                await _evidenceTypeRepo.GetByCodeAsync(typeCode)
                ?? throw new DomainException(
                    $"Tipo de evidencia '{typeCode}' no encontrado en catálogo."
                );

            // Guardar archivo en el sistema de archivos
            var filePath = await _fileStorage.SaveFileAsync(
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
                FileTypeId = evidenceType.Id,
                FileName = fileName,
                FilePath = filePath,
                FileSize = fileSize,
                ContentType = contentType,
                Description = description,
                UploadedAt = DateTime.UtcNow,
            };

            await _evidenceRepo.AddAsync(evidence);
            await _uow.SaveChangesAsync();

            _logger.LogInformation(
                "Evidencia '{FileName}' guardada con ID {EvidenceId}.",
                fileName,
                evidence.Id
            );

            return new EvidenceDto
            {
                Id = evidence.Id,
                FileTypeId = evidence.FileTypeId,
                FileTypeName = evidenceType.Name,
                FileName = evidence.FileName,
                FileUrl = _fileStorage.GetFileUrl(evidence.FilePath),
                FileSize = evidence.FileSize,
                Description = evidence.Description,
                UploadedAt = evidence.UploadedAt,
            };
        }
    }
}
