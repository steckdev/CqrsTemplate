using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Queries;
using CqrsTemplate.Repositories;
using Mediator;

namespace CqrsTemplate.Features.Users.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserById(request);
        return ValueTask.FromResult(user);
    }
}