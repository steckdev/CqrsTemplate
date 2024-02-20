
using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Queries;
using Mediator;

namespace CqrsTemplate.Repositories;

public interface IUserRepository
{
    User AddUser(CreateUserCommand command);
    User? GetUserById(GetUserByIdQuery query);
    IEnumerable<User> GetAllUsers();
}