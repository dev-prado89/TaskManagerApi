using System.Collections.Generic;

namespace TaskManagerApi.Models
{
    public class TaskActionLog
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Action { get; set; } = string.Empty;
        public int PerformedByUserId { get; set; }
        public DateTimeOffset PerformedAt { get; set; }

        //Relations
        public TaskItem Task { get; set; } = null!;
        public User PerformedByUser { get; set; } = null!;
    }
}