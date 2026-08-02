// src/QAMS.Application/DTOs/Reviews/CreateReviewSessionDto.cs
using System;
using System.Collections.Generic;

namespace QAMS.Application.DTOs.Reviews
{
    public class CreateReviewSessionDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ArtifactUnderReview { get; set; }
        public int ReviewTypeId { get; set; }
        public int StatusId { get; set; } = 1; // PLANNED
        public DateTime? ScheduledDate { get; set; }
        
        public Guid? ModeratorId { get; set; }
        public Guid? AuthorId { get; set; }

        public string? EntryCriteria { get; set; }
        public string? ExitCriteria { get; set; }
        public string? Conclusions { get; set; }

        public List<Guid> ParticipantUserIds { get; set; } = [];
    }
}
