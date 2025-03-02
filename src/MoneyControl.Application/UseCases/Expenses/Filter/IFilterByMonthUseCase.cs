using MoneyControl.Communication.Responses;

namespace MoneyControl.Application.UseCases.Expenses.Filter
{
    public interface IFilterByMonthUseCase
    {

        public Task<ResponseExpensesJson> Execute(DateOnly date);

    }
}
