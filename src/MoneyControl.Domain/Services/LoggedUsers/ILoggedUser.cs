using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Services.LoggedUsers
{
    public interface ILoggedUser
    {

        Task<User> Get();

    }
}
