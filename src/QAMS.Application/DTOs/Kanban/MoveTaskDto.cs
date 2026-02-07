// src/QAMS.Application/DTOs/Kanban/MoveTaskDto.cs
namespace QAMS.Application.DTOs.Kanban
{
    public class MoveTaskDto
    {
        public Guid TargetColumnId { get; set; }
        public int NewOrderIndex { get; set; }
    }
}
