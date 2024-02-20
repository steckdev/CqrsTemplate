
using CqrsTemplate.Features.Users.Commands;
using CqrsTemplate.Features.Users.Handlers;
using CqrsTemplate.Repositories;
using Moq;

namespace CqrsTemplate.Tests
{
    public class CreateUserCommandHandlerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Test]
        public void Handle_ValidCommand_ShouldCreateUserAndSave()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                GivenName = "John",
                Surname = "Doe",
                CreatedBy = "System"
            };

            // Act
            var handler = new CreateUserCommandHandler(_userRepositoryMock.Object);
            handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(x => x.AddUser(command));
        }

        [Test]
        public void Handle_InvalidCommand_ShouldThrowException()
        {
            // Arrange
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var command = new CreateUserCommand { CreatedBy = "System", GivenName = null, Surname = null }; // Missing GivenName and Surname
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Act & Assert
            var handler = new CreateUserCommandHandler(_userRepositoryMock.Object);
            Assert.Throws<ArgumentException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
