using AutoMapper;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Domain.Repository;
using MoneyControl.Domain.Repository.Users;
using MoneyControl.Domain.Entities;
using MoneyControl.Application.UseCases.Expenses;
using MoneyControl.Exception.ExceptionBase;
using MoneyControl.Domain.Security.Criptography;
using MoneyControl.Exception;
using FluentValidation.Results;
using MoneyControl.Domain.Security.Tokens;

namespace MoneyControl.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {

        private readonly IUsersWriteOnlyRepository _repository;
        private readonly IUsersReadOnlyRepository _readRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordEncrypter _encrypter;
        private readonly IAccessTokenGenerator _tokenGenerator;

        public RegisterUserUseCase(IUsersWriteOnlyRepository repository, IAccessTokenGenerator tokenGenerator, IUnityOfWork unityOfWork, IMapper mapper, IPasswordEncrypter encrypter, IUsersReadOnlyRepository readRepository)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _encrypter = encrypter;
            _readRepository = readRepository;
            _tokenGenerator = tokenGenerator;
            
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var entity = _mapper.Map<User>(request);

            entity.Password = _encrypter.Encrypt(request.Password);
            entity.UserIdentifier = new Guid();

            await _repository.Add(entity);
            await _unityOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                Token = _tokenGenerator.Generate(entity)
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {

            var validator = new RegisterUserValidator();

            var validation = validator.Validate(request);

            var isEmailAlreadyRegistered = await _readRepository.ExistsActiveUserWithEmail(request.Email);

            if (isEmailAlreadyRegistered)
            {
                validation.Errors.Add(new ValidationFailure(string.Empty, ResourcesErrorMessages.EMAIL_ALREADY_REGISTERED));
            }


            if (!validation.IsValid)
            {
                var errorMessages = validation.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ValidationErrorException(errorMessages);
            }

            


        }
    }
}
