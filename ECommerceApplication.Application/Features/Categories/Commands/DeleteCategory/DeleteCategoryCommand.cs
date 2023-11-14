using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; } = default!;

    }
}
