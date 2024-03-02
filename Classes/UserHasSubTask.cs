using ClassFormWithDb.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TaskManagementAPI.Classes
{
    [Table("user_has_subtask")]
    public class TaskHasSubTask
    {
        [Key]
        public int IdHas { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public ClassFormWithDb.Classes.Task Task { get; set; }

        [ForeignKey("SubTask")]
        public int SubTaskId { get; set; }
        public SubTask SubTask { get; set; }
    }
}
