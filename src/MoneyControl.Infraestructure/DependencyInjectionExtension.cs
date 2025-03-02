using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Domain.Repository;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Infraestructure.DataAccess;
using MoneyControl.Infraestructure.DataAccess.Repositories;

namespace MoneyControl.Infraestructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration, string connectionStringName, ServerVersion serverVersion)
        {
            AddDbContext(services, configuration, connectionStringName, serverVersion);
            AddRepositories(services);

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IExpensesWriteOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpensesReadOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpensesDeleteOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpensesUpdateOnlyRepository, ExpenseRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration, string connectionStringName, ServerVersion serverVersion)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName) ;
            
            services.AddDbContext<MoneyControlDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }

    }
}
