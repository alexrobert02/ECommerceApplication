using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerceApplication.Application.Features.Addresses.Commands.CreateAddress;
using ECommerceApplication.Application.Features.Addresses.Queries.GetAllAddress;

namespace ECommerceApplication.API.Controllers
{
    public class AddressesController : ApiControllerBase
    {
        //[Authorize(Roles = "User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //[Authorize(Roles = "User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllAddressQuery();
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
