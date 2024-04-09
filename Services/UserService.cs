using TaskManagementAPI_proj.Models;
using TaskManagementAPI_proj.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI_proj.Services;

public class UserService
{
    private readonly TaskManagerContext _context;

    public UserService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users
            .AsNoTracking()
            .ToList();
    }

    public User? GetUserInfo(string email, string password)
    {
        return _context.Users
        .Where(u => u.Email == email && u.Password == password)
            .AsNoTracking()
            .SingleOrDefault();
    }

    public User? GetById(int id)
    {
        return _context.Users
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Project> GetUserProjects(int id)
    {
        return _context.Users
        .Where(u => u.Id == id)
       .SelectMany(u => u.Projects)
       .AsNoTracking()
       .ToList();
    }

    public User Create(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();

        return newUser;
    }

    //When adding a project for the user all we have to do is in the controller, we use the ProjectService object to create a project and then 
    //We pass the returned value to this function
    public void AddProject(int userId, Project project)
    {
        var userToUpdate = _context.Users.Find(userId);

        if (userToUpdate is null)
        {
            throw new InvalidOperationException("User does not exist");
        }

        if (userToUpdate.Projects is null)
        {
            userToUpdate.Projects = new List<Project>();
        }

        userToUpdate.Projects.Add(project);

        _context.SaveChanges();
    }


    public void UpdateUser(int userId, User newUser)
    {
        var userToUpdate = _context.Users.Find(userId);

        if (userToUpdate is null)
        {
            throw new InvalidOperationException("User does not exist");
        }

        userToUpdate = newUser;
        _context.Users.Update(userToUpdate);

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var userToDelete = _context.Users.Find(id);
        if (userToDelete is not null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }
}