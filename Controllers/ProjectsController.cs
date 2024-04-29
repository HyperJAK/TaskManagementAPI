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

        [HttpGet("getExternalProjectsForUser/{userId}")]
        public IActionResult GetProjectsByContainedUser(int userId)
        {
            var projects = _projectService.GetProjectsByContainedUser(userId);

            if (projects != null)
            {
                return Ok(projects);
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

        [HttpGet("{id}/getUserRole/{userId}")]
        public IActionResult GetUserRole(int id, int userId)
        {

            try{
                var userRole = _projectService.GetUserRole(id, userId);


                return Ok(new
                {
                    role = userRole,
                });
            }catch(InvalidOperationException ex){

                return NotFound(ex.Message);
            }
              
            
        }

        [HttpPost]
        public IActionResult Create(Project newProject)
        {
            var project = _projectService.Create(newProject);
            return Ok(project.Id);
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

        [HttpPost("{projectId}/adduser/{email}/{role}")]
        public IActionResult AddUser(int projectId, string email, string role)
        {
            try
            {
                var newUser = _projectService.AddUser(projectId, email, role);
                if(newUser != null){
                    return Ok(new{
                        id = newUser.UserId
                    });
                }
                return null;
                
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
