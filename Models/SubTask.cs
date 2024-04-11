using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public class SubTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Completed { get; set; } = false!;

}
