using MoneyControl.Communication.Responses;

namespace MoneyControl.Application.UseCases.Expenses.GetAll
{
    public interface IGetAllExpensesUseCase
    {

        public Task<ResponseExpensesJson> Execute();

    }
}
