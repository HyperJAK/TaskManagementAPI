using TaskManagementAPI_proj.Models;
using TaskManagementAPI_proj.Data;
using Microsoft.EntityFrameworkCore;

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

    public void AddSubTask(int taskId, SubTask newSubTask)
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
    }


    public void UpdateTask(int taskId, Models.Task newTask)
    {
        var taskToUpdate = _context.Tasks.Find(taskId);

        if (taskToUpdate is null)
        {
            throw new InvalidOperationException("Task does not exist");
        }

        taskToUpdate = newTask;

        _context.Tasks.Update(taskToUpdate);

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var taskToDelete = _context.Tasks.Find(id);
        if (taskToDelete is not null)
        {
            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
        }
    }
}