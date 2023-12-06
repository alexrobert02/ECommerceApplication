using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.ShoppingCarts.Commands.RemoveOrderItemFromCart
{
    public class RemoveOrderItemFromShoppingCartCommand : IRequest<RemoveOrderItemFromShoppingCartResponse> 
    {
        public Guid ShoppingCartId { get; set; }
        public Guid OrderItemId { get; set; }
    }
}
