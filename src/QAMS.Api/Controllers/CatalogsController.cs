// src/QAMS.Api/Controllers/CatalogsController.cs
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Catalogs;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CatalogsController(ICatalogService catalogService, ILogger<CatalogsController> logger) : ControllerBase
    {
        private readonly ICatalogService _catalogService = catalogService;
        private readonly ILogger<CatalogsController> _logger = logger;

        /// <summary>
        /// Obtiene los elementos activos de un catálogo específico.
        /// </summary>
        /// <param name="catalogName">Nombre del catálogo (ej. 'Status', 'Priority').</param>
        /// <returns>Lista de elementos activos del catálogo.</returns>
        [HttpGet("{catalogName}/active")]
        public async Task<IActionResult> GetActive(string catalogName)
        {
            _logger.LogInformation("GET /api/catalogs/{CatalogName}/active", catalogName);
            return Ok(await _catalogService.GetActiveByCatalogNameAsync(catalogName));
        }

        /// <summary>
        /// Obtiene todos los elementos de un catálogo. Requiere permiso CATALOGS_VIEW.
        /// </summary>
        /// <param name="catalogName">Nombre del catálogo.</param>
        /// <returns>Lista de todos los elementos del catálogo.</returns>
        [HttpGet("{catalogName}")]
        [HasPermission("CATALOGS_VIEW")]
        public async Task<IActionResult> GetAll(string catalogName)
        {
            _logger.LogInformation("GET /api/catalogs/{CatalogName}", catalogName);
            return Ok(await _catalogService.GetAllByCatalogNameAsync(catalogName));
        }

        /// <summary>
        /// Crea un nuevo elemento en un catálogo. Requiere permiso CATALOGS_MANAGE.
        /// </summary>
        /// <param name="catalogName">Nombre del catálogo.</param>
        /// <param name="dto">Datos del nuevo elemento.</param>
        /// <returns>El elemento creado.</returns>
        [HttpPost("{catalogName}")]
        [HasPermission("CATALOGS_MANAGE")]
        public async Task<IActionResult> Create(string catalogName, [FromBody] CreateCatalogItemDto dto)
        {
            _logger.LogInformation("POST /api/catalogs/{CatalogName} - Creando item '{Code}'.", catalogName, dto.Code);
            return Created("", await _catalogService.CreateAsync(catalogName, dto));
        }

        /// <summary>
        /// Actualiza un elemento existente de un catálogo. Requiere permiso CATALOGS_MANAGE.
        /// </summary>
        /// <param name="catalogName">Nombre del catálogo.</param>
        /// <param name="id">ID numérico del elemento.</param>
        /// <param name="dto">Datos actualizados.</param>
        /// <returns>El elemento actualizado.</returns>
        [HttpPut("{catalogName}/{id:int}")]
        [HasPermission("CATALOGS_MANAGE")]
        public async Task<IActionResult> Update(string catalogName, int id, [FromBody] CreateCatalogItemDto dto)
        {
            _logger.LogInformation("PUT /api/catalogs/{CatalogName}/{ItemId} - Actualizando item.", catalogName, id);
            return Ok(await _catalogService.UpdateAsync(catalogName, id, dto));
        }
    }
}
