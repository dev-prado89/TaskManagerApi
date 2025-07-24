using TaskManagerApi.Models;

namespace TaskManagerApi.Dtos
{
    public class CreateTaskItemDto
    {
        public string Title { get; set; } = string.Empty;
        public int AssignedUserId { get; set; }
        public int GroupId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}