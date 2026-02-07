// src/QAMS.Application/Services/CatalogService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Catalogs;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de administración de tablas catálogo.
    /// OCP: agregar catálogos sin modificar lógica existente.
    /// </summary>
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository<ExecutionStatus> _execStatusRepo;
        private readonly ICatalogRepository<EvidenceType> _evidTypeRepo;
        private readonly ICatalogRepository<StepResultStatus> _stepStatusRepo;
        private readonly ICatalogRepository<TaskPriority> _taskPriorityRepo;
        private readonly ICatalogRepository<TestCasePriority> _casePriorityRepo;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CatalogService> _logger;

        public CatalogService(
            ICatalogRepository<ExecutionStatus> execStatusRepo,
            ICatalogRepository<EvidenceType> evidTypeRepo,
            ICatalogRepository<StepResultStatus> stepStatusRepo,
            ICatalogRepository<TaskPriority> taskPriorityRepo,
            ICatalogRepository<TestCasePriority> casePriorityRepo,
            IUnitOfWork uow, ILogger<CatalogService> logger)
        {
            _execStatusRepo = execStatusRepo;
            _evidTypeRepo = evidTypeRepo;
            _stepStatusRepo = stepStatusRepo;
            _taskPriorityRepo = taskPriorityRepo;
            _casePriorityRepo = casePriorityRepo;
            _uow = uow;
            _logger = logger;
        }

        public async Task<List<CatalogItemDto>> GetActiveByCatalogNameAsync(string catalogName)
        {
            _logger.LogInformation("Obteniendo activos del catálogo '{Name}'.", catalogName);
            return catalogName.ToLower() switch
            {
                "executionstatus" => Map(await _execStatusRepo.GetAllActiveAsync()),
                "evidencetype" => Map(await _evidTypeRepo.GetAllActiveAsync()),
                "stepresultstatus" => Map(await _stepStatusRepo.GetAllActiveAsync()),
                "taskpriority" => Map(await _taskPriorityRepo.GetAllActiveAsync()),
                "testcasepriority" => Map(await _casePriorityRepo.GetAllActiveAsync()),
                _ => throw new DomainException($"Catálogo '{catalogName}' no reconocido.")
            };
        }

        public async Task<List<CatalogItemDto>> GetAllByCatalogNameAsync(string catalogName)
        {
            _logger.LogInformation("Obteniendo todos del catálogo '{Name}'.", catalogName);
            return catalogName.ToLower() switch
            {
                "executionstatus" => Map(await _execStatusRepo.GetAllAsync()),
                "evidencetype" => Map(await _evidTypeRepo.GetAllAsync()),
                "stepresultstatus" => Map(await _stepStatusRepo.GetAllAsync()),
                "taskpriority" => Map(await _taskPriorityRepo.GetAllAsync()),
                "testcasepriority" => Map(await _casePriorityRepo.GetAllAsync()),
                _ => throw new DomainException($"Catálogo '{catalogName}' no reconocido.")
            };
        }

        public async Task<CatalogItemDto> CreateAsync(string catalogName, CreateCatalogItemDto dto)
        {
            _logger.LogInformation("Creando valor en catálogo '{Name}': {Code}.", catalogName, dto.Code);
            var result = catalogName.ToLower() switch
            {
                "executionstatus" => await Add(_execStatusRepo, dto, () => new ExecutionStatus()),
                "evidencetype" => await Add(_evidTypeRepo, dto, () => new EvidenceType()),
                "stepresultstatus" => await Add(_stepStatusRepo, dto, () => new StepResultStatus()),
                "taskpriority" => await Add(_taskPriorityRepo, dto, () => new TaskPriority()),
                "testcasepriority" => await Add(_casePriorityRepo, dto, () => new TestCasePriority()),
                _ => throw new DomainException($"Catálogo '{catalogName}' no reconocido.")
            };
            await _uow.SaveChangesAsync();
            return result;
        }

        public async Task<CatalogItemDto> UpdateAsync(string catalogName, int id, CreateCatalogItemDto dto)
        {
            _logger.LogInformation("Actualizando ID={Id} en catálogo '{Name}'.", id, catalogName);
            var result = catalogName.ToLower() switch
            {
                "executionstatus" => await Upd(_execStatusRepo, id, dto),
                "evidencetype" => await Upd(_evidTypeRepo, id, dto),
                "stepresultstatus" => await Upd(_stepStatusRepo, id, dto),
                "taskpriority" => await Upd(_taskPriorityRepo, id, dto),
                "testcasepriority" => await Upd(_casePriorityRepo, id, dto),
                _ => throw new DomainException($"Catálogo '{catalogName}' no reconocido.")
            };
            await _uow.SaveChangesAsync();
            return result;
        }

        private List<CatalogItemDto> Map<T>(IReadOnlyList<T> items) where T : CatalogBase
            => items.Select(e => new CatalogItemDto
            {
                Id = e.Id, Code = e.Code, Name = e.Name,
                Description = e.Description, SortOrder = e.SortOrder, IsActive = e.IsActive
            }).ToList();

        private async Task<CatalogItemDto> Add<T>(
            ICatalogRepository<T> repo, CreateCatalogItemDto dto, Func<T> factory) where T : CatalogBase
        {
            if (await repo.ExistsByCodeAsync(dto.Code))
                throw new DomainException($"Código '{dto.Code}' ya existe.");
            var entity = factory();
            entity.Code = dto.Code.ToUpper();
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.SortOrder = dto.SortOrder;
            entity.IsActive = dto.IsActive;
            await repo.AddAsync(entity);
            return new CatalogItemDto
            {
                Id = entity.Id, Code = entity.Code, Name = entity.Name,
                Description = entity.Description, SortOrder = entity.SortOrder, IsActive = entity.IsActive
            };
        }

        private async Task<CatalogItemDto> Upd<T>(
            ICatalogRepository<T> repo, int id, CreateCatalogItemDto dto) where T : CatalogBase
        {
            var entity = await repo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(typeof(T).Name, id);
            entity.Code = dto.Code.ToUpper();
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.SortOrder = dto.SortOrder;
            entity.IsActive = dto.IsActive;
            repo.Update(entity);
            return new CatalogItemDto
            {
                Id = entity.Id, Code = entity.Code, Name = entity.Name,
                Description = entity.Description, SortOrder = entity.SortOrder, IsActive = entity.IsActive
            };
        }
    }
}
