using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using MediatR;

namespace ECommerceApplication.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUserRepository repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new UpdateUserCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            // Retrieve the user from the repository
            var user = await repository.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { "User not found." }
                };
            }

            // Update user profile
            var updateResult = user.Value.Update(request.Username, request.Email, request.PasswordHash ,request.FirstName, request.LastName, request.Address, request.PhoneNumber);

            if (updateResult.IsSuccess)
            {
                // Save the updated user
                await repository.UpdateAsync(updateResult.Value);

                return new UpdateUserCommandResponse
                {
                    Success = true,
                    User = new UpdateUserDto
                    {
                        UserId = updateResult.Value.UserId,
                        Username = updateResult.Value.Username,
                        Email = updateResult.Value.Email,
                        FirstName = updateResult.Value.FirstName,
                        LastName = updateResult.Value.LastName,
                        Address = updateResult.Value.Address,
                        PhoneNumber = updateResult.Value.PhoneNumber
                    }
                };
            }
            else
            {
                // Handle failure result
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { updateResult.Error }
                };
            }
        }
    }
}