// src/QAMS.Application/DTOs/Auth/ForgotPasswordRequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Auth
{
    /// <summary>
    /// DTO para solicitar el restablecimiento de contraseña mediante correo electrónico.
    /// </summary>
    public class ForgotPasswordRequestDto
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;
    }
}
