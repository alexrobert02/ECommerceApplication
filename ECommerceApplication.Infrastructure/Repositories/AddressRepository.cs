using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ECommerceApplicationContext context) : base(context)
        {
        }

        public async Task<bool> AddressExists(Guid addressId)
        {
            return await context.Addresses.AnyAsync(a => a.AddressId == addressId);
        }
    }
}
