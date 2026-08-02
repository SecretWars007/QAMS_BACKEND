// src/QAMS.Api/Controllers/ReviewController.cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Reviews;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewController(IReviewService service, ILogger<ReviewController> logger) : ControllerBase
    {
        private readonly IReviewService _service = service;
        private readonly ILogger<ReviewController> _logger = logger;

        [HttpGet("{id:guid}")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/review/{ReviewId}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("project/{projectId:guid}")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/review/project/{ProjectId}", projectId);
            return Ok(await _service.GetByProjectIdAsync(projectId));
        }

        [HttpPost]
        [HasPermission("PROJECT_EDIT")]
        public async Task<IActionResult> Create([FromBody] CreateReviewSessionDto dto)
        {
            _logger.LogInformation("POST /api/review");
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPost("{id:guid}/start")]
        [HasPermission("PROJECT_EDIT")]
        public async Task<IActionResult> StartSession(Guid id)
        {
            _logger.LogInformation("POST /api/review/{ReviewId}/start", id);
            return Ok(await _service.StartSessionAsync(id));
        }

        [HttpPost("{id:guid}/complete")]
        [HasPermission("PROJECT_EDIT")]
        public async Task<IActionResult> CompleteSession(Guid id, [FromBody] CompleteReviewRequest request)
        {
            _logger.LogInformation("POST /api/review/{ReviewId}/complete", id);
            return Ok(await _service.CompleteSessionAsync(id, request.Conclusions, request.ExitCriteria));
        }

        [HttpPost("{id:guid}/cancel")]
        [HasPermission("PROJECT_EDIT")]
        public async Task<IActionResult> CancelSession(Guid id)
        {
            _logger.LogInformation("POST /api/review/{ReviewId}/cancel", id);
            return Ok(await _service.CancelSessionAsync(id));
        }

        [HttpPost("finding")]
        [HasPermission("TEST_EXECUTION_CREATE")]
        public async Task<IActionResult> AddFinding([FromBody] CreateReviewFindingDto dto)
        {
            _logger.LogInformation("POST /api/review/finding");
            var result = await _service.AddFindingAsync(dto);
            return Ok(result);
        }

        [HttpPut("finding/{findingId:guid}")]
        [HasPermission("TEST_EXECUTION_CREATE")]
        public async Task<IActionResult> UpdateFinding(Guid findingId, [FromBody] UpdateReviewFindingDto dto)
        {
            _logger.LogInformation("PUT /api/review/finding/{FindingId}", findingId);
            return Ok(await _service.UpdateFindingAsync(findingId, dto));
        }

        [HttpDelete("finding/{findingId:guid}")]
        [HasPermission("TEST_EXECUTION_CREATE")]
        public async Task<IActionResult> DeleteFinding(Guid findingId)
        {
            _logger.LogInformation("DELETE /api/review/finding/{FindingId}", findingId);
            await _service.DeleteFindingAsync(findingId);
            return NoContent();
        }
    }

    public class CompleteReviewRequest
    {
        public string Conclusions { get; set; } = string.Empty;
        public string ExitCriteria { get; set; } = string.Empty;
    }
}
