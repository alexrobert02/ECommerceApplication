using FluentValidation;

namespace ECommerceApplication.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            // Add validation rules for other properties if needed
            // ...
        }
    }
}
