// src/QAMS.Application/DTOs/Auth/ResetPasswordRequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Auth
{
    /// <summary>
    /// DTO para restablecer la contraseña usando el token recibido por correo.
    /// </summary>
    public class ResetPasswordRequestDto
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El token de restablecimiento es obligatorio.")]
        public string ResetToken { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
