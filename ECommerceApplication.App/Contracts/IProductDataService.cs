using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.App.ViewModels;

namespace ECommerceApplication.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetProductAsync();
        Task <ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel);
    }
}
