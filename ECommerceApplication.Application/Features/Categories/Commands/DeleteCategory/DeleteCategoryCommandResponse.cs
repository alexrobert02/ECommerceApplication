using ECommerceApplication.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandResponse : BaseResponse
    {
        public DeleteCategoryCommandResponse() : base()
        {
        }
        public DeleteCategoryDto Category { get; set; }
    }
}
