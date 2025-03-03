using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repositories.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {

        Task Add(Expense expense);

    }
}
