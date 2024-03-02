using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementAPI.Classes;
using TaskManagementAPI.Classes.Database;

namespace ClassFormWithDb.Classes
{
    [Table("subtask")]
    public class SubTask
    {
        [Column("subTaskId")]
        [Key]
        public int SubTaskId { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [InverseProperty("SubTask")]
        public List<TaskHasSubTask> TaskHasSubTasks { get; set; }
    }

}
