using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoneyControl.Domain.Entities;

namespace MoneyControl.Infraestructure.DataAccess
{
    internal class MoneyControlDbContext(DbContextOptions<MoneyControlDbContext> options) : DbContext(options)
    {
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<User> Users { get; set; }

    }

}