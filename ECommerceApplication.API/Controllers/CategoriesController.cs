using ECommerceApplication.API.Controllers;
using ECommerceApplication.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApplication.Application.Features.Categories.Commands.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
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
        public async Task<IActionResult> GetAll(GetAllCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
