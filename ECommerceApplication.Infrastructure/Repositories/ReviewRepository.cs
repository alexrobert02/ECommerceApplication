using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}
