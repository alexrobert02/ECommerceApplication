using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
