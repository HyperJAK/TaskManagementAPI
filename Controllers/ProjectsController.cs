using TaskManagementAPI_proj.Services;
using TaskManagementAPI_proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI_proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/getTasks")]
        public IActionResult GetProjectTasks(int id)
        {
            var project = _projectService.GetProjectTasks(id);

            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Project newProject)
        {
            var project = _projectService.Create(newProject);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPost("{projectId}/addtask")]
        public IActionResult AddTask(int projectId, Models.Task task)
        {
            try
            {
                var newTask = _projectService.AddTask(projectId, task);
                return Ok(new
                {
                    id = newTask.Id,
                    name = newTask.Name,
                });

            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{projectId}/adduser")]
        public IActionResult AddUser(int projectId, User user)
        {
            try
            {
                _projectService.AddUser(projectId, user);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, Project newProject)
        {
            try
            {
                _projectService.UpdateProject(id, newProject);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.DeleteById(id);
            return Ok();
        }
    }
}
