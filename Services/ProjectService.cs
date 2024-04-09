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

    public Project Create(Project newProject)
    {
        _context.Projects.Add(newProject);
        _context.SaveChanges();

        return newProject;
    }

    public void AddTask(int projectId, Models.Task task)
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

        _context.Tasks.Add(task);

        _context.SaveChanges();
    }

    public void AddUser(int projectId, User user)
    {
        var projectToUpdate = _context.Projects.Find(projectId);

        if (projectToUpdate is null)
        {
            throw new InvalidOperationException("Project does not exist");
        }

        if (projectToUpdate.Users is null)
        {
            projectToUpdate.Users = new List<User>();
        }

        projectToUpdate.Users.Add(user);

        _context.Users.Add(user);

        _context.SaveChanges();
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