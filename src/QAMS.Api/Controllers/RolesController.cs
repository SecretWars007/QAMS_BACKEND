// src/QAMS.Api/Controllers/RolesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Roles;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RolesController> _logger;

        public RolesController(IRoleService roleService, ILogger<RolesController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET /api/roles - Obteniendo todos los roles.");
            return Ok(await _roleService.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/roles/{RoleId}", id);
            return Ok(await _roleService.GetByIdAsync(id));
        }

        [HttpPost]
        [HasPermission("ROLES_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            _logger.LogInformation("POST /api/roles - Creando rol '{Name}'.", dto.Name);
            var role = await _roleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateRoleDto dto)
        {
            _logger.LogInformation("PUT /api/roles/{RoleId} - Actualizando rol.", id);
            return Ok(await _roleService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id:guid}")]
        [HasPermission("ROLES_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/roles/{RoleId}", id);
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("permissions")]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetAllPermissions()
        {
            _logger.LogInformation("GET /api/roles/permissions - Obteniendo todos los permisos disponibles.");
            return Ok(await _roleService.GetAllPermissionsAsync());
        }

        [HttpPost("{id:guid}/permissions")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> AssignPermissions(Guid id, [FromBody] AssignPermissionsDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/permissions - Asignando permisos.", id);
            await _roleService.AssignPermissionsAsync(id, dto);
            return NoContent();
        }

        [HttpPut("{id:guid}/toggle-status")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            _logger.LogInformation("PUT /api/roles/{RoleId}/toggle-status", id);
            await _roleService.ToggleStatusAsync(id);
            return NoContent();
        }

        [HttpPost("{id:guid}/duplicate")]
        [HasPermission("ROLES_CREATE")]
        public async Task<IActionResult> Duplicate(Guid id, [FromBody] DuplicateRoleDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/duplicate - Nuevo nombre: '{NewName}'", id, dto.NewName);
            var role = await _roleService.DuplicateAsync(id, dto.NewName);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPost("{id:guid}/permissions/add")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> AddPermissions(Guid id, [FromBody] AssignPermissionsDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/permissions/add - Agregando permisos.", id);
            await _roleService.AddPermissionsAsync(id, dto.PermissionIds);
            return NoContent();
        }

        [HttpPost("{id:guid}/permissions/remove")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> RemovePermissions(Guid id, [FromBody] AssignPermissionsDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/permissions/remove - Quitando permisos.", id);
            await _roleService.RemovePermissionsAsync(id, dto.PermissionIds);
            return NoContent();
        }
    }
}
