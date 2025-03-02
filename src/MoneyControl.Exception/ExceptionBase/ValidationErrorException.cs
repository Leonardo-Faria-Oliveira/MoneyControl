using System.Net;

namespace MoneyControl.Exception.ExceptionBase
{
    public class ValidationErrorException : MoneyControlException
    {

        private readonly ICollection<string> _errors = [];

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public ValidationErrorException(ICollection<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override ICollection<string> GetErrors()
        {
            return _errors;
        }
    }
}
