using ECommerceApplication.Application.Persistence;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItems.Commands.DeleteCategory
{
    public class DeleteOrderItemQueryHandler : IRequestHandler <DeleteOrderItemQuery, DeleteOrderItemResponse>
    {
       private readonly ICategoryRepository _categoryRepository;
        public DeleteOrderItemQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<DeleteOrderItemResponse> Handle(DeleteOrderItemQuery request, CancellationToken cancellationToken)
        {
            var response = new DeleteOrderItemResponse();
            var category = await _categoryRepository.FindByIdAsync(request.OrderItemId);
            if (category == null)
            {
                response.Success = false;
                response.ValidationsErrors = new List<string> { "OrderItem not found" };
                return response;
            }
            await _categoryRepository.DeleteAsync(category.Value.CategoryId);
            response.Success = true;
            response.Message = "OrderItem deleted successfully";
            return response;

        }
    }
}
