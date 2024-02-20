
using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Queries;
using Mediator;

namespace CqrsTemplate.Repositories;

public interface IUserRepository
{
    User AddUser(User user);
    User? GetUserById(Guid id);
    IEnumerable<User> GetAllUsers();
}