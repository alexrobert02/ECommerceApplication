using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Application.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        //Task<bool> IsProductNameAndManufacterUnique(string productName, Manufacturer manufacturer);
    }
}
