using MoneyControl.Communication.Responses;

namespace MoneyControl.Application.UseCases.Expenses.Get
{
    public interface IGetExpenseByIdUseCase
    {

        public Task<ResponseExpenseJson> Execute(long id);

    }
}
