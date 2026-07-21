// src/QAMS.Application/DTOs/TestPlans/TestPlanCriteriaDto.cs
using System;

namespace QAMS.Application.DTOs.TestPlans
{
    public class TestPlanCriteriaDto
    {
        public Guid Id { get; set; }
        public Guid TestPlanId { get; set; }

        /// <summary>
        /// "ENTRY" o "EXIT"
        /// </summary>
        public string CriteriaType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsMet { get; set; }
    }
}
