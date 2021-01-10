using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksManagement.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string Photo { get; set; }
    }
}
