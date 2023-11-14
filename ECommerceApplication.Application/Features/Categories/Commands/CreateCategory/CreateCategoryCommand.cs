using MediatR;

namespace ECommerceApplication.Application.Features.Categories.Queries.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; } = default!;
    }
}
