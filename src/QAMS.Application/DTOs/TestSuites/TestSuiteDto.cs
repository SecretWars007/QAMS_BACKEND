namespace QAMS.Application.DTOs.TestSuites
{
    public class TestSuiteDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? TestPlanId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public int TestCaseCount { get; set; }
        
        // ISTQB Fields
        public int? ExecutionPriorityId { get; set; }
        public string? ExecutionPriorityName { get; set; }
        
        public int? TestLevelId { get; set; }
        public string? TestLevelName { get; set; }
        
        public int? TestTypeId { get; set; }
        public string? TestTypeName { get; set; }
        
        public int? AutomationStatusId { get; set; }
        public string? AutomationStatusName { get; set; }
        
        public int? TestDesignTechniqueId { get; set; }
        public string? TestDesignTechniqueName { get; set; }
        
        public int? ReviewStatusId { get; set; }
        public string? ReviewStatusName { get; set; }
        
        public int? TestEnvironmentId { get; set; }
        public string? TestEnvironmentName { get; set; }
        
        public Guid? OwnerUserId { get; set; }
        public string? OwnerName { get; set; }
        
        public string? Preconditions { get; set; }
        public string? CoverageObjective { get; set; }
        public decimal EstimatedDurationHours { get; set; }
        
        public List<string> Tags { get; set; } = new();

        // Execution Metrics (Real-time projection)
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
        public int BlockedCount { get; set; }
        public int PendingCount { get; set; }
        public int ExecutionProgress { get; set; } // percentage 0-100
        public DateTime? LastExecutionDate { get; set; }
        public int DefectCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
