using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ProductVariationRepository : BaseRepository<ProductVariation>, IProductVariationRepository
    {
        public ProductVariationRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}