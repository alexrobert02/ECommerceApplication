using MediatR;

namespace ECommerceApplication.Application.Features.Categories.Commands.GetByIdCategory
{
    public class GetByIdCategoryCommand : IRequest<GetByIdCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; } = default!;
    }
}
