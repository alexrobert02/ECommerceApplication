using ECommerceApplication.Application.Responses;

namespace ECommerceApplication.Application.Features.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandResponse : BaseResponse
    {
        public CreateOrderItemCommandResponse() : base()
        {
        }

        public CreateOrderItemDto OrderItem { get; set; }
    }
}