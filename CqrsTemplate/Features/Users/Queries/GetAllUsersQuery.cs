using Mediator;

namespace CqrsTemplate.Features.Users.Queries
{
	public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
	}
}

