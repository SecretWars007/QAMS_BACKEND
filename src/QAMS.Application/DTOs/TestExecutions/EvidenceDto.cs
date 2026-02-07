// src/QAMS.Application/DTOs/TestExecutions/EvidenceDto.cs
namespace QAMS.Application.DTOs.TestExecutions
{
    public class EvidenceDto
    {
        public Guid Id { get; set; }
        public int FileTypeId { get; set; }
        public string FileTypeName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
