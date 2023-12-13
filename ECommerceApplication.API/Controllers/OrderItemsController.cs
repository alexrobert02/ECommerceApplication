using ECommerceApplication.Application.Features.OrderItems.Queries.GetAllOrderItem;
using ECommerceApplication.Application.Features.OrderItems.Commands.CreateOrderItem;
using ECommerceApplication.Application.Features.OrderItems.Commands.DeleteCategory;
using ECommerceApplication.Application.Features.OrderItems.Commands.UpdateOrderItem;
using ECommerceApplication.Application.Features.OrderItems.Queries.GetByIdOrderItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;

namespace ECommerceApplication.API.Controllers
{
    public class OrderItemsController: ApiControllerBase 
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateOrderItemCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{orderItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid orderItemId, UpdateOrderItemCommand command)
        {
            // Ensure the orderItemId in the path matches the one in the request body
            if (orderItemId != command.OrderItemId)
            {
                return BadRequest("The provided orderItemId in the path does not match the one in the request body.");
            }

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
            var result = await Mediator.Send(new GetAllOrderItemQuery());
            return Ok(result.OrderItems);
        }

        [HttpGet("{orderItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetByIdOrderItemQuery), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid orderItemId)
        {
            var command = new GetByIdOrderItemQuery { OrderItemId = orderItemId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{orderItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DeleteOrderItemQuery), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid orderItemId)
        {
            var command = new DeleteOrderItemQuery { OrderItemId = orderItemId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
