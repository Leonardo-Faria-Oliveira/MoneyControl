﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.Application.UseCases.Expenses.Delete;
using MoneyControl.Application.UseCases.Expenses.Filter;
using MoneyControl.Application.UseCases.Expenses.Get;
using MoneyControl.Application.UseCases.Expenses.GetAll;
using MoneyControl.Application.UseCases.Expenses.Register;
using MoneyControl.Application.UseCases.Expenses.Update;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;

namespace MoneyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterExpenseUseCase useCase,
            [FromBody] RequestExpenseJson request
        )
        {

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);

        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
        {
            var response = await useCase.Execute();

            if(response.Expenses.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExpenseById([FromServices] IGetExpenseByIdUseCase useCase, [FromRoute] long id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById([FromServices] IDeleteExpenseByIdUseCase useCase, [FromRoute] long id)
        {
            await useCase.Execute(id);

            return NoContent();
        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById([FromServices] IUpdateExpenseByIdUseCase useCase, [FromRoute] long id, [FromBody] RequestExpenseJson request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [Route("/date")]
        [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FilterByMonth([FromServices] IFilterByMonthUseCase useCase, [FromQuery] DateOnly date)
        {
            var response = await useCase.Execute(date);

            if (response.Expenses.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }


    }
}
