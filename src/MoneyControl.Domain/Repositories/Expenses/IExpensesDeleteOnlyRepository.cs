using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repositories.Expenses
{
    public interface IExpensesDeleteOnlyRepository
    {

        public Task DeleteById(long id);

    }
}
