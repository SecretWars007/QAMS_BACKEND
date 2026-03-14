// src/QAMS.Application/DTOs/Auth/ChangePasswordRequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Auth
{
    /// <summary>
    /// DTO para que un usuario autenticado cambie su contraseña actual.
    /// </summary>
    public class ChangePasswordRequestDto
    {
        [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
