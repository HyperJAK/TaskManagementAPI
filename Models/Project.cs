using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public partial class Project
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<Task>? Tasks { get; set; } = new List<Task>();
    public virtual ICollection<User>? Users { get; set; } = new List<User>();
}
