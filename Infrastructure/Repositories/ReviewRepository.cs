using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
