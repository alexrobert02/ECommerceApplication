using ECommerceApplication.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetAllCategory
{
    public class GetAllCategoryCommandResponse : BaseResponse
    {
        public GetAllCategoryCommandResponse() : base()
        {
        }
        public List<GetAllCategoryDto> Categories { get; set; }
    }
}
