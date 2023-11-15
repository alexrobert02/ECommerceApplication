using ECommerceApplication.Application.Persistence;
using MediatR;

namespace ECommerceApplication.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, GetAllProductResponse>
    {
        private readonly IProductRepository _categoryRepository;

        public GetAllProductQueryHandler(IProductRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetAllProductResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            GetAllProductResponse response = new();
            var result = await _categoryRepository.GetAllAsync();
            if (result.IsSuccess)
            {
                response.Products = result.Value.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Manufacturer = p.Manufacturer
                }).ToList();
            }
            return response;
        }
    }
}
