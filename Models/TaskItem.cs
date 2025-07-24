namespace TaskManagerApi.Models
{
    public class TaskItem
    {
        //Task Data
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsDone { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;

        //Relations
        public int AssignedUserId { get; set; } //Foreign Key to User
        public User AssignedUser { get; set; } = null!; //Navigation

        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;        
    }
}