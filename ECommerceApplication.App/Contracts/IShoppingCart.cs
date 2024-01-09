using ECommerceApplication.App.ViewModels;

namespace ECommerceApplication.App.Contracts
{
    public interface IShoppingCartDataService
    {
        Task<List<ShoppingCartViewModel>> GetShoppingCartsAsync();
        Task<ShoppingCartViewModel> GetShoppingCartByIdAsync(Guid shoppingCartId);

    }
}