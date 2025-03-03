using Microsoft.EntityFrameworkCore;
using MoneyControl.Domain.Entities;
using MoneyControl.Domain.Repositories.Users;

namespace MoneyControl.Infraestructure.DataAccess.Repositories
{
    internal class UserRepository(MoneyControlDbContext context) : IUsersWriteOnlyRepository, IUsersReadOnlyRepository
    {

        private readonly MoneyControlDbContext _context = context;

        public async Task Add(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task<bool> ExistsActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email); 
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}
