using MoneyControl.Communication.Requests;

namespace MoneyControl.Application.UseCases.Expenses.Update
{
    public interface IUpdateExpenseByIdUseCase
    {

        public Task Execute(long id, RequestExpenseJson request);

    }
}
