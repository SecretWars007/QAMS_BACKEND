// src/QAMS.Api/Controllers/DefectsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Extensions;
using QAMS.Application.DTOs.Defects;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/defects")]
    [Authorize] // Autenticación requerida
    public class DefectsController(IDefectService defectService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            var defects = await defectService.GetByProjectAsync(projectId);
            return Ok(defects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid id)
        {
            var defect = await defectService.GetByIdAsync(id);
            if (defect == null || defect.ProjectId != projectId) return NotFound();
            return Ok(defect);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid projectId, [FromBody] CreateDefectDto dto)
        {
            if (dto.ProjectId != projectId) return BadRequest("Project ID mismatch");
            var currentUserId = User.GetUserId();
            var created = await defectService.CreateAsync(currentUserId, dto);
            return CreatedAtAction(nameof(GetById), new { projectId = created.ProjectId, id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid projectId, Guid id, [FromBody] UpdateDefectDto dto)
        {
            var existing = await defectService.GetByIdAsync(id);
            if (existing == null || existing.ProjectId != projectId) return NotFound();
            
            var updated = await defectService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid projectId, Guid id)
        {
            var existing = await defectService.GetByIdAsync(id);
            if (existing == null || existing.ProjectId != projectId) return NotFound();

            await defectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
