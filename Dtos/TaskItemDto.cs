using TaskManagerApi.Models;

namespace TaskManagerApi.Dtos
{
    public class TaskItemDto
    {
        public int Id{get;set;}
        public string Title {get;set;} = string.Empty;
        public bool IsDone {get;set;}
        public DateTime CreatedAt {get;set;}
        public string AssignedUserName {get;set;} = string.Empty;
        public string GroupName {get;set;} = string.Empty;
    }
}