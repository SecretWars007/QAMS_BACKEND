// src/QAMS.Api/Controllers/UsersController.cs
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController(IUserService userService, ILogger<UsersController> logger) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ILogger<UsersController> _logger = logger;

        /// <summary>
        /// Obtiene la lista de todos los usuarios registrados. Requiere permiso USERS_VIEW.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        [HttpGet]
        [HasPermission("USERS_VIEW")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET /api/users - Obteniendo todos los usuarios.");
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Obtiene el perfil detallado de un usuario por su ID. Requiere permiso USERS_VIEW.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Detalle del usuario y sus roles.</returns>
        [HttpGet("{id:guid}")]
        [HasPermission("USERS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/users/{UserId}", id);
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        /// <summary>
        /// Crea un nuevo usuario en el sistema. Requiere permiso USERS_CREATE.
        /// </summary>
        /// <param name="dto">Datos del usuario (Username, Email, etc.).</param>
        /// <returns>El usuario creado.</returns>
        [HttpPost]
        [HasPermission("USERS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            _logger.LogInformation("POST /api/users - Creando usuario '{Username}'", dto.Username);
            var user = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Actualiza la información de un usuario existente. Requiere permiso USERS_UPDATE.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <param name="dto">Nuevos datos del perfil.</param>
        /// <returns>El usuario actualizado.</returns>
        [HttpPut("{id:guid}")]
        [HasPermission("USERS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            _logger.LogInformation("PUT /api/users/{UserId} - Actualizando usuario.", id);
            var user = await _userService.UpdateAsync(id, dto);
            return Ok(user);
        }

        /// <summary>
        /// Realiza una desactivación lógica del usuario. Requiere permiso USERS_DELETE.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{id:guid}")]
        [HasPermission("USERS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/users/{UserId}", id);
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Asigna un rol específico a un usuario. Requiere permiso USERS_ASSIGN_ROLES.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="roleId">ID del rol a asignar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpPost("{userId:guid}/roles/{roleId:guid}")]
        [HasPermission("USERS_ASSIGN_ROLES")]
        public async Task<IActionResult> AssignRole(Guid userId, Guid roleId)
        {
            _logger.LogInformation("POST /api/users/{UserId}/roles/{RoleId} - Asignando rol.", userId, roleId);
            await _userService.AssignRoleAsync(userId, roleId);
            return NoContent();
        }

        /// <summary>
        /// Remueve un rol específico de un usuario. Requiere permiso USERS_ASSIGN_ROLES.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="roleId">ID del rol a remover.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{userId:guid}/roles/{roleId:guid}")]
        [HasPermission("USERS_ASSIGN_ROLES")]
        public async Task<IActionResult> RemoveRole(Guid userId, Guid roleId)
        {
            _logger.LogInformation("DELETE /api/users/{UserId}/roles/{RoleId} - Quitando rol.", userId, roleId);
            await _userService.RemoveRoleAsync(userId, roleId);
            return NoContent();
        }

        /// <summary>
        /// Limpia todos los roles asociados a un usuario. Requiere permiso USERS_ASSIGN_ROLES.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{userId:guid}/roles")]
        [HasPermission("USERS_ASSIGN_ROLES")]
        public async Task<IActionResult> RemoveAllRoles(Guid userId)
        {
            _logger.LogInformation("DELETE /api/users/{UserId}/roles - Removiendo todos los roles.", userId);
            await _userService.RemoveAllRolesAsync(userId);
            return NoContent();
        }
    }
}
