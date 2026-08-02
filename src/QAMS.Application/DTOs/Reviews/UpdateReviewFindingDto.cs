// src/QAMS.Application/DTOs/Reviews/UpdateReviewFindingDto.cs
using System;

namespace QAMS.Application.DTOs.Reviews
{
    public class UpdateReviewFindingDto
    {
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? FindingTypeId { get; set; }
        public int? SeverityId { get; set; }
        public int? FindingStatusId { get; set; }
        public Guid? AssignedToId { get; set; }
        public string? Resolution { get; set; }
        public bool IsResolved { get; set; }
    }
}
