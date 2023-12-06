using ECommerceApplication.Application.Responses;

namespace ECommerceApplication.Application.Features.OrderItems.Commands.DeleteCategory
{
    public class DeleteOrderItemResponse : BaseResponse
    {
        public DeleteOrderItemResponse() : base()
        {
        }

        public CategoryDto Category { get; set; }
    }
}
