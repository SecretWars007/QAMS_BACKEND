// src/QAMS.Domain/Constants/CatalogConstants.cs
namespace QAMS.Domain.Constants
{
    public static class CatalogConstants
    {
        public static class ProjectPriority
        {
            public const string Low = "LOW";
            public const string Medium = "MEDIUM";
            public const string High = "HIGH";
            public const string Critical = "CRITICAL";
        }

        public static class RequirementType
        {
            public const string Functional = "FUNCTIONAL";
            public const string NonFunctional = "NON_FUNCTIONAL";
            public const string Technical = "TECHNICAL";
            public const string UserStory = "USER_STORY";
        }

        public static class RequirementPriority
        {
            public const string Low = "LOW";
            public const string Medium = "MEDIUM";
            public const string High = "HIGH";
            public const string Critical = "CRITICAL";
        }

        public static class RequirementComplexity
        {
            public const string Simple = "SIMPLE";
            public const string Moderate = "MODERATE";
            public const string Complex = "COMPLEX";
            public const string VeryComplex = "VERY_COMPLEX";
        }

        public static class RequirementStatus
        {
            public const string Draft = "DRAFT";
            public const string InReview = "IN_REVIEW";
            public const string Approved = "APPROVED";
            public const string Rejected = "REJECTED";
            public const string Implemented = "IMPLEMENTED";
            public const string Verified = "VERIFIED";
        }

        public static class PlatformType
        {
            public const string Web = "WEB";
            public const string Desktop = "DESKTOP";
            public const string DataProcessing = "DATA_PROCESSING";
        }

        public static class PlatformTypes
        {
            public const string Web = "WEB";
            public const string Desktop = "DESKTOP";
            public const string DataProcessing = "DATA_PROCESSING";
        }
    }
}
