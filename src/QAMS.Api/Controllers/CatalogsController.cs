// src/QAMS.Api/Controllers/CatalogsController.cs
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

        /// <summary>GET api/catalogs/{catalogName}/active</summary>
        [HttpGet("{catalogName}/active")]
        public async Task<IActionResult> GetActive(string catalogName)
        {
            _logger.LogInformation("GET /api/catalogs/{CatalogName}/active", catalogName);
            return Ok(await _catalogService.GetActiveByCatalogNameAsync(catalogName));
        }

        /// <summary>GET api/catalogs/{catalogName}</summary>
        [HttpGet("{catalogName}")]
        [HasPermission("CATALOGS_VIEW")]
        public async Task<IActionResult> GetAll(string catalogName)
        {
            _logger.LogInformation("GET /api/catalogs/{CatalogName}", catalogName);
            return Ok(await _catalogService.GetAllByCatalogNameAsync(catalogName));
        }

        /// <summary>POST api/catalogs/{catalogName}</summary>
        [HttpPost("{catalogName}")]
        [HasPermission("CATALOGS_MANAGE")]
        public async Task<IActionResult> Create(string catalogName, [FromBody] CreateCatalogItemDto dto)
        {
            _logger.LogInformation("POST /api/catalogs/{CatalogName} - Creando item '{Code}'.", catalogName, dto.Code);
            return Created("", await _catalogService.CreateAsync(catalogName, dto));
        }

        /// <summary>PUT api/catalogs/{catalogName}/{id}</summary>
        [HttpPut("{catalogName}/{id:int}")]
        [HasPermission("CATALOGS_MANAGE")]
        public async Task<IActionResult> Update(string catalogName, int id, [FromBody] CreateCatalogItemDto dto)
        {
            _logger.LogInformation("PUT /api/catalogs/{CatalogName}/{ItemId} - Actualizando item.", catalogName, id);
            return Ok(await _catalogService.UpdateAsync(catalogName, id, dto));
        }
    }
}
