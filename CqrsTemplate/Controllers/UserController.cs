using CqrsTemplate.Entities;
using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CqrsTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersContext _context;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(UsersContext context, ILogger<UserController> logger, IMediator mediator)
        {
            _context = context;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IEnumerable<User>> Get()
        {
            _logger.LogInformation("Getting users");
            var users = await _mediator.Send(new GetAllUsersQuery());
            return users;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Getting user by id");
            var user = _mediator.Send(new GetUserByIdQuery{ Id = id});
            if (user.Result == null)
            {
                return NotFound();
            }
            return Ok(user.Result);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            _logger.LogInformation("Creating user");
            var createdUser = await _mediator.Send(new CreateUserCommand{
                GivenName = user.GivenName,
        Surname = user.Surname,
        CreatedBy = user.CreatedBy});
            return CreatedAtRoute("GetUserById", new { id = user.Id }, createdUser);
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
