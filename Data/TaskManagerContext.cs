using Microsoft.EntityFrameworkCore;
using TaskManagementAPI_proj.Models;

namespace TaskManagementAPI_proj.Data;

public class TaskManagerContext : DbContext
{
    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskManagementAPI_proj.Models.Task> Tasks => Set<TaskManagementAPI_proj.Models.Task>();
    public DbSet<SubTask> SubTasks => Set<SubTask>();

    public DbSet<Tag> Tags => Set<Tag>();

}