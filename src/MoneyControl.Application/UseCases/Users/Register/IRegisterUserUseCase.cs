using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;

namespace MoneyControl.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {

        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
