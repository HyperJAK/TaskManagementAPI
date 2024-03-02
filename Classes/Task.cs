using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementAPI.Classes;
using TaskManagementAPI.Classes.Database;

namespace ClassFormWithDb.Classes
{
    [Table("task")]
    public class Task
    {
        [Column("taskId")]
        [Key]
        public int TaskId { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("priority")]
        public string Priority { get; set; }

        [Column("deadline")]
        public DateTime? Deadline { get; set; }

        [Column("category_category_id")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [InverseProperty("Task")]
        public List<UserHasTask> UserHasTasks { get; set; }

        [InverseProperty("Task")]
        public List<TaskHasSubTask> TaskHasSubTasks { get; set; }
    }

}
