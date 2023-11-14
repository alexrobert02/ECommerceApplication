using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Queries.GetByIdCategory
{
    internal class GetByIdCategoryValidator : AbstractValidator<GetByIdCategoryQuery>
    {
        public GetByIdCategoryValidator()
        {
            RuleFor(p => p.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
        }
    }
}
