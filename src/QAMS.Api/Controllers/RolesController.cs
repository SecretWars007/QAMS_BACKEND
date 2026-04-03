// src/QAMS.Api/Controllers/RolesController.cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Roles;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolesController(IRoleService roleService, ILogger<RolesController> logger) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService;
        private readonly ILogger<RolesController> _logger = logger;

        /// <summary>
        /// Obtiene todos los roles definidos en el sistema. Requiere permiso ROLES_VIEW.
        /// </summary>
        /// <returns>Lista de roles.</returns>
        [HttpGet]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET /api/roles - Obteniendo todos los roles.");
            return Ok(await _roleService.GetAllAsync());
        }

        /// <summary>
        /// Obtiene el detalle de un rol por su ID. Requiere permiso ROLES_VIEW.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>El objeto rol con sus permisos.</returns>
        [HttpGet("{id:guid}")]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/roles/{RoleId}", id);
            return Ok(await _roleService.GetByIdAsync(id));
        }

        /// <summary>
        /// Crea un nuevo rol vacío o con datos básicos. Requiere permiso ROLES_CREATE.
        /// </summary>
        /// <param name="dto">Datos del nuevo rol.</param>
        /// <returns>El rol creado.</returns>
        [HttpPost]
        [HasPermission("ROLES_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            _logger.LogInformation("POST /api/roles - Creando rol '{Name}'.", dto.Name);
            var role = await _roleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        /// <summary>
        /// Actualiza un rol existente. Requiere permiso ROLES_UPDATE.
        /// </summary>
        /// <param name="id">ID del rol a actualizar.</param>
        /// <param name="dto">Nuevos datos del rol.</param>
        /// <returns>El rol actualizado.</returns>
        [HttpPut("{id:guid}")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateRoleDto dto)
        {
            _logger.LogInformation("PUT /api/roles/{RoleId} - Actualizando rol.", id);
            return Ok(await _roleService.UpdateAsync(id, dto));
        }

        /// <summary>
        /// Elimina un rol del sistema. Requiere permiso ROLES_DELETE.
        /// </summary>
        /// <param name="id">ID del rol a eliminar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{id:guid}")]
        [HasPermission("ROLES_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/roles/{RoleId}", id);
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Obtiene el catálogo de todos los permisos granulares disponibles. Requiere permiso ROLES_VIEW.
        /// </summary>
        /// <returns>Lista de permisos del sistema.</returns>
        [HttpGet("permissions")]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetAllPermissions()
        {
            _logger.LogInformation("GET /api/roles/permissions - Obteniendo todos los permisos disponibles.");
            return Ok(await _roleService.GetAllPermissionsAsync());
        }

        /// <summary>
        /// Asigna un conjunto completo de permisos a un rol (reemplaza los existentes). Requiere permiso ROLES_UPDATE.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <param name="dto">Lista de IDs de permisos a asignar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpPost("{id:guid}/permissions")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> AssignPermissions(Guid id, [FromBody] AssignPermissionsDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/permissions - Asignando permisos.", id);
            await _roleService.AssignPermissionsAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Activa o desactiva un rol. Requiere permiso ROLES_UPDATE.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpPut("{id:guid}/toggle-status")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            _logger.LogInformation("PUT /api/roles/{RoleId}/toggle-status", id);
            await _roleService.ToggleStatusAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Crea una copia exacta de un rol existente con un nuevo nombre. Requiere permiso ROLES_CREATE.
        /// </summary>
        /// <param name="id">ID del rol origen.</param>
        /// <param name="dto">Nombre para el nuevo rol.</param>
        /// <returns>El nuevo rol duplicado.</returns>
        [HttpPost("{id:guid}/duplicate")]
        [HasPermission("ROLES_CREATE")]
        public async Task<IActionResult> Duplicate(Guid id, [FromBody] DuplicateRoleDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/duplicate - Nuevo nombre: '{NewName}'", id, dto.NewName);
            var role = await _roleService.DuplicateAsync(id, dto.NewName);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        /// <summary>
        /// Agrega permisos adicionales a un rol sin eliminar los actuales. Requiere permiso ROLES_UPDATE.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <param name="dto">Lista de permisos a agregar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpPost("{id:guid}/permissions/add")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> AddPermissions(Guid id, [FromBody] AssignPermissionsDto dto)
        {
            _logger.LogInformation("POST /api/roles/{RoleId}/permissions/add - Agregando permisos.", id);
            await _roleService.AddPermissionsAsync(id, dto.PermissionIds);
            return NoContent();
        }

        /// <summary>
        /// Quita permisos específicos de un rol. Requiere permiso ROLES_UPDATE.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <param name="dto">Lista de permisos a remover.</param>
        /// <returns>Sin contenido (NoContent).</returns>
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
