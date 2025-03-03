using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;

namespace MoneyControl.Application.UseCases.Users.Login
{
    public interface ILoginUseCase
    {

        public Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
    }
}
