using TaskManagementAPI_proj.Services;
using TaskManagementAPI_proj.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TaskManagementAPI_proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetById(id);

            if (task != null)
            {
                return Ok(task);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Models.Task newTask)
        {
            var task = _taskService.Create(newTask);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpGet("{taskId}/getSubTasks")]
        public IActionResult GetTaskSubTasks(int taskId)
        {
            var subtasks = _taskService.GetTaskSubTasks(taskId);

            if (subtasks != null)
            {
                return Ok(subtasks);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{taskId}/getTags")]
        public IActionResult GetTaskTags(int taskId)
        {
            var tags = _taskService.GetTaskTags(taskId);

            if (tags != null)
            {
                return Ok(tags);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Models.Task newTask)
        {
            try
            {
                var updatedTask = _taskService.UpdateTask(id, newTask);
                return Ok(updatedTask);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{taskId}/addSubTask")]
        public IActionResult AddSubTask(int taskId, Models.SubTask subtask)
        {
            try
            {
                var newSubTask = _taskService.AddSubTask(taskId, subtask);
                return Ok(new
                {
                    id = newSubTask.Id,
                    name = newSubTask.Name,
                    completed = false
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
            var deletedTask = _taskService.DeleteById(id);
            return Ok(deletedTask);
        }
    }
}
