// src/QAMS.Api/Models/TestExecutions/ObservationRequest.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace QAMS.Api.Models.TestExecutions
{
    public class ObservationRequest
    {
        [Required]
        public Guid ExecutionStepResultId { get; set; }

        [Required]
        public string Observation { get; set; } = string.Empty;

        public IFormFile? File { get; set; }
    }
}
