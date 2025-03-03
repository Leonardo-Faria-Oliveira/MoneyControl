using MoneyControl.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UsersReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUsersReadOnlyRepository> _repository;


        public UsersReadOnlyRepositoryBuilder()
        {
            _repository = new Mock<IUsersReadOnlyRepository>();
        }

        public void ExistsActiveUserWithEmail(string email)
        {
            _repository.Setup(repository => repository.ExistsActiveUserWithEmail(email)).ReturnsAsync(true);
        }

        public IUsersReadOnlyRepository Build()
        {

            return _repository.Object;


        }

    }
}
