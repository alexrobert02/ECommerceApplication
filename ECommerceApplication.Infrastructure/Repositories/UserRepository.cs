using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}
