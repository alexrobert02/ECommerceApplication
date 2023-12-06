﻿using ECommerceApplication.Application.Features.Categories.Queries.DeleteCategory;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItems.Commands.DeleteCategory
{
    public class DeleteOrderItemQuery : IRequest<DeleteOrderItemResponse>
    {
        public Guid OrderItemId { get; set; } = default!;

    }
}
