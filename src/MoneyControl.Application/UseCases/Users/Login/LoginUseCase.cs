using AutoMapper;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Security.Criptography;
using MoneyControl.Domain.Security.Tokens;
using MoneyControl.Exception.ExceptionBase;
using MoneyControl.Communication.Requests;
using MoneyControl.Domain.Repositories.Users;
using MoneyControl.Domain.Repositories;

namespace MoneyControl.Application.UseCases.Users.Login
{
    public class LoginUseCase : ILoginUseCase
    {

        
        private readonly IUsersReadOnlyRepository _repository;
        private readonly IPasswordEncrypter _encrypter;
        private readonly IAccessTokenGenerator _tokenGenerator;

        public LoginUseCase(IUsersReadOnlyRepository repository, IAccessTokenGenerator tokenGenerator, IUnityOfWork unityOfWork, IMapper mapper, IPasswordEncrypter encrypter, IUsersReadOnlyRepository readRepository)
        {
            _repository = repository;
            _encrypter = encrypter;
            _tokenGenerator = tokenGenerator;

        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);
            if(user is null)
            {
                throw new InvalidLoginException();
            }

            var isPasswordCorrect = _encrypter.Verify(request.Password, user.Password);

            if(!isPasswordCorrect)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }
    }
}
