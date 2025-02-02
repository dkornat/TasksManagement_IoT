﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksManagement.Context;
using TasksManagement.Filters;

namespace TasksManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuthorization]
    public class TasksController : ControllerBase
    {
        private readonly TaskMgmtDbContext _context;

        public TasksController(TaskMgmtDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks
        [HttpGet("{statusId}")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasksByStatus(int statusId)
        {
            if (statusId == 0)
                return await _context.Tasks.ToListAsync();
            else
                return await _context.Tasks.Where(task => task.StatusId == statusId).ToListAsync();
        }


        //GET: api/Tasks/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Models.Task>> GetTask(int id)
        //{
        //    var task = await _context.Tasks.FindAsync(id);

        //    if (task == null)
        //    {
        //        return NotFound();
        //    }

        //    return task;
        //}

        // PUT: api/Tasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.Task>> PostTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
