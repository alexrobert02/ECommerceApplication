using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
