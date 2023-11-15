using ECommerceApplication.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApplication.Application.Features.Categories.Queries.GetAllCategory;
using Microsoft.AspNetCore.Mvc;
using ECommerceApplication.Application.Features.Categories.Queries.GetByIdCategory;
using ECommerceApplication.Application.Features.Categories.Queries.DeleteCategory;

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
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllCategoryQuery();
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetByIdCategoryQuery), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid categoryId)
        {
            var command = new GetByIdCategoryQuery { CategoryId = categoryId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DeleteCategoryQuery), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var command = new DeleteCategoryQuery { CategoryId = categoryId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
