using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Queries.DeleteCategory
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryQuery>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
