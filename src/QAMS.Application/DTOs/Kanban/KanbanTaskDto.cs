// src/QAMS.Application/DTOs/Kanban/KanbanTaskDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class KanbanTaskDto
    {
        public Guid Id { get; set; }
        public Guid KanbanColumnId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? AssigneeId { get; set; }
        public string? AssigneeName { get; set; }
        public Guid? TestCaseId { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public string PriorityCode { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public int OrderIndex { get; set; }
    }
}
