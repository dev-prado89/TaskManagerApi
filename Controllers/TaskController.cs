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
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll()
        {
            var tasks = await _context.Tasks
                .Include(t => t.AssignedUser)
                .Include(t => t.Group)
                .Select(t => new TaskItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsDone = t.IsDone,
                    CreatedAt = t.CreatedAt,
                    AssignedUserName = t.AssignedUser.UserName,
                    GroupName = t.Group.Name
                })
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.AssignedUser)
                .Include(t => t.Group)
                .Where(t => t.Id == id)
                .Select(t => new TaskItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsDone = t.IsDone,
                    CreatedAt = t.CreatedAt,
                    AssignedUserName = t.AssignedUser.UserName,
                    GroupName = t.Group.Name
                })
                .FirstOrDefaultAsync();

            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskItemDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                AssignedUserId = dto.AssignedUserId,
                GroupId = dto.GroupId,
                IsDone = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
   
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}