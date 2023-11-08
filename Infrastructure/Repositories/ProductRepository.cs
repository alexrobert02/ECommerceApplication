using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
  
        public class ProductRepository : BaseRepository<Product>, IProductRepository
        {
            public ProductRepository(ECommergeApplicationContext context) : base(context)
            {
            }
        }
    
}
