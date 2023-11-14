using ECommerceApplication.Application.Responses;

namespace ECommerceApplication.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandResponse : BaseResponse
    {
        public CreateUserCommandResponse() : base()
        {
        }

        public CreateUserDto User { get; set; }
    }
}