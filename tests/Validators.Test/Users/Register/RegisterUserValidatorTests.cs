using CommonTestUtilities.Requests;
using MoneyControl.Application.UseCases.Users.Register;
using MoneyControl.Exception;

namespace Validators.Test.Users.Register;

    public class RegisterUserValidatorTests
    {

        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();


            //Act
            var validation = validator.Validate(request);

            //Assert
            Assert.True(validation.IsValid);
            Assert.Empty(validation.Errors);
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData(null)]
        public void Name_Empty(string name)
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = name;


            //Act
            var validation = validator.Validate(request);

            //Assert
            Assert.False(validation.IsValid);
            Assert.Single(validation.Errors);
            Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.NAME_EMPTY);


        }



    [Theory]
    [InlineData("")]
    [InlineData("       ")]
    [InlineData(null)]
    public void Email_Empty(string email)
    {
        //Arrange
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = email;


        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.EMAIL_EMPTY);


    }


    [Fact]
    public void Email_Invalid()
    {
        //Arrange
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = "teste";


        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.EMAIL_INVALID);


    }



    [Theory]
    [InlineData("")]
    [InlineData("       ")]
    [InlineData(null)]
    public void Password_Empty(string password)
    {
        //Arrange
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = password;


        //Act
        var validation = validator.Validate(request);

        //Assert
        Assert.False(validation.IsValid);
        Assert.Equal(validation.Errors.First().ErrorMessage, ResourcesErrorMessages.INVALID_PASSWORD);


    }


}

