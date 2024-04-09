using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public partial class SubTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Status { get; set; }

}
