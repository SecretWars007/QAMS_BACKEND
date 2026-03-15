// src/QAMS.Api/Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [HasPermission("USERS_VIEW")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET /api/users - Obteniendo todos los usuarios.");
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        [HasPermission("USERS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/users/{UserId}", id);
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [HasPermission("USERS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            _logger.LogInformation("POST /api/users - Creando usuario '{Username}'", dto.Username);
            var user = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("USERS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            _logger.LogInformation("PUT /api/users/{UserId} - Actualizando usuario.", id);
            var user = await _userService.UpdateAsync(id, dto);
            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        [HasPermission("USERS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/users/{UserId}", id);
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{userId:guid}/roles/{roleId:guid}")]
        [HasPermission("USERS_MANAGE_ROLES")]
        public async Task<IActionResult> AssignRole(Guid userId, Guid roleId)
        {
            _logger.LogInformation("POST /api/users/{UserId}/roles/{RoleId} - Asignando rol.", userId, roleId);
            await _userService.AssignRoleAsync(userId, roleId);
            return NoContent();
        }

        [HttpDelete("{userId:guid}/roles/{roleId:guid}")]
        [HasPermission("USERS_MANAGE_ROLES")]
        public async Task<IActionResult> RemoveRole(Guid userId, Guid roleId)
        {
            _logger.LogInformation("DELETE /api/users/{UserId}/roles/{RoleId} - Quitando rol.", userId, roleId);
            await _userService.RemoveRoleAsync(userId, roleId);
            return NoContent();
        }

        [HttpDelete("{userId:guid}/roles")]
        [HasPermission("USERS_MANAGE_ROLES")]
        public async Task<IActionResult> RemoveAllRoles(Guid userId)
        {
            _logger.LogInformation("DELETE /api/users/{UserId}/roles - Removiendo todos los roles.", userId);
            await _userService.RemoveAllRolesAsync(userId);
            return NoContent();
        }
    }
}
