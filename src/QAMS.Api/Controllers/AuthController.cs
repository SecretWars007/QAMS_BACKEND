// src/QAMS.Api/Controllers/AuthController.cs
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Application.DTOs.Auth;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>POST api/auth/login</summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/login - Usuario: {Username}", request.Username);
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }

        /// <summary>POST api/auth/register</summary>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/register - Usuario: {Username}", request.Username);
            var result = await _authService.RegisterAsync(request);
            return Created("", result);
        }

        /// <summary>POST api/auth/refresh</summary>
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/refresh");
            var result = await _authService.RefreshTokenAsync(request);
            return Ok(result);
        }

        /// <summary>POST api/auth/logout</summary>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            _logger.LogInformation("POST /api/auth/logout - UserId: {UserId}", userId);
            await _authService.RevokeRefreshTokenAsync(userId);
            return NoContent();
        }
    }
}
