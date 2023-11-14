using ECommerceApplication.Application.Persistence;
using MediatR;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetAllCategory
{
    public class GetAllCategoryCommandHandler : IRequestHandler<GetAllCategoryCommand, GetAllCategoryCommandResponse>
    {
      private readonly ICategoryRepository _categoryRepository;

      public GetAllCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
        _categoryRepository = categoryRepository;
      }
      
       public async Task<GetAllCategoryCommandResponse> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoriesResult = await _categoryRepository.GetAllAsync();
            if(categoriesResult.IsSuccess)
            {
                var categories = categoriesResult.Value;
                var categoriDto = categories.Select(x => new GetAllCategoryDto
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName
                }).ToList();
                var response = new GetAllCategoryCommandResponse
                {
                    Categories = categoriDto
                };
                return response;
            }
            else
            {
                return new GetAllCategoryCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { categoriesResult.Error }
                };
            }
            
        }
    }
}
