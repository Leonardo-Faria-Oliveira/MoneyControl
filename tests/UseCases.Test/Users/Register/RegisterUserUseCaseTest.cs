using CommonTestUtilities.Criptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using MoneyControl.Application.UseCases.Users.Register;
using MoneyControl.Exception;
using MoneyControl.Exception.ExceptionBase;

namespace UseCases.Test.Users.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserJsonBuilder.Build();

        var result = await useCase.Execute(request);

        Assert.NotNull(result);
        Assert.Equal(request.Name, result.Name);
        Assert.NotEmpty(result.Token);
        Assert.NotEqual(" ", result.Token);
    }

    [Fact]
    public async Task NameIsEmpty()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;

        var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => useCase.Execute(request));
        Assert.Equal(ResourcesErrorMessages.NAME_EMPTY, exception.GetErrors().First());
    }

    [Fact]
    public async Task EmailIsEmpty()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = string.Empty;

        var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => useCase.Execute(request));
        Assert.Equal(ResourcesErrorMessages.EMAIL_EMPTY, exception.GetErrors().First());
    }

    [Fact]
    public async Task PasswordIsEmpty()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = string.Empty;

        var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => useCase.Execute(request));
        Assert.Equal(ResourcesErrorMessages.INVALID_PASSWORD, exception.GetErrors().First());
    }

    [Fact]
    public async Task EmailAlreadyRegistred()
    {
        
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase(request.Email);

        var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => useCase.Execute(request));
        Assert.Equal(ResourcesErrorMessages.EMAIL_ALREADY_REGISTERED, exception.GetErrors().First());
    }



    [Fact]
    public async Task EmailIsInvalid()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = "invalid-email";

        var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => useCase.Execute(request));
        Assert.Equal(ResourcesErrorMessages.EMAIL_INVALID, exception.GetErrors().First());
    }


    private RegisterUserUseCase CreateUseCase(string email = "")
    {
        var mapper = MapperBuilder.Build();
        var unityOfWork = UnityOfWorkBuilder.Build();
        var usersWriteOnlyRepository = UsersWriteOnlyRepositoryBuilder.Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
        var passwordEncrypter = PasswordEncryptedBuilder.Build();
        var usersReadOnlyRepository = new UsersReadOnlyRepositoryBuilder();

        if(!string.IsNullOrWhiteSpace(email))
        {
            usersReadOnlyRepository.ExistsActiveUserWithEmail(email);
           
        }


        return new RegisterUserUseCase(usersWriteOnlyRepository, jwtTokenGenerator, unityOfWork, mapper, passwordEncrypter, usersReadOnlyRepository.Build());
    }
}

