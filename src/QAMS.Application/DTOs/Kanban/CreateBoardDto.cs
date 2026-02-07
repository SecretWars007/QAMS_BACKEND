// src/QAMS.Application/DTOs/Kanban/CreateBoardDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class CreateBoardDto
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
