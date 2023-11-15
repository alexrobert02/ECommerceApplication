using ECommerceApplication.Application.Features.Categories.Queries.GetByIdCategory;
using ECommerceApplication.Application.Features.ShoppingCarts.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    public class ShoppingCartController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllShoppingCartsQuery();
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("{shoppingCartId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetByIdShoppingCartQuery), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid shoppingCartId)
        {
            var command = new GetByIdShoppingCartQuery { ShoppingCartId = shoppingCartId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
