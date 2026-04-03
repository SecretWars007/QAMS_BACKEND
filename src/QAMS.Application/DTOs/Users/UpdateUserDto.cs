using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// src/QAMS.Application/DTOs/Users/UpdateUserDto.cs
namespace QAMS.Application.DTOs.Users
{
    public class UpdateUserDto
    {
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "El documento de identidad no puede exceder los 20 caracteres.")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]+$", ErrorMessage = "Formato de documento de identidad no válido.")]
        public string? DocumentoIdentidad { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres.")]
        [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "El teléfono debe tener formato internacional (ej. +59171234567).")]
        public string? Telefono { get; set; }

        public bool? IsActive { get; set; }
        public List<Guid> RoleIds { get; set; } = [];
    }
}
