// src/QAMS.Domain/Entities/TestSuiteTag.cs
namespace QAMS.Domain.Entities
{
    using QAMS.Domain.Entities.Catalogs;
    using System;

    public class TestSuiteTag
    {
        public Guid TestSuiteId { get; set; }
        public TestSuite? TestSuite { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
