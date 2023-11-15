using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.ShoppingCarts.Queries.GetAll
{
    public class GetAllShoppingCartsQuery : IRequest<GetAllShoppingCartsResponse>
    {
        public GetAllShoppingCartsQuery() { }

    }
}
