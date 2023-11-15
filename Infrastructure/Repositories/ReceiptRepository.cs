using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ECommerceApplicationContext context) : base(context)
        {
        }
    }
}