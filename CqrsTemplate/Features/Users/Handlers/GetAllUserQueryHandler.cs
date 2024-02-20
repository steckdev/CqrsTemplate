using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Queries;
using CqrsTemplate.Repositories;
using Mediator;

namespace CqrsTemplate.Features.Users.Handlers;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAllUsers();
        return ValueTask.FromResult(users);
    }
}