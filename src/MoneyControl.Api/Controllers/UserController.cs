using Microsoft.AspNetCore.Mvc;
using MoneyControl.Application.UseCases.Expenses.Register;
using MoneyControl.Application.UseCases.Users.Register;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;

namespace MoneyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
           [FromServices] IRegisterUserUseCase useCase,
           [FromBody] RequestRegisterUserJson request
       )
        {

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);

        }

    }
}
