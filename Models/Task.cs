using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Priority { get; set; }

    public DateTime? Deadline { get; set; }

    public ICollection<Tag>? Tags = new List<Tag>();

    public string? Status { get; set; }

    public ICollection<SubTask>? SubTasks = new List<SubTask>();
}
