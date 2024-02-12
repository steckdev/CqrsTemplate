using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CqrsTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(UsersContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IEnumerable<User>> Get()
        {
            _logger.LogInformation("Getting users");
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Getting user by id");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            _logger.LogInformation("Creating user");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetUserById", new { id = user.Id }, user);
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<IActionResult> Update(User user)
        {
            _logger.LogInformation("Updating user");
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Deleting user");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
