// src/QAMS.Application/DTOs/Kanban/CreateKanbanTaskDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class CreateKanbanTaskDto
    {
        public Guid KanbanColumnId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid? TestCaseId { get; set; }
        public int PriorityId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
