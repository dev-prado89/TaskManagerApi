using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerApi.Models;
using TaskManagerApi.Data;
using TaskManagerApi.Dtos;


namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll([FromQuery] int groupId)
        {
            var tasks = await _context.Tasks
                .Include(t => t.AssignedUser)
                .Where(t => t.GroupId == groupId)
                .Select(t => new TaskItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsDone = t.IsDone,
                    CreatedAt = t.CreatedAt,
                    AssignedUserName = t.AssignedUser.UserName
                })
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.AssignedUser)
                .Where(t => t.Id == id)
                .Select(t => new TaskItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsDone = t.IsDone,
                    CreatedAt = t.CreatedAt,
                    AssignedUserName = t.AssignedUser.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskItemDto dto)
        {
            if (!_context.Users.Any(u => u.Id == dto.AssignedUserId) || !_context.Groups.Any(g => g.Id == dto.GroupId))
                return BadRequest("Invalid user or group ID");

            var task = new TaskItem
            {
                Title = dto.Title,
                AssignedUserId = dto.AssignedUserId,
                GroupId = dto.GroupId,
                IsDone = false,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedByUserId = dto.CreatedByUserId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            var log = new TaskActionLog
            {
                TaskId = task.Id,
                Action = "Created",
                PerformedByUserId = task.CreatedByUserId,
                PerformedAt = DateTimeOffset.UtcNow
            };

            _context.TaskActionLogs.Add(log);
            await _context.SaveChangesAsync();

            var createdTask = await _context.Tasks
                .Include(t => t.AssignedUser)
                .Where(t => t.Id == task.Id)
                .Select(t => new TaskItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsDone = t.IsDone,
                    CreatedAt = t.CreatedAt,
                    AssignedUserName = t.AssignedUser.UserName
                })
                .FirstOrDefaultAsync();

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, createdTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            var log = new TaskActionLog
            {
                TaskId = task.Id,
                Action = "Deleted",
                PerformedByUserId = task.CreatedByUserId, //temporal
                PerformedAt = DateTimeOffset.UtcNow
            };
            _context.TaskActionLogs.Add(log);
   
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}