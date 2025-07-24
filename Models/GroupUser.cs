namespace TaskManagerApi.Models
{
    public class GroupUser
    {
        public int Id { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; } = null!;

        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }
}