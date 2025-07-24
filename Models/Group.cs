namespace TaskManagerApi.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}