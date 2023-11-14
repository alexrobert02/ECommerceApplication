using ECommerceApplication.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Queries.DeleteCategory
{
    public class DeleteCategoryResponse : BaseResponse
    {
        public DeleteCategoryResponse() : base()
        {
        }

        public CategoryDto Category { get; set; }
    }
}
