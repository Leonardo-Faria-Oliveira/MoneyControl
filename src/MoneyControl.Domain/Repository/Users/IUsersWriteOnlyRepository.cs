using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Repository.Users
{
    public interface IUsersWriteOnlyRepository
    {

        Task Add(User user);

    }
}
