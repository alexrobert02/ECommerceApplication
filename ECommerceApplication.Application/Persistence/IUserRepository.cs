using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
