using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public class Project
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public int CreatorId { get; set; }

    public virtual ICollection<Task>? Tasks { get; set; } = new List<Task>();
    public virtual ICollection<ProjectUser>? ProjectUsers { get; set; } = new List<ProjectUser>();
}
