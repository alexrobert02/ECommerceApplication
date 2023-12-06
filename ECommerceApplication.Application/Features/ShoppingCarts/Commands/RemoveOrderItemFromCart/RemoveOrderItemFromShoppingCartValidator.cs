using ECommerceApplication.Application.Features.OrderItems.Queries.GetByIdOrderItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.ShoppingCarts.Commands.RemoveOrderItemFromCart
{
    public class RemoveOrderItemFromShoppingCartValidator : AbstractValidator<RemoveOrderItemFromShoppingCartCommand>
    {
        public RemoveOrderItemFromShoppingCartValidator()
        {
            RuleFor(p => p.ShoppingCartId)
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
            RuleFor(p => p.OrderItemId)
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
        }
    }
}
