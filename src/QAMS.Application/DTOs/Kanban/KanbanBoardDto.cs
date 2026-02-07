// src/QAMS.Application/DTOs/Kanban/KanbanBoardDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class KanbanBoardDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<KanbanColumnDto> Columns { get; set; } = new();
    }
}
