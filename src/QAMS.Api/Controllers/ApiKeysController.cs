// src/QAMS.Api/Controllers/ApiKeysController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Application.DTOs.ApiKeys;
using QAMS.Application.Interfaces.Services;

namespace QAMS.Api.Controllers
{
    /// <summary>
    /// Gestión de API Keys para integración CI/CD y automatización.
    /// Solo administradores pueden crear/revocar llaves.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class ApiKeysController(IApiKeyService apiKeyService) : ControllerBase
    {
        /// <summary>Lista las API Keys activas de un proyecto.</summary>
        [HttpGet("project/{projectId:guid}")]
        public async Task<ActionResult<List<ApiKeyDto>>> GetByProject(Guid projectId)
        {
            var keys = await apiKeyService.GetByProjectAsync(projectId);
            return Ok(keys);
        }

        /// <summary>
        /// Crea una nueva API Key para un proyecto.
        /// El valor plano solo se devuelve en esta respuesta — no se puede recuperar después.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,QALead")]
        public async Task<ActionResult<ApiKeyCreatedDto>> Create([FromBody] CreateApiKeyDto dto)
        {
            var result = await apiKeyService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByProject), new { projectId = dto.ProjectId }, result);
        }

        /// <summary>Revoca (desactiva) una API Key.</summary>
        [HttpDelete("{id:guid}/revoke")]
        [Authorize(Roles = "Admin,QALead")]
        public async Task<ActionResult> Revoke(Guid id)
        {
            await apiKeyService.RevokeAsync(id);
            return NoContent();
        }
    }
}
