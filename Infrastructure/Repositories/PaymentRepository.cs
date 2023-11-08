using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
