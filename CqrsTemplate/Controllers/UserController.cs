using Microsoft.AspNetCore.Mvc;

namespace cqrs_template.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllUsers")]
    public IEnumerable<User> Get()
    {
        _logger.LogInformation("Getting users");
        return Enumerable.Range(1, 5).Select(index => new User
        {
            Id = Guid.NewGuid(),
            GivenName = $"givenname {index}",
            Surname = $"surname {index}",
        })
        .ToArray();
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public User GetById(Guid id)
    {
        _logger.LogInformation("Getting user by id");
        return new User
        {
            Id = id,
            GivenName = "givenname",
            Surname = "surname",
        };
    }

    [HttpPost(Name = "CreateUser")]
    public User Create(User user)
    {
        _logger.LogInformation("Creating user");
        return user;
    }

    [HttpPut(Name = "UpdateUser")]
    public User Update(User user)
    {
        _logger.LogInformation("Updating user");
        return user;
    }

    [HttpDelete(Name = "DeleteUser")]
    public User Delete(User user)
    {
        _logger.LogInformation("Deleting user");
        return user;
    }


}

