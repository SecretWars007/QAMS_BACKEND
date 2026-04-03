// src/QAMS.Api/Controllers/AuthController.cs
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Auth;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService, IUserService userService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly IUserService _userService = userService;
        private readonly ILogger<AuthController> _logger = logger;

        /// <summary>
        /// Inicia sesión en el sistema.
        /// </summary>
        /// <param name="request">Credenciales del usuario.</param>
        /// <returns>Token JWT y datos básicos del usuario.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/login - Usuario: {Username}", request.Username);
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="request">Datos del nuevo usuario.</param>
        /// <returns>Datos del usuario recién creado.</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/register - Usuario: {Username}", request.Username);
            var result = await _authService.RegisterAsync(request);
            return Created("", result);
        }

        /// <summary>
        /// Renueva el Access Token usando un Refresh Token válido.
        /// </summary>
        /// <param name="request">Refresh Token actual.</param>
        /// <returns>Nuevo par de tokens (Access y Refresh).</returns>
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/refresh");
            var result = await _authService.RefreshTokenAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Cierra la sesión del usuario actual, invalidando su Refresh Token.
        /// </summary>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            _logger.LogInformation("POST /api/auth/logout - UserId: {UserId}", userId);
            await _authService.RevokeRefreshTokenAsync(userId);
            return NoContent();
        }

        /// <summary>
        /// POST api/auth/forgot-password
        /// Recibe el correo electrónico registrado y genera un token temporal de restablecimiento.
        /// En producción el token se envía por email; en desarrollo se incluye en la respuesta.
        /// </summary>
        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/forgot-password - Email: {Email}", request.Email);
            var token = await _authService.ForgotPasswordAsync(request);

            // Si el email no existe devolvemos la misma respuesta neutra (no revelar que no existe)
            if (string.IsNullOrEmpty(token))
                return Ok(new { message = "Si el correo existe en el sistema, recibirás instrucciones para restablecer tu contraseña." });

            // TODO: en producción enviar por email (ya implementado en AuthService)
            return Ok(new
            {
                message = "Si el correo existe, recibirás instrucciones para restablecer tu contraseña dentro de los próximos 15 minutos."
            });
        }

        /// <summary>
        /// POST api/auth/reset-password
        /// Restablece la contraseña usando el token temporal obtenido en forgot-password.
        /// </summary>
        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request)
        {
            _logger.LogInformation("POST /api/auth/reset-password - Email: {Email}", request.Email);
            await _authService.ResetPasswordAsync(request);
            return Ok(new { message = "Contraseña restablecida exitosamente. Ya puedes iniciar sesión con tu nueva contraseña." });
        }

        /// <summary>
        /// POST api/auth/change-password
        /// Permite a un usuario autenticado cambiar su contraseña proporcionando la actual y la nueva.
        /// </summary>
        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto request)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            _logger.LogInformation("POST /api/auth/change-password - UserId: {UserId}", userId);
            await _authService.ChangePasswordAsync(userId, request);
            return Ok(new { message = "Contraseña actualizada exitosamente." });
        }

        /// <summary>
        /// POST api/auth/admin-reset-password
        /// Permite a un administrador restablecer la contraseña de cualquier usuario.
        /// </summary>
        [HttpPost("admin-reset-password")]
        [Authorize]
        [HasPermission("USERS_UPDATE")]
        public async Task<IActionResult> AdminResetPassword([FromBody] AdminResetPasswordDto request)
        {
            _logger.LogInformation("AdminResetPassword solicitado para el usuario {UserId}.", request.UserId);

            await _userService.ResetPasswordAsync(request.UserId, request.NewPassword);

            return Ok(new { message = "Contraseña restablecida exitosamente por el administrador." });
        }
    }
}
