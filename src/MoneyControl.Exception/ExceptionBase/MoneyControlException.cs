namespace MoneyControl.Exception.ExceptionBase
{
    public abstract class MoneyControlException(string errorMessage) : SystemException(errorMessage)
    {

        public abstract int StatusCode { get; }

        public abstract ICollection<string> GetErrors();

    }
}
