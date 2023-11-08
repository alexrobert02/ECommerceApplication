using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
