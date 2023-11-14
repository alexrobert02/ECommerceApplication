using ECommerceApplication.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler <DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
       private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteCategoryCommandResponse();
            var category = await _categoryRepository.FindByIdAsync(request.CategoryId);
            if (category == null)
            {
                response.Success = false;
                response.Message = "Category not found";
                return response;
            }
            await _categoryRepository.DeleteAsync(category.Value.CategoryId);
            response.Success = true;
            response.Message = "Category deleted successfully";
            return response;
        }
    }
}
