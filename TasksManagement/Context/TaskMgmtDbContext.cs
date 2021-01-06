using Microsoft.EntityFrameworkCore;
using TasksManagement.Models;

namespace TasksManagement.Context
{
    public class TaskMgmtDbContext : DbContext 
    {
        public TaskMgmtDbContext(DbContextOptions<TaskMgmtDbContext> options) : base(options)
        {
        }

        protected TaskMgmtDbContext()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Worklog> Worklogs { get; set; }
    }
}
