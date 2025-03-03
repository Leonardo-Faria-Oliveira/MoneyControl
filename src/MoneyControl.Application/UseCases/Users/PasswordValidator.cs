using FluentValidation;
using FluentValidation.Validators;
using MoneyControl.Exception;
using System.Text.RegularExpressions;

namespace MoneyControl.Application.UseCases.Users
{
    public partial class PasswordValidator<T> : PropertyValidator<T, string>
    {

        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override string Name => "PasswordValidator";

        public override bool IsValid(ValidationContext<T> context, string password)
        {

            if (string.IsNullOrWhiteSpace(password) || 
                password.Length < 8 || 
                !UpperCaseLetter().IsMatch(password) || 
                !LowerCaseLetter().IsMatch(password) || 
                !Number().IsMatch(password) ||
                !SpecialCharacter().IsMatch(password)
            )
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourcesErrorMessages.INVALID_PASSWORD);
                return false;
            }

            
            return true;
        }

        [GeneratedRegex(@"[A-Z]+")]
        public static partial Regex UpperCaseLetter();

        [GeneratedRegex(@"[a-z]+")]
        public static partial Regex LowerCaseLetter();

        [GeneratedRegex(@"[0-9]+")]
        public static partial Regex Number();

        [GeneratedRegex(@"[\!\?\*\.\,]+")]
        public static partial Regex SpecialCharacter();
    }
}
