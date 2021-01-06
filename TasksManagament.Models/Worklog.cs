using System;

namespace TasksManagement.Models
{
    public class Worklog
    {
        public int Id { get; set; }
        public int WorkedTime { get; set; }
        public Task Task { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime WorkedOn { get; set; }
    }
}
