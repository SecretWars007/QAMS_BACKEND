using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.TestPlans;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestPlansController : ControllerBase
    {
        private readonly ITestPlanService _testPlanService;

        public TestPlansController(ITestPlanService testPlanService)
        {
            _testPlanService = testPlanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestPlanDto>>> GetAll()
        {
            var plans = await _testPlanService.GetAllAsync();
            return Ok(plans);
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<TestPlanDto>>> GetByProject(Guid projectId)
        {
            var plans = await _testPlanService.GetByProjectAsync(projectId);
            return Ok(plans);
        }

        [HttpGet("sut/{sutId}")]
        public async Task<ActionResult<IEnumerable<TestPlanDto>>> GetBySut(Guid sutId)
        {
            var plans = await _testPlanService.GetBySutAsync(sutId);
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestPlanDto>> GetById(Guid id)
        {
            var plan = await _testPlanService.GetByIdAsync(id);
            return Ok(plan);
        }

        [HttpPost]
        public async Task<ActionResult<TestPlanDto>> Create([FromBody] CreateTestPlanDto dto)
        {
            var plan = await _testPlanService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = plan.Id }, plan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TestPlanDto>> Update(Guid id, [FromBody] UpdateTestPlanDto dto)
        {
            var plan = await _testPlanService.UpdateAsync(id, dto);
            return Ok(plan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _testPlanService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/approve")]
        [HasPermission("TEST_CASES_UPDATE")]
        public async Task<IActionResult> Approve(Guid id, [FromBody] ApproveTestPlanDto dto)
        {
            await _testPlanService.ApproveAsync(id, dto);
            return Ok();
        }
    }
}
