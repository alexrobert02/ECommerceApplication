using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
