using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Application.UseCases.Expenses.Register
{
    public interface IRegisterExpenseUseCase
    {

        Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
    }
}
