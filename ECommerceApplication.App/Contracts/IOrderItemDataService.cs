
using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.App.ViewModels;

namespace ECommerceApplication.App.Contracts
{
    public interface IOrderItemDataService
    {
        Task<List<OrderItemViewModel>> GetOrderItemsAsync();

        Task<ApiResponse<OrderItemDto>> CreateOrderItemAsync(OrderItemViewModel orderItemViewModel);

        Task<ApiResponse<OrderItemDto>> UpdateOrderItemAsync(OrderItemViewModel orderItemViewModel);

        Task<ApiResponse<OrderItemDto>> RemoveItemFromCartAsync(Guid orderItemId);


    }
}
