// src/QAMS.Application/DTOs/Catalogs/CreateCatalogItemDto.cs
namespace QAMS.Application.DTOs.Catalogs
{
    public class CreateCatalogItemDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
