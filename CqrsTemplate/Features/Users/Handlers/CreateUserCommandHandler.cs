using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Repositories;
using Mediator;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CqrsTemplate.Features.Users.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.GivenName) || string.IsNullOrWhiteSpace(request.Surname) || string.IsNullOrWhiteSpace(request.CreatedBy))
            throw new ArgumentException("Missing required field.");

        var userRequest = new User
        {
            Id = Guid.NewGuid(),
            GivenName = request.GivenName,
            Surname = request.Surname,
            CreatedBy = request.CreatedBy,
        };
        var user = _userRepository.AddUser(userRequest);
        return ValueTask.FromResult(user);
    }
}