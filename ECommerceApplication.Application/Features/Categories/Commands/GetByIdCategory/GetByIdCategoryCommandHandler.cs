using ECommerceApplication.Application.Persistence;
using MediatR;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetByIdCategory
{
    public class GetByIdCategoryCommandHandler : IRequestHandler<GetByIdCategoryCommand, GetByIdCategoryCommandResponse>
    {
        private readonly ICategoryRepository repository;

        public GetByIdCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetByIdCategoryCommandResponse> Handle(GetByIdCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetByIdCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new GetByIdCategoryCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var category = await repository.FindByIdAsync(request.CategoryId);

            if (!category.IsSuccess)
            {
                return new GetByIdCategoryCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { "Category not found." }
                };
            }

            return new GetByIdCategoryCommandResponse
            {
                Success = true,
                Category = new GetByIdCategoryDto
                {
                    CategoryId = category.Value.CategoryId,
                    CategoryName = category.Value.CategoryName
                }
            };
        }

    }
}
