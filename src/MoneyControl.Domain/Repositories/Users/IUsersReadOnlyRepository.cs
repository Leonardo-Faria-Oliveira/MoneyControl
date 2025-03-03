using MoneyControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Domain.Repositories.Users
{
    public interface IUsersReadOnlyRepository
    {

        Task<bool> ExistsActiveUserWithEmail(string email);

        Task<User?> GetUserByEmail(string email);

    }
}
