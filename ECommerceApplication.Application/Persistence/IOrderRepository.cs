using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
