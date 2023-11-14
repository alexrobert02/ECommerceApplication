using ECommerceApplication.Application.Responses;

namespace ECommerceApplication.Application.Features.Categories.Queries.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {
        }

        public CreateCategoryDto Category { get; set; }
    }
}