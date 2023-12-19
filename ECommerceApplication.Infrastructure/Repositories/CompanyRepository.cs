using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace ECommerceApplication.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Manufacturer>, ICompanyRepository
    {
        public CompanyRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}
