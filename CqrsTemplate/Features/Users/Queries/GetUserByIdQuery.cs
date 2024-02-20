using System;
using Mediator;

namespace CqrsTemplate.Features.Users.Queries
{
	public class GetUserByIdQuery : IRequest<User>
    {
		public required Guid Id { get; set; }
	}
}

