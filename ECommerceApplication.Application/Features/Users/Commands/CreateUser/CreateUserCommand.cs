using MediatR;

namespace ECommerceApplication.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Username { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string Address { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
    }
}
