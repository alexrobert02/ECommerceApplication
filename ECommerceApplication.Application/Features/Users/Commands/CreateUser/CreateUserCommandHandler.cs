using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using MediatR;

namespace ECommerceApplication.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateUserCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var user = User.Create(request.Username, request.Email, request.PasswordHash, request.FirstName, request.LastName, request.PhoneNumber);
            if (!user.IsSuccess)
            {
                return new CreateUserCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { user.Error }
                };
            }

            await repository.AddAsync(user.Value);

            return new CreateUserCommandResponse
            {
                Success = true,
                User = new CreateUserDto
                {
                    UserId = user.Value.UserId,
                    Username = user.Value.Username,
                    Email = user.Value.Email,
                    PasswordHash = user.Value.PasswordHash,
                    FirstName = user.Value.FirstName,
                    LastName = user.Value.LastName,
                    PhoneNumber = user.Value.PhoneNumber
                }
            };
        }
    }
}
