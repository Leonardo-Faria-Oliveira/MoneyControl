using BC = BCrypt.Net.BCrypt;
using MoneyControl.Domain.Security.Criptography;

namespace MoneyControl.Infraestructure.Security
{
    internal class Criptography : IPasswordEncrypter
    {
        public string Encrypt(string password)
        {
            return BC.HashPassword(password);
        }

        public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
    }
}
