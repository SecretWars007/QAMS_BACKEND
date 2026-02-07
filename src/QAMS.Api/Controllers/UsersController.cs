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
        public RolesController(IRoleService roleService) { _roleService = roleService; }

        [HttpGet]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetAll() => Ok(await _roleService.GetAllAsync());

        [HttpGet("{id:guid}")]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _roleService.GetByIdAsync(id));

        [HttpPost]
        [HasPermission("ROLES_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var role = await _roleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("ROLES_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateRoleDto dto)
            => Ok(await _roleService.UpdateAsync(id, dto));

        [HttpDelete("{id:guid}")]
        [HasPermission("ROLES_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        { await _roleService.DeleteAsync(id); return NoContent(); }

        [HttpPut("{roleId:guid}/permissions")]
        [HasPermission("ROLES_ASSIGN_PERMISSIONS")]
        public async Task<IActionResult> AssignPermissions(Guid roleId, [FromBody] AssignPermissionsDto dto)
        { await _roleService.AssignPermissionsAsync(roleId, dto); return NoContent(); }

        [HttpGet("permissions")]
        [HasPermission("ROLES_VIEW")]
        public async Task<IActionResult> GetAllPermissions()
            => Ok(await _roleService.GetAllPermissionsAsync());
    }
}
