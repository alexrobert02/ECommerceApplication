using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetAllCategory
{
    public class GetAllCategoryCommand : IRequest<GetAllCategoryCommandResponse>
    {
        public GetAllCategoryCommand() { }

    }
}
