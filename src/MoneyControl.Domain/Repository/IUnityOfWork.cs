namespace MoneyControl.Domain.Repository
{
    public interface IUnityOfWork
    {

        Task Commit();

    }
}
