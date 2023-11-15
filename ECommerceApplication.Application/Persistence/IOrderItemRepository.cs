﻿using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Persistence
{
    public interface IOrderItemRepository : IAsyncRepository<OrderItem>
    {
    }
}
