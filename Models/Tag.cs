using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string? Color { get; set; }

}
