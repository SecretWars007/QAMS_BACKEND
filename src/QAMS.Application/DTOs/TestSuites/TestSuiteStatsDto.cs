namespace QAMS.Application.DTOs.TestSuites
{
    public class TestSuiteStatsDto
    {
        public Guid SuiteId { get; set; }
        public string SuiteName { get; set; } = string.Empty;
        public int TotalTestCases { get; set; }
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
        public int BlockedCount { get; set; }
        public int PendingCount { get; set; }
        public decimal PassRate => TotalTestCases > 0 ? (decimal)PassedCount / TotalTestCases * 100 : 0;
    }
}
