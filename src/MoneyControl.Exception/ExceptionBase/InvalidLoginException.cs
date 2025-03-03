
using System.Net;

namespace MoneyControl.Exception.ExceptionBase
{
    public class InvalidLoginException() : MoneyControlException(ResourcesErrorMessages.EMAIL_OR_PASSWORD_INVALID)
    {

        public override int StatusCode => (int) HttpStatusCode.Unauthorized;

        public override ICollection<string> GetErrors()
        {
            return [Message];
        }
    }
}
