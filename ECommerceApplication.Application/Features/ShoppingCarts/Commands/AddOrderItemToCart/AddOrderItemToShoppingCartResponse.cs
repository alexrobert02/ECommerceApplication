using ECommerceApplication.Application.Features.ShoppingCarts.Queries;
using ECommerceApplication.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.ShoppingCarts.Commands.AddOrderItemToCart
{
    public class AddOrderItemToShoppingCartResponse :BaseResponse
    {
        public AddOrderItemToShoppingCartResponse() : base()
        {
        }

        public ShoppingCartDto ShoppingCart{ get; set; }
    }
}
