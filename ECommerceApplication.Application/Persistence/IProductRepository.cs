using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<bool> ProductExists(Guid productId);
    }
}
