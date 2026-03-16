// src/QAMS.Application/DTOs/Auth/AdminResetPasswordDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Auth
{
    /// <summary>
    /// DTO para que un administrador restablezca la contraseña de cualquier usuario.
    /// </summary>
    public class AdminResetPasswordDto
    {
        [Required(ErrorMessage = "El UserId es obligatorio.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
