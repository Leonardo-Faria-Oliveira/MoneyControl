using MoneyControl.Domain.Repositories;

namespace MoneyControl.Infraestructure.DataAccess
{
    internal class UnityOfWork(MoneyControlDbContext context) : IUnityOfWork
    {

        private readonly MoneyControlDbContext _context = context;

        public async Task Commit() => await _context.SaveChangesAsync();
    }
}
