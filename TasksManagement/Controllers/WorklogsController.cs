using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksManagement.Context;
using TasksManagement.Filters;
using TasksManagement.Models;

namespace TasksManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuthorization]
    public class WorklogsController : ControllerBase
    {
        private readonly TaskMgmtDbContext _context;

        public WorklogsController(TaskMgmtDbContext context)
        {
            _context = context;
        }

        // GET: api/Worklogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worklog>>> GetWorklogs()
        {
            return await _context.Worklogs.ToListAsync();
        }

        // GET: api/Worklogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worklog>> GetWorklog(int id)
        {
            var worklog = await _context.Worklogs.FindAsync(id);

            if (worklog == null)
            {
                return NotFound();
            }

            return worklog;
        }

        // PUT: api/Worklogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorklog(int id, Worklog worklog)
        {
            if (id != worklog.Id)
            {
                return BadRequest();
            }

            _context.Entry(worklog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorklogExists(id))
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

        // POST: api/Worklogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Worklog>> PostWorklog(Worklog worklog)
        {
            _context.Worklogs.Add(worklog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorklog", new { id = worklog.Id }, worklog);
        }

        // DELETE: api/Worklogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worklog>> DeleteWorklog(int id)
        {
            var worklog = await _context.Worklogs.FindAsync(id);
            if (worklog == null)
            {
                return NotFound();
            }

            _context.Worklogs.Remove(worklog);
            await _context.SaveChangesAsync();

            return worklog;
        }

        private bool WorklogExists(int id)
        {
            return _context.Worklogs.Any(e => e.Id == id);
        }
    }
}
