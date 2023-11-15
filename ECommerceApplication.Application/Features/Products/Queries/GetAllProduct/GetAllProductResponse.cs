using ECommerceApplication.Application.Responses;


namespace ECommerceApplication.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductResponse : BaseResponse
    {
        public GetAllProductResponse() : base()
        {
        }
        public List<ProductDto> Products { get; set; }
    }
}
