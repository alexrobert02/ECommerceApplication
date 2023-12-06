using ECommerceApplication.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApplication.Application.Features.Categories.Queries.DeleteCategory;
using ECommerceApplication.Application.Features.Categories.Queries.GetByIdCategory;
using ECommerceApplication.Application.Features.ShoppingCarts.Commands.AddOrderItemToCart;
using ECommerceApplication.Application.Features.ShoppingCarts.Commands.CreateShoppingCart;
using ECommerceApplication.Application.Features.ShoppingCarts.Commands.DeleteShoppingCart;
using ECommerceApplication.Application.Features.ShoppingCarts.Commands.RemoveOrderItemFromCart;
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

        [HttpDelete("{shoppingCartId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DeleteShoppingCartQuery), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid shoppingCartId)
        {
            var command = new DeleteShoppingCartQuery { ShoppingCartId = shoppingCartId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateShoppingCartCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("{shoppingCartId}/AddItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AddOrderItemToShoppingCartCommand), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItemToCart(Guid shoppingCartId, AddOrderItemToShoppingCartCommand command)
        {
            command.ShoppingCartId = shoppingCartId;
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{shoppingCartId}/RemoveItem/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RemoveOrderItemFromShoppingCartCommand), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveItemFromCart(Guid shoppingCartId, Guid itemId)
        {
            var command = new RemoveOrderItemFromShoppingCartCommand
            {
                ShoppingCartId = shoppingCartId,
                OrderItemId = itemId
            };

            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
