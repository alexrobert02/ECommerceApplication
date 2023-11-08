using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
