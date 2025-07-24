using System.Collections.Generic;

namespace TaskManagerApi.Models
{
    public class User
    {
    //User Data
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    //Relations
    public ICollection<GroupUser> GroupsUsers { get; set; } = new List<GroupUser>();
    }
}