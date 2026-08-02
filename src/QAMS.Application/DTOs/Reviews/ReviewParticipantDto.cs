// src/QAMS.Application/DTOs/Reviews/ReviewParticipantDto.cs
using System;

namespace QAMS.Application.DTOs.Reviews
{
    public class ReviewParticipantDto
    {
        public Guid Id { get; set; }
        public Guid ReviewSessionId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Attended { get; set; }
        public DateTime InvitedAt { get; set; }
    }
}
