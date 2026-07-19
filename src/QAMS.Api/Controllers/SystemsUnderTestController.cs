// src/QAMS.Api/Controllers/SystemsUnderTestController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.SystemsUnderTest;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers;

[ApiController]
[Route("api/projects/{projectId}/systems-under-test")]
[Authorize]
public class SystemsUnderTestController(ISystemUnderTestService sutService) : ControllerBase
{
    [HttpGet]
    [HasPermission("SUT_VIEW")]
    public async Task<IActionResult> GetByProject(Guid projectId)
    {
        var suts = await sutService.GetByProjectIdAsync(projectId);
        return Ok(suts);
    }

    [HttpGet("{id}")]
    [HasPermission("SUT_VIEW")]
    public async Task<IActionResult> GetById(Guid projectId, Guid id)
    {
        var sut = await sutService.GetByIdAsync(id);
        if (sut == null || sut.ProjectId != projectId)
            return NotFound();
        return Ok(sut);
    }

    [HttpPost]
    [HasPermission("SUT_CREATE")]
    public async Task<IActionResult> Create(Guid projectId, [FromBody] CreateSystemUnderTestDto request)
    {
        if (projectId != request.ProjectId)
            return BadRequest("El ID del proyecto en la URL no coincide con el payload.");

        var created = await sutService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { projectId = created.ProjectId, id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [HasPermission("SUT_UPDATE")]
    public async Task<IActionResult> Update(Guid projectId, Guid id, [FromBody] UpdateSystemUnderTestDto request)
    {
        var existing = await sutService.GetByIdAsync(id);
        if (existing == null || existing.ProjectId != projectId)
            return NotFound();

        var updated = await sutService.UpdateAsync(id, request);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    [HasPermission("SUT_DELETE")]
    public async Task<IActionResult> Delete(Guid projectId, Guid id)
    {
        var existing = await sutService.GetByIdAsync(id);
        if (existing == null || existing.ProjectId != projectId)
            return NotFound();

        await sutService.DeleteAsync(id);
        return NoContent();
    }
}
