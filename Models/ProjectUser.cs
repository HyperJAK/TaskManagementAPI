namespace TaskManagementAPI_proj.Models;

public class ProjectUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public string Role { get; set; }
}