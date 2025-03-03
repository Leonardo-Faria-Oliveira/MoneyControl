using MoneyControl.Domain.Security.Criptography;
using Moq;

namespace CommonTestUtilities.Criptography
{
    public class PasswordEncryptedBuilder
    {

        public static IPasswordEncrypter Build()
        {
            var mock = new Mock<IPasswordEncrypter>();

            mock.Setup(passwordEncrypter => passwordEncrypter.Encrypt(It.IsAny<string>())).Returns("2892jd8");

            return mock.Object;
        }

    }
}
