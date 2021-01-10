using System;

namespace TasksManagement.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string Photo { get; set; }
    }
}
