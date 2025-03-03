namespace MoneyControl.Domain.Security.Tokens
{
    public interface ITokenProvider
    {

        string GetTokenOnRequest();

    }
}
