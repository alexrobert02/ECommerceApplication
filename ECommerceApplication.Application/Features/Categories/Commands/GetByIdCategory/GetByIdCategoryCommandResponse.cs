using ECommerceApplication.Application.Responses;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetByIdCategory
{
    public class GetByIdCategoryCommandResponse : BaseResponse
    {
        public GetByIdCategoryCommandResponse(): base()
        {
        }

        public GetByIdCategoryDto Category { get; set; }
    }
}