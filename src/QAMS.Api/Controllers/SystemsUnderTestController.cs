// src/QAMS.Api/Controllers/SystemsUnderTestController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.SystemsUnderTest;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers;

[ApiController]
[Route("api/systems-under-test")]
[Authorize]
public class SystemsUnderTestController(ISystemUnderTestService sutService) : ControllerBase
{
    [HttpGet]
    [HasPermission("SUT_VIEW")]
    public async Task<IActionResult> GetAll()
    {
        var suts = await sutService.GetAllAsync();
        return Ok(suts);
    }

    [HttpGet("{id}")]
    [HasPermission("SUT_VIEW")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sut = await sutService.GetByIdAsync(id);
        if (sut == null)
            return NotFound();
        return Ok(sut);
    }

    [HttpPost]
    [Authorize(Roles = "QA Lead,Administrator")]
    [HasPermission("SUT_CREATE")]
    public async Task<IActionResult> Create([FromBody] CreateSystemUnderTestDto request)
    {
        var created = await sutService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "QA Lead,Administrator")]
    [HasPermission("SUT_UPDATE")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSystemUnderTestDto request)
    {
        var existing = await sutService.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        var updated = await sutService.UpdateAsync(id, request);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "QA Lead,Administrator")]
    [HasPermission("SUT_DELETE")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await sutService.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await sutService.DeleteAsync(id);
        return NoContent();
    }
}
