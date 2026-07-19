// src/QAMS.Api/Models/TestExecutions/UploadEvidenceRequest.cs
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace QAMS.Api.Models.TestExecutions
{
    public class UploadEvidenceRequest
    {
        [Required(ErrorMessage = "El archivo es obligatorio.")]
        public IFormFile File { get; set; } = null!;

        public string? Description { get; set; }

        public Guid? StepResultId { get; set; }
    }
}
