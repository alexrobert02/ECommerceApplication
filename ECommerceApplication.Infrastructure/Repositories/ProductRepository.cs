using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Common;
using ECommerceApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceApplicationContext context) : base(context)
        {
        }

        /*public Task<bool> IsProductNameAndManufacterUnique(string productName, Manufacturer manufacturer)
        {
            var matches = context.Products.Any(e => e.ProductName.Equals(productName)
            && e.Manufacturer.Equals(manufacturer));
            return Task.FromResult(matches);
        }*/

        public override async Task<Result<Product>> FindByIdAsync(Guid id)
        {
            var result = await context.Products.Include(e => e.Category).FirstOrDefaultAsync(e => e.ProductId.Equals(id))!;
            if (result == null)
            {
                return Result<Product>.Failure($"Entity with id {id} not found");
            }
            return Result<Product>.Success(result);
        }

        public override async Task<Result<IReadOnlyList<Product>>> GetAllAsync()
        {
            var result = await context.Products.Include(e => e.Category).AsNoTracking().ToListAsync();
            return Result<IReadOnlyList<Product>>.Success(result);
        }

    }
}
