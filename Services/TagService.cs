using TaskManagementAPI_proj.Models;
using TaskManagementAPI_proj.Data;
using Microsoft.EntityFrameworkCore;
using Task = TaskManagementAPI_proj.Models.Task;

namespace TaskManagementAPI_proj.Services;

public class TagService
{
    private readonly TaskManagerContext _context;

    public TagService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<Models.Tag> GetAll()
    {
        return _context.Tags
            .AsNoTracking()
            .ToList();
    }

    public Models.Tag? GetById(int id)
    {
        return _context.Tags
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Models.Tag Create(Models.Tag newTag)
    {
        _context.Tags.Add(newTag);
        _context.SaveChanges();
        return newTag;
    }


    public Tag UpdateTag(int tagId, Models.Tag newTag)
    {
        var tagToUpdate = _context.Tags.Find(tagId);

        if (tagToUpdate is null)
        {
            throw new InvalidOperationException("Tag does not exist");
        }

        tagToUpdate = newTag;

        _context.Tags.Update(tagToUpdate);

        _context.SaveChanges();

        return tagToUpdate;
    }


    public Tag DeleteById(int id)
    {
        var tagToDelete = _context.Tags.Find(id);
        var tempSaved = tagToDelete;
        if (tagToDelete is not null)
        {
            _context.Tags.Remove(tagToDelete);
            _context.SaveChanges();

            return tempSaved;
        }
        return tempSaved;
    }
}