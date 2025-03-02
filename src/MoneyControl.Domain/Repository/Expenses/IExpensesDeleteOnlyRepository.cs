using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repository.Expenses
{
    public interface IExpensesDeleteOnlyRepository
    {

        public Task<bool> DeleteById(long id);

    }
}
