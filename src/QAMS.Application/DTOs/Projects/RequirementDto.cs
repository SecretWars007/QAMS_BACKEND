// src/QAMS.Application/DTOs/Projects/RequirementDto.cs
using System;

namespace QAMS.Application.DTOs.Projects
{
    public class RequirementDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        public string Code { get; set; } = string.Empty;
        public string? AcceptanceCriteria { get; set; }
        public int RequirementTypeId { get; set; }
        public string RequirementTypeName { get; set; } = string.Empty;
        public int RequirementPriorityId { get; set; }
        public string RequirementPriorityName { get; set; } = string.Empty;
        public int RequirementComplexityId { get; set; }
        public string RequirementComplexityName { get; set; } = string.Empty;
        public int RequirementStatusId { get; set; }
        public string RequirementStatusName { get; set; } = string.Empty;
        public string? Source { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
