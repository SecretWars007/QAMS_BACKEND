// src/QAMS.Api/Controllers/CatalogsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Catalogs;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatalogsController(ICatalogService catalogService)
        { _catalogService = catalogService; }

        /// <summary>GET api/catalogs/{catalogName}/active</summary>
        [HttpGet("{catalogName}/active")]
        public async Task<IActionResult> GetActive(string catalogName)
            => Ok(await _catalogService.GetActiveByCatalogNameAsync(catalogName));

        /// <summary>GET api/catalogs/{catalogName}</summary>
        [HttpGet("{catalogName}")]
        [HasPermission("CATALOGS_VIEW")]
        public async Task<IActionResult> GetAll(string catalogName)
            => Ok(await _catalogService.GetAllByCatalogNameAsync(catalogName));

        /// <summary>POST api/catalogs/{catalogName}</summary>
        [HttpPost("{catalogName}")]
        [HasPermission("CATALOGS_MANAGE")]
        public async Task<IActionResult> Create(string catalogName, [FromBody] CreateCatalogItemDto dto)
            => Created("", await _catalogService.CreateAsync(catalogName, dto));

        /// <summary>PUT api/catalogs/{catalogName}/{id}</summary>
        [HttpPut("{catalogName}/{id:int}")]
        [HasPermission("CATALOGS_MANAGE")]
        public async Task<IActionResult> Update(string catalogName, int id, [FromBody] CreateCatalogItemDto dto)
            => Ok(await _catalogService.UpdateAsync(catalogName, id, dto));
    }
}
