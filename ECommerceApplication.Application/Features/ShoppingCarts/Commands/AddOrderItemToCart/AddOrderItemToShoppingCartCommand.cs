using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.ShoppingCarts.Commands.AddOrderItemToCart
{
    public class AddOrderItemToShoppingCartCommand : IRequest<AddOrderItemToShoppingCartResponse> 
    {
        public Guid ShoppingCartId { get; set; }
        public Guid OrderItemId { get; set; }
    }
}
