using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{

    public class ProductRepository : BaseRepository<Product>, IProductRepository
        {
            public ProductRepository(ECommergeApplicationContext context) : base(context)
            {
            }
        }
    
}
