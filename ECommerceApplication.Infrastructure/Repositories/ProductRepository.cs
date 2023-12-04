using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Infrastructure.Repositories
{

    public class ProductRepository : BaseRepository<Product>, IProductRepository
        {
            public ProductRepository(ECommerceApplicationContext context) : base(context)
            {
            }
        }
    
}
