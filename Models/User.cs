using System;
using System.Collections.Generic;

namespace TaskManagementAPI_proj.Models;

public class User
{
    public int Id { get; set; }

    public string? ProfilePic { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public string? PassId { get; set; }

    public string? PlatformAccount { get; set; }

    public sbyte? Disabled { get; set; }

}
