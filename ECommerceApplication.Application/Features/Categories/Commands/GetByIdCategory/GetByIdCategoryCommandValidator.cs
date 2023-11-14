using FluentValidation;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetByIdCategory
{
    public class GetByIdCategoryCommandValidator : AbstractValidator<GetByIdCategoryCommand>
    {
        public GetByIdCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
        }
    }
}
