using ECommerceApplication.Application.Features.Products.Queries;
using ECommerceApplication.Application.Features.Products.Queries.GetAllProduct;
using ECommerceApplication.Application.Features.Products.Queries.GetByIdProduct;
using ECommerceApplication.Application.Features.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await Mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var dtos = await Mediator.Send(new GetAllProductQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdProductQuery()
            {
                ProductId = id
            });
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result.Product);
        }
    }
}
