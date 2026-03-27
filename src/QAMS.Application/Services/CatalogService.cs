// src/QAMS.Application/Services/CatalogService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Catalogs;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de administración de tablas catálogo.
    /// OCP: agregar catálogos sin modificar lógica existente.
    /// </summary>
    public class CatalogService(
        IServiceProvider serviceProvider,
        IUnitOfWork uow,
        ILogger<CatalogService> logger) : ICatalogService
    {

        public async Task<List<CatalogItemDto>> GetActiveByCatalogNameAsync(string catalogName)
        {
            logger.LogInformation("Obteniendo activos del catálogo '{Name}'.", catalogName);
            var items = await ResolveRepo<IReadOnlyList<CatalogBase>>(catalogName, async repo => await repo.GetAllActiveAsync());
            return Map(items);
        }

        public async Task<List<CatalogItemDto>> GetAllByCatalogNameAsync(string catalogName)
        {
            logger.LogInformation("Obteniendo todos del catálogo '{Name}'.", catalogName);
            var items = await ResolveRepo<IReadOnlyList<CatalogBase>>(catalogName, async repo => await repo.GetAllAsync());
            return Map(items);
        }

        public async Task<CatalogItemDto> CreateAsync(string catalogName, CreateCatalogItemDto dto)
        {
            logger.LogInformation("Creando valor en catálogo '{Name}': {Code}.", catalogName, dto.Code);
            var result = await ResolveRepo<CatalogBase>(catalogName, async repo => 
            {
                if (await repo.ExistsByCodeAsync(dto.Code))
                    throw new DomainException($"Código '{dto.Code}' ya existe.");
                
                var entity = CreateEntityInstance(catalogName);
                entity.Code = dto.Code.ToUpper();
                entity.Name = dto.Name;
                entity.Description = dto.Description;
                entity.SortOrder = dto.SortOrder;
                entity.IsActive = dto.IsActive;
                
                await repo.AddAsync(entity);
                return (CatalogBase)entity;
            });

            await uow.SaveChangesAsync();
            return MapSingle(result);
        }

        public async Task<CatalogItemDto> UpdateAsync(string catalogName, int id, CreateCatalogItemDto dto)
        {
            logger.LogInformation("Actualizando ID={Id} en catálogo '{Name}'.", id, catalogName);
            var result = await ResolveRepo<CatalogBase>(catalogName, async repo => 
            {
                var entity = await repo.GetByIdAsync(id)
                    ?? throw new EntityNotFoundException(catalogName, id);
                
                entity.Code = dto.Code.ToUpper();
                entity.Name = dto.Name;
                entity.Description = dto.Description;
                entity.SortOrder = dto.SortOrder;
                entity.IsActive = dto.IsActive;
                
                repo.Update(entity);
                return (CatalogBase)entity;
            });

            await uow.SaveChangesAsync();
            return MapSingle(result);
        }

        private async Task<TResult> ResolveRepo<TResult>(string catalogName, Func<dynamic, Task<TResult>> action)
        {
            var type = catalogName.ToLower() switch
            {
                "executionstatus" => typeof(ExecutionStatus),
                "evidencetype" => typeof(EvidenceType),
                "stepresultstatus" => typeof(StepResultStatus),
                "taskpriority" => typeof(TaskPriority),
                "testcasepriority" => typeof(TestCasePriority),
                "testtype" => typeof(TestType),
                "testsuitestatus" => typeof(TestSuiteStatus),
                "projectstatus" => typeof(ProjectStatus),
                _ => throw new DomainException($"Catálogo '{catalogName}' no reconocido.")
            };

            var repoType = typeof(ICatalogRepository<>).MakeGenericType(type);
            var repo = serviceProvider.GetRequiredService(repoType);
            return await action(repo);
        }

        private static CatalogBase CreateEntityInstance(string catalogName)
        {
            return catalogName.ToLower() switch
            {
                "executionstatus" => new ExecutionStatus(),
                "evidencetype" => new EvidenceType(),
                "stepresultstatus" => new StepResultStatus(),
                "taskpriority" => new TaskPriority(),
                "testcasepriority" => new TestCasePriority(),
                "testtype" => new TestType(),
                "testsuitestatus" => new TestSuiteStatus(),
                "projectstatus" => new ProjectStatus(),
                _ => throw new DomainException($"Entidad para catálogo '{catalogName}' no reconocida.")
            };
        }

        private static List<CatalogItemDto> Map(IEnumerable<CatalogBase> items)
        {
            var dtos = new List<CatalogItemDto>();
            foreach (var e in items)
            {
                dtos.Add(MapSingle(e));
            }
            return dtos;
        }

        private static CatalogItemDto MapSingle(CatalogBase e)
        {
            return new CatalogItemDto
            {
                Id = e.Id,
                Code = e.Code,
                Name = e.Name,
                Description = e.Description,
                SortOrder = e.SortOrder,
                IsActive = e.IsActive
            };
        }
    }
}
