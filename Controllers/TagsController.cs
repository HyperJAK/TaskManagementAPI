using TaskManagementAPI_proj.Services;
using TaskManagementAPI_proj.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TaskManagementAPI_proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _tagService.GetAll();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tag = _tagService.GetById(id);

            if (tag != null)
            {
                return Ok(tag);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Models.Tag newTag)
        {
            var tag = _tagService.Create(newTag);
            return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateTag(int id, Models.Tag newTag)
        {
            try
            {
                var updatedTag = _tagService.UpdateTag(id, newTag);
                return Ok(updatedTag);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedTag = _tagService.DeleteById(id);
            return Ok(deletedTag);
        }
    }
}
