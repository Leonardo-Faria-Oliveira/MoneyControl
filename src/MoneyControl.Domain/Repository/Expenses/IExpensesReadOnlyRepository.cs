using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repository.Expenses
{
    public interface IExpensesReadOnlyRepository
    {
        Task<ICollection<Expense>> GetAll();

        Task<Expense?> GetById(long id);

        Task<ICollection<Expense>> FilterByMonth(DateOnly date);
    }
}
