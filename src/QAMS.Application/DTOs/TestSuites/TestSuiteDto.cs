namespace QAMS.Application.DTOs.TestSuites
{
    public class TestSuiteDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public int TestCaseCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
