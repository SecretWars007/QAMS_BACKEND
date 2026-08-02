// src/QAMS.Application/DTOs/Reviews/ReviewSessionDto.cs
using System;
using System.Collections.Generic;

namespace QAMS.Application.DTOs.Reviews
{
    public class ReviewSessionDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ArtifactUnderReview { get; set; }
        
        public int ReviewTypeId { get; set; }
        public string ReviewTypeCode { get; set; } = string.Empty;
        public string ReviewTypeName { get; set; } = string.Empty;

        public int StatusId { get; set; }
        public string StatusCode { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;

        public DateTime? ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public Guid? ModeratorId { get; set; }
        public string? ModeratorName { get; set; }
        
        public Guid? AuthorId { get; set; }
        public string? AuthorName { get; set; }

        public string? EntryCriteria { get; set; }
        public string? ExitCriteria { get; set; }
        public string? Conclusions { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;

        public List<ReviewFindingDto> Findings { get; set; } = [];
        public List<ReviewParticipantDto> Participants { get; set; } = [];
    }
}
