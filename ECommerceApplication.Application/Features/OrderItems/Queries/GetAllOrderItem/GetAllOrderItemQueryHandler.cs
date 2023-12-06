using ECommerceApplication.Application.Features.OrderItems;
using ECommerceApplication.Application.Persistence;
using MediatR;

namespace ECommerceApplication.Application.Features.Categories.Queries.GetAllOrderItem
{
    public class GetAllOrderItemQueryHandler : IRequestHandler<GetAllOrderItemQuery, GetAllCategoryResponse>
    {
        private readonly IOrderItemRepository _ordeItemRepository;

        public GetAllOrderItemQueryHandler(IOrderItemRepository ordeItemRepository)
        {
            _ordeItemRepository = ordeItemRepository;
        }

        public async Task<GetAllCategoryResponse> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
        {
            GetAllCategoryResponse response = new();
            var result = await _ordeItemRepository.GetAllAsync();
            if (result.IsSuccess)
            {
                response.OrderItems = result.Value.Select(c => new OrderItemDto
                {
                    OrderItemId = c.OrderItemId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    PricePerUnit = c.PricePerUnit
                }).ToList();
            }
            return response;
        }
    }
}
