// src/QAMS.Application/DTOs/Defects/CreateDefectDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Defects
{
    public class CreateDefectDto
    {
        [Required(ErrorMessage = "El ProjectId es obligatorio.")]
        public Guid ProjectId { get; set; }

        /// <summary>Caso de prueba donde se detectó (opcional)</summary>
        public Guid? TestCaseId { get; set; }

        /// <summary>Ejecución específica donde se detectó (opcional)</summary>
        public Guid? TestExecutionId { get; set; }

        /// <summary>Paso de ejecución específico donde se falló (opcional)</summary>
        public Guid? TestExecutionStepResultId { get; set; }

        [Required(ErrorMessage = "El título del defecto es obligatorio.")]
        [StringLength(300, ErrorMessage = "El título no puede exceder los 300 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(3000)]
        public string? Description { get; set; }

        [StringLength(3000, ErrorMessage = "Los pasos para reproducir no pueden exceder 3000 caracteres.")]
        public string? StepsToReproduce { get; set; }

        [StringLength(2000)]
        public string? ActualResult { get; set; }

        [StringLength(2000)]
        public string? ExpectedResult { get; set; }

        [Required(ErrorMessage = "La prioridad del defecto es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La prioridad debe ser un valor válido.")]
        public int DefectPriorityId { get; set; }

        /// <summary>Estado inicial: si no se especifica, se usará OPEN (Id=1)</summary>
        public int DefectStatusId { get; set; } = 1;

        public Guid? AssignedToUserId { get; set; }
    }

    public class UpdateDefectDto
    {
        [StringLength(300)]
        public string? Title { get; set; }

        [StringLength(3000)]
        public string? Description { get; set; }

        [StringLength(3000)]
        public string? StepsToReproduce { get; set; }

        [StringLength(2000)]
        public string? ActualResult { get; set; }

        [StringLength(2000)]
        public string? ExpectedResult { get; set; }

        public int? DefectPriorityId { get; set; }
        public int? DefectStatusId { get; set; }
        public Guid? AssignedToUserId { get; set; }

        [StringLength(2000)]
        public string? ResolutionNotes { get; set; }
    }
}
