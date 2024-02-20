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

    public User AddUser(User user)
    {
        user.OnBeforeSave(null);
        _users.Add(user);
        return user;
    }

    public User? GetUserById(Guid id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }
}