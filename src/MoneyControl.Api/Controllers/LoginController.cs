
using Microsoft.AspNetCore.Mvc;
using MoneyControl.Application.UseCases.Users.Login;
using MoneyControl.Application.UseCases.Users.Register;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;

namespace MoneyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register(
          [FromServices] ILoginUseCase useCase,
          [FromBody] RequestLoginJson request
      )
        {

            var response = await useCase.Execute(request);

            return Ok(response);

        }

    }
}
