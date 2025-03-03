using MoneyControl.Domain.Repositories;
using MoneyControl.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public  class UsersWriteOnlyRepositoryBuilder
    {

        public static IUsersWriteOnlyRepository Build()
        {
            var mock = new Mock<IUsersWriteOnlyRepository>();

            return mock.Object;
        }

    }
}
