// src/QAMS.Application/DTOs/Kanban/UpdateKanbanTaskDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class UpdateKanbanTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? AssigneeId { get; set; }
        public int PriorityId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
