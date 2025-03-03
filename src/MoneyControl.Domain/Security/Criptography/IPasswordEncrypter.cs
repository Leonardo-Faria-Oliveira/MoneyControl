namespace MoneyControl.Domain.Security.Criptography
{
    public interface IPasswordEncrypter
    {

        string Encrypt(string password);

        bool Verify(string password, string passwordHash);

    }
}
