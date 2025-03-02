using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyControl.Communication.Responses;
using MoneyControl.Exception.ExceptionBase;
using System;

namespace MoneyControl.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            
            if(context.Exception is MoneyControlException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context);
            }

        }

        private void HandleProjectException(ExceptionContext context)
        {
            var exception = (MoneyControlException)context.Exception;
            var errorMessage = new ResponseErrorJson { ErrorMessage = exception.GetErrors() };

            context.HttpContext.Response.StatusCode = exception.StatusCode;
            context.Result = new ObjectResult(errorMessage);

            

        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorMessage = new ResponseErrorJson { ErrorMessage = [context.Exception.Message] };

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(errorMessage);
        }
    }
}
