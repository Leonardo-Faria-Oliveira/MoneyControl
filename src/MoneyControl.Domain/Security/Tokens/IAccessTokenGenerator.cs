using MoneyControl.Domain.Entities;

namespace MoneyControl.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {

        string Generate(User user);

    }
}
