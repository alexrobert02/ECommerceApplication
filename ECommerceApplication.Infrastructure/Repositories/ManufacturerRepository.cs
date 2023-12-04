using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}
