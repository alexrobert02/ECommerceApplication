using ECommerceApplication.Domain.Entities;
using MediatR;

namespace ECommerceApplication.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        public Guid AddressId { get; private set; }
        public Guid ShoppingCartId { get; private set; }
    }
}
