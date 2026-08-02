// src/QAMS.Application/DTOs/Reviews/ReviewFindingDto.cs
using System;

namespace QAMS.Application.DTOs.Reviews
{
    public class ReviewFindingDto
    {
        public Guid Id { get; set; }
        public Guid ReviewSessionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }

        public int FindingTypeId { get; set; }
        public string FindingTypeCode { get; set; } = string.Empty;
        public string FindingTypeName { get; set; } = string.Empty;

        public int SeverityId { get; set; }
        public string SeverityCode { get; set; } = string.Empty;
        public string SeverityName { get; set; } = string.Empty;

        public int FindingStatusId { get; set; }
        public string FindingStatusCode { get; set; } = string.Empty;
        public string FindingStatusName { get; set; } = string.Empty;

        public Guid? AssignedToId { get; set; }
        public string? AssignedToName { get; set; }

        public string? Resolution { get; set; }
        public DateTime? ResolvedAt { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
