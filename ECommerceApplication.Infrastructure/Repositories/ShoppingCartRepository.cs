using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}
