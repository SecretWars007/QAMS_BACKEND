// src/QAMS.Application/DTOs/Reviews/CreateReviewFindingDto.cs
using System;

namespace QAMS.Application.DTOs.Reviews
{
    public class CreateReviewFindingDto
    {
        public Guid ReviewSessionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public int FindingTypeId { get; set; }
        public int SeverityId { get; set; }
        public int FindingStatusId { get; set; } = 1; // OPEN
        public Guid? AssignedToId { get; set; }
    }
}
