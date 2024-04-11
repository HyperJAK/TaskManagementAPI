using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Priority { get; set; }

    public DateTime? Deadline { get; set; }

    public virtual ICollection<Tag>? Tags { get; set; } = new List<Tag>();

    public string? Status { get; set; }

    public virtual ICollection<SubTask>? SubTasks { get; set; } = new List<SubTask>();
}
