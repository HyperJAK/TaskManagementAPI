using TaskManagementAPI_proj.Models;
using TaskManagementAPI_proj.Data;
using Microsoft.EntityFrameworkCore;
using Task = TaskManagementAPI_proj.Models.Task;

namespace TaskManagementAPI_proj.Services;

public class ProjectService
{
    private readonly TaskManagerContext _context;

    public ProjectService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<Project> GetAll()
    {
        return _context.Projects
            .AsNoTracking()
            .ToList();
    }

    public Project? GetById(int id)
    {
        return _context.Projects
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Task> GetProjectTasks(int id)
    {
        return _context.Projects
        .Where(p => p.Id == id)
       .SelectMany(u => u.Tasks)
       .AsNoTracking()
       .ToList();
    }

    public string GetUserRole(int id, int userId)
    {
        return _context.ProjectUsers
        .Where(p => p.ProjectId == id && p.UserId == userId)
        .Select(u => u.Role)
        .FirstOrDefault();
    }

    public IEnumerable<Project> GetProjectsByContainedUser(int userId)
{
    return _context.Projects
        .Where(p => p.ProjectUsers.Any(u => u.UserId == userId))
        .ToList();
}

    public Project Create(Project newProject)
    {
        _context.Projects.Add(newProject);
        _context.SaveChanges();

        return newProject;
    }

    public Task AddTask(int projectId, Models.Task task)
    {
        var projectToUpdate = _context.Projects.Find(projectId);

        if (projectToUpdate is null)
        {
            throw new InvalidOperationException("Project does not exist");
        }

        if (projectToUpdate.Tasks is null)
        {
            projectToUpdate.Tasks = new List<Models.Task>();
        }

        projectToUpdate.Tasks.Add(task);

        _context.SaveChanges();

        return task;
    }

    public ProjectUser AddUser(int projectId, string email, string role)
{
    var projectToUpdate = _context.Projects.Include(p => p.ProjectUsers).FirstOrDefault(p => p.Id == projectId);
    var userToAdd = _context.Users.FirstOrDefault(u => u.Email == email);

    if (projectToUpdate is null)
    {
        throw new InvalidOperationException("Project does not exist");
    }

    if (userToAdd is null)
    {
        throw new InvalidOperationException("User does not exist");
    }

    if (projectToUpdate.ProjectUsers is null)
    {
        projectToUpdate.ProjectUsers = new List<ProjectUser>();
    }

    if (!projectToUpdate.ProjectUsers.Any(u => u.UserId == userToAdd.Id))
    {
        var projectUser = new ProjectUser
        {
            User = userToAdd,
            Project = projectToUpdate,
            Role = role
        };

        projectToUpdate.ProjectUsers.Add(projectUser);
        _context.SaveChanges();

        return projectUser;
    }

    return null;
    
}


    public void UpdateProject(int projectId, Project newProject)
    {
        var projectToUpdate = _context.Projects.Find(projectId);

        if (projectToUpdate is null)
        {
            throw new InvalidOperationException("Project does not exist");
        }

        projectToUpdate = newProject;

        _context.Projects.Update(projectToUpdate);

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var projectToDelete = _context.Projects.Find(id);
        if (projectToDelete is not null)
        {
            _context.Projects.Remove(projectToDelete);
            _context.SaveChanges();
        }
    }
}