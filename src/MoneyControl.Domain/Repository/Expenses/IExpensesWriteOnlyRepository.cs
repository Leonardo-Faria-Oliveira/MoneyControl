using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repository.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {

        Task Add(Expense expense);

    }
}
