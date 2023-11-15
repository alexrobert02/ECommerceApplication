using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}