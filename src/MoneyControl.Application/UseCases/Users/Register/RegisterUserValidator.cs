using FluentValidation;
using MoneyControl.Communication.Requests;
using MoneyControl.Exception;

namespace MoneyControl.Application.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {

        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourcesErrorMessages.NAME_EMPTY);
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourcesErrorMessages.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourcesErrorMessages.EMAIL_INVALID);
            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
           
        }

    }
}
