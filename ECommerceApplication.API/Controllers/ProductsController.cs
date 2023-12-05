﻿using ECommerceApplication.Application.Features.Products.Queries;
using ECommerceApplication.Application.Features.Products.Queries.GetAllProduct;
using ECommerceApplication.Application.Features.Products.Queries.GetByIdProduct;
using ECommerceApplication.Application.Features.Products.Commands.CreateProduct;
using ECommerceApplication.Application.Features.Products.Commands.DeleteProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceApplication.API.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await Mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var dtos = await Mediator.Send(new GetAllProductQuery());
            return Ok(dtos);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteProductCommand() { ProductId = id };
            await Mediator.Send(deleteEventCommand);
            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
