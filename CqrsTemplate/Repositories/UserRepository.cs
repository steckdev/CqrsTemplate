using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Queries;

namespace CqrsTemplate.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users;

    public InMemoryUserRepository()
    {
        _users = new List<User>();
    }

    public User AddUser(CreateUserCommand command)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            GivenName = command.GivenName,
            Surname = command.Surname,
            CreatedBy = command.CreatedBy,
        };
        user.OnBeforeSave(null);
        _users.Add(user);
        return user;
    }

    public User? GetUserById(GetUserByIdQuery query)
    {
        var user = _users.FirstOrDefault(x => x.Id == query.Id);
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }
}