using ECommerceApplication.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApplication.Application.Features.Categories.Commands.GetAllCategory;
using ECommerceApplication.Application.Features.Categories.Commands.GetByIdCategory;
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
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllCategoryCommand();
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetByIdCategoryCommand), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid categoryId)
        {
            var command = new GetByIdCategoryCommand { CategoryId = categoryId };
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
