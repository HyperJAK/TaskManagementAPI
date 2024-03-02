using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ClassFormWithDb.Classes;

namespace TaskManagementAPI.Classes
{
    [Table("user_has_task")]
    public class UserHasTask
    {
        [Key]
        public int IdHas { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public ClassFormWithDb.Classes.Task Task { get; set; }
    }
}
