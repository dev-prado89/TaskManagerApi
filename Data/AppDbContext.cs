using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TaskManagerApi.Models;

namespace TaskManagerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }    
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TaskActionLog> TaskActionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                        .HasKey(gu => new { gu.UserId, gu.GroupId });

            modelBuilder.Entity<TaskItem>()
                        .HasOne(t => t.AssignedUser)
                        .WithMany()
                        .HasForeignKey(t => t.AssignedUserId);

            modelBuilder.Entity<TaskItem>()
                        .HasOne(t => t.CreatedByUser)
                        .WithMany()
                        .HasForeignKey(t => t.CreatedByUserId);

            modelBuilder.Entity<TaskItem>()
                        .HasOne(t => t.Group)
                        .WithMany()
                        .HasForeignKey(t => t.GroupId);

            modelBuilder.Entity<TaskActionLog>()
                        .HasOne(l => l.Task)
                        .WithMany()
                        .HasForeignKey(l => l.TaskId);

            modelBuilder.Entity<TaskActionLog>()
                        .HasOne(l => l.PerformedByUser)
                        .WithMany()
                        .HasForeignKey(l => l.PerformedByUserId);
        }
    }
}