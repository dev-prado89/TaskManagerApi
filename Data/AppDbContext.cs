using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TaskManagerApi.Models;

namespace TaskManagerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<GroupUser> GroupUsers => Set<GroupUser>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                        .HasKey(gu => new { gu.UserId, gu.GroupId });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Pablo" },
                new User { Id = 2, UserName = "Romina" }
                );

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "CasaPrado" }
                );
        }
    }
}