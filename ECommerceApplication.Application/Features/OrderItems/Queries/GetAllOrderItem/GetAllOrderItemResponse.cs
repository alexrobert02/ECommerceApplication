using ECommerceApplication.Application.Features.OrderItems;
using ECommerceApplication.Application.Responses;


namespace ECommerceApplication.Application.Features.Categories.Queries.GetAllOrderItem
{
    public class GetAllCategoryResponse : BaseResponse
    {
        public GetAllCategoryResponse() : base()
        {
        }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
