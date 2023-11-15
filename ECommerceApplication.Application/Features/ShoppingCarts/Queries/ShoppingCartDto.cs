using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.ShoppingCarts.Queries
{
    public class ShoppingCartDto
    {
        public Guid ShoppingCartId { get; set; }
        public Guid UserId { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
