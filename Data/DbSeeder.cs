using TaskManagerApi.Models;

namespace TaskManagerApi.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var user1 = new User { UserName = "pablo", Email = "pablo@grupo.com" };
                var user2 = new User { UserName = "javier", Email = "javier@grupo.com" };
                var user3 = new User { UserName = "marina", Email = "marina@grupo.com" };

                context.Users.AddRange(user1, user2, user3);
                context.SaveChanges();
            }

            if (!context.Groups.Any())
            {
                var group = new Group { Name = "Familia Prado" };
                context.Groups.Add(group);
                context.SaveChanges();

                var users = context.Users.ToList();
                var groupUsers = users.Select(u => new GroupUser
                {
                    GroupId = group.Id,
                    UserId = u.Id,
                    IsAdmin = u.UserName == "pablo" // solo Pablo es admin
                });

                context.GroupUsers.AddRange(groupUsers);
                context.SaveChanges();


                Console.WriteLine("✔ Se cargaron los usuarios iniciales.");
            }

            if (!context.Tasks.Any())
            {
                var user = context.Users.First();
                var group = context.Groups.First();

                var task = new TaskItem
                {
                    Title = "Sacar la basura",
                    IsDone = false,
                    CreatedAt = DateTimeOffset.UtcNow,
                    CreatedByUserId = user.Id,
                    AssignedUserId = user.Id,
                    GroupId = group.Id
                };

                context.Tasks.Add(task);
                context.SaveChanges();

                Console.WriteLine("✔ Se cargaron las tareas iniciales.");
            }
        }
    }
}