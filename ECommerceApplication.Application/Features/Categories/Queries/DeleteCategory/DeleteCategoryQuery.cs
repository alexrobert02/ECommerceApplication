using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Queries.DeleteCategory
{
    public class DeleteCategoryQuery : IRequest<DeleteCategoryResponse>
    {
        public Guid CategoryId { get; set; } = default!;

    }
}
