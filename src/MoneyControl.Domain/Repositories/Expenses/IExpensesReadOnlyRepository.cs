using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repositories.Expenses
{
    public interface IExpensesReadOnlyRepository
    {
        Task<ICollection<Expense>> GetAll(long userId);

        Task<Expense?> GetById(long id);

        Task<ICollection<Expense>> FilterByMonth(DateOnly date);
    }
}
