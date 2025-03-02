

using System.Net;

namespace MoneyControl.Exception.ExceptionBase
{
    public class NotFoundException(string errorMessage) : MoneyControlException(errorMessage)
    {
        public override int StatusCode => (int) HttpStatusCode.NotFound;

        public override ICollection<string> GetErrors()
        {
            return [errorMessage];
        }
    }
}
