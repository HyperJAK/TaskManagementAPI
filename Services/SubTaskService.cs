using TaskManagementAPI_proj.Models;
using TaskManagementAPI_proj.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI_proj.Services;

public class SubTaskService
{
    private readonly TaskManagerContext _context;

    public SubTaskService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<SubTask> GetAll()
    {
        return _context.SubTasks
            .AsNoTracking()
        .ToList();
    }

    public SubTask? GetById(int id)
    {
        return _context.SubTasks
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public SubTask Create(SubTask newSubTask)
    {
        _context.SubTasks.Add(newSubTask);
        _context.SaveChanges();

        return newSubTask;
    }

    /*public void AddNothing(int pizzaId, int toppingId)
    {
        var pizzaToUpdate = _context.Pizzas.Find(pizzaId);
        var toppingToAdd = _context.Toppings.Find(toppingId);

        if (pizzaToUpdate is null || toppingToAdd is null)
        {
            throw new InvalidOperationException("Pizza or topping does not exist");
        }

        if(pizzaToUpdate.Toppings is null)
        {
            pizzaToUpdate.Toppings = new List<Topping>();
        }

        pizzaToUpdate.Toppings.Add(toppingToAdd);

        _context.SaveChanges();
    }*/


    public SubTask UpdateSubTask(int subTaskId, SubTask newSubTask)
    {
        var subTaskToUpdate = _context.SubTasks.Find(subTaskId);

        if (subTaskToUpdate is null)
        {
            throw new InvalidOperationException("SubTask does not exist");
        }

        subTaskToUpdate.Name = newSubTask.Name;
        subTaskToUpdate.Completed = newSubTask.Completed;

    _context.SubTasks.Update(subTaskToUpdate);

        _context.SaveChanges();

        return newSubTask;
    }

    public void DeleteById(int id)
    {
        var subTaskToDelete = _context.SubTasks.Find(id);
        if (subTaskToDelete is not null)
        {
            _context.SubTasks.Remove(subTaskToDelete);
            _context.SaveChanges();
        }
    }
}