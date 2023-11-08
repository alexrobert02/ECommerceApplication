using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Persistence
{
    public interface IShoppingCartRepository : IAsyncRepository<ShoppingCart>
    {
    }
}
