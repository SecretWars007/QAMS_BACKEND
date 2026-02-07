// src/QAMS.Application/DTOs/Kanban/KanbanColumnDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class KanbanColumnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public List<KanbanTaskDto> Tasks { get; set; } = new();
    }
}
