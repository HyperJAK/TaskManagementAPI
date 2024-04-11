using TaskManagementAPI_proj.Services;
using TaskManagementAPI_proj.Models;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI_proj;

namespace TaskManagementAPI_proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubTasksController : ControllerBase
    {
        private readonly SubTaskService _subTaskService;

        public SubTasksController(SubTaskService subTaskService)
        {
            _subTaskService = subTaskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var subTasks = _subTaskService.GetAll();
            return Ok(subTasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subTask = _subTaskService.GetById(id);

            if (subTask != null)
            {
                return Ok(subTask);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(SubTask newSubTask)
        {
            var subTask = _subTaskService.Create(newSubTask);
            return CreatedAtAction(nameof(GetById), new { id = subTask.Id }, subTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubTask(int id, SubTask newSubTask)
        {
            try
            {
                var subtask = _subTaskService.UpdateSubTask(id, newSubTask);
                return Ok(new
                {
                    id = id,
                    name = subtask.Name,
                    completed = subtask.Completed
                });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subTaskService.DeleteById(id);
            return Ok();
        }
    }
}
