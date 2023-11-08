using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
