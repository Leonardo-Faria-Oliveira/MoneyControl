using CommonTestUtilities.Requests;
using FluentValidation;
using MoneyControl.Application.UseCases.Users;
using MoneyControl.Application.UseCases.Users.Register;
using MoneyControl.Communication.Requests;
using MoneyControl.Exception;

namespace Validators.Test.Users
{
    public class PasswordValidatorTest
    {


        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData(null)]
        [InlineData("1")]
        [InlineData("11")]
        [InlineData("111")]
        [InlineData("1111")]
        [InlineData("11111")]
        [InlineData("111111")]
        [InlineData("1111111")]
        [InlineData("aaaaaaaa")]
        [InlineData("Aaaaaaaa")]
        [InlineData("Aaaaaaa1")]
        public void Password_Empty(string password)
        {
            //Arrange
            var validator = new PasswordValidator<RequestRegisterUserJson>();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Password = password;


            //Act
            var validation = validator.IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password);

            //Assert
            Assert.False(validation);
           


        }

    }
}
