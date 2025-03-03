using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repositories.Expenses
{
    public interface IExpensesUpdateOnlyRepository
    {

        Task<Expense?> GetById(long id);

        public Task UpdateById(Expense expense);

    }
}
