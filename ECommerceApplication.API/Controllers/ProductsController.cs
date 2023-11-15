using ECommerceApplication.Application.Features.Products.Queries.GetAllProduct;
using ECommerceApplication.Application.Features.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllProductQuery();
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
