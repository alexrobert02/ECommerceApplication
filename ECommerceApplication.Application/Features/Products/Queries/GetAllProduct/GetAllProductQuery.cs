﻿using MediatR;

namespace ECommerceApplication.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<GetAllProductResponse>
    {
        public GetAllProductQuery() { }

    }
}
