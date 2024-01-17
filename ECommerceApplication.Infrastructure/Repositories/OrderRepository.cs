using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Common;
using ECommerceApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceApplicationContext context) : base(context)
        {
        }
        public async Task<Result<IReadOnlyList<Order>>> getOrdersByFilter(Guid? userId) {
            try
            {
                var orders = await context.Orders
                    .Where(order => (userId == null || order.UserId == userId))
                    .Include(o => o.OrderItems).ThenInclude(oi=> oi.Product)
                    .ToListAsync();

                return Result<IReadOnlyList<Order>>.Success(orders);
            }
            catch (Exception e)
            {
                return Result<IReadOnlyList<Order>>.Failure(e.Message);
            }
        }
    }
}
