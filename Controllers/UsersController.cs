using TaskManagementAPI_proj.Services;
using TaskManagementAPI_proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI_proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/getProjects")]
        public IActionResult GetUserProjects(int id)
        {
            var projects = _userService.GetUserProjects(id);

            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{email}/{password}")]
        public IActionResult GetUserInfo(string email, string password)
        {
            var user = _userService.GetUserInfo(email,password);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public IActionResult Create(User newUser)
        {
            try
            {
                var user = _userService.Create(newUser);
                return CreatedAtAction(nameof(GetById), new { id = user.Id, email = user.Email }, user);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User newUser)
        {
            try
            {
                _userService.UpdateUser(id, newUser);
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
            _userService.DeleteById(id);
            return Ok();
        }
    }
}
