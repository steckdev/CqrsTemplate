using Mediator;

namespace CqrsTemplate.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public required string GivenName { get; set; }
        public required string Surname { get; set; }
        public required string CreatedBy { get; set; }
    }
}

