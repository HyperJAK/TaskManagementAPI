using TaskManagementAPI_proj.Models;
using TaskManagementAPI_proj.Data;
using Microsoft.EntityFrameworkCore;
using Task = TaskManagementAPI_proj.Models.Task;

namespace TaskManagementAPI_proj.Services;

public class TaskService
{
    private readonly TaskManagerContext _context;

    public TaskService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<Models.Task> GetAll()
    {
        return _context.Tasks
            .AsNoTracking()
            .ToList();
    }

    public Models.Task? GetById(int id)
    {
        return _context.Tasks
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Models.Task Create(Models.Task newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public SubTask AddSubTask(int taskId, SubTask newSubTask)
    {
        var taskToUpdate = _context.Tasks.Find(taskId);

        if (taskToUpdate is null)
        {
            throw new InvalidOperationException("Task does not exist");
        }

        if (taskToUpdate.SubTasks is null)
        {
            taskToUpdate.SubTasks = new List<SubTask>();
        }

        taskToUpdate.SubTasks.Add(newSubTask);

        _context.SubTasks.Add(newSubTask);

        _context.SaveChanges();

        return newSubTask;
    }

    public Tag AddTag(int taskId, Tag newTag)
    {
        var taskToUpdate = _context.Tasks.Find(taskId);

        if (taskToUpdate is null)
        {
            throw new InvalidOperationException("Task does not exist");
        }

        if (taskToUpdate.Tags is null)
        {
            taskToUpdate.Tags = new List<Tag>();
        }

        taskToUpdate.Tags.Add(newTag);

        _context.Tags.Add(newTag);

        _context.SaveChanges();

        return newTag;
    }

    public IEnumerable<SubTask> GetTaskSubTasks(int id)
    {
        return _context.Tasks
        .Include(p => p.SubTasks)
        .Where(p => p.Id == id)
       .SelectMany(u => u.SubTasks)
       .AsNoTracking()
       .ToList();
    }

    public IEnumerable<Tag> GetTaskTags(int id)
    {
        return _context.Tasks
        .Include(p => p.Tags)
        .Where(p => p.Id == id)
       .SelectMany(u => u.Tags)
       .AsNoTracking()
       .ToList();
    }


    public Task UpdateTask(int taskId, Models.Task newTask)
    {
        var taskToUpdate = _context.Tasks.Find(taskId);

        if (taskToUpdate is null)
        {
            throw new InvalidOperationException("Task does not exist");
        }

        taskToUpdate = newTask;

        _context.Tasks.Update(taskToUpdate);

        _context.SaveChanges();

        return taskToUpdate;
    }

    public void DeleteAllSubTasks(int id)
    {
        var taskToDelete = _context.Tasks.Include(t => t.SubTasks).FirstOrDefault(t => t.Id == id);

    if (taskToDelete != null && taskToDelete.SubTasks.Any())
    {
        while (taskToDelete.SubTasks.Any())
        {
            var subTaskToRemove = taskToDelete.SubTasks.First();
            taskToDelete.SubTasks.Remove(subTaskToRemove);
        }
        
        _context.SaveChanges();
    }

    }


    public Task DeleteById(int id)
    {
        var taskToDelete = _context.Tasks.Find(id);
        var tempSaved = taskToDelete;
        if (taskToDelete is not null)
        {
            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();

            return tempSaved;
        }
        return tempSaved;
    }
}