using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repositories.Users
{
    public interface IUsersWriteOnlyRepository
    {

        Task Add(User user);

    }
}
