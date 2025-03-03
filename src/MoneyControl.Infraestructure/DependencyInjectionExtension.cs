using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Domain.Repository;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Domain.Repository.Users;
using MoneyControl.Domain.Security.Criptography;
using MoneyControl.Domain.Security.Tokens;
using MoneyControl.Infraestructure.DataAccess;
using MoneyControl.Infraestructure.DataAccess.Repositories;
using MoneyControl.Infraestructure.Security;
using MoneyControl.Infraestructure.Security.Tokens;

namespace MoneyControl.Infraestructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration, string connectionStringName, ServerVersion serverVersion)
        {
            AddDbContext(services, configuration, connectionStringName, serverVersion);
            AddRepositories(services);
            AddEncrypters(services);
            AddToken(services, configuration);

        }

        private static void AddEncrypters(IServiceCollection services)
        {
            services.AddScoped<IPasswordEncrypter, Criptography>();
        }

        private static void AddRepositories(IServiceCollection services)
        {

            //Expenses
            services.AddScoped<IExpensesWriteOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpensesReadOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpensesDeleteOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpensesUpdateOnlyRepository, ExpenseRepository>();

            //Unity Of Work
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            //Users
            services.AddScoped<IUsersWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUsersReadOnlyRepository, UserRepository>();

        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration, string connectionStringName, ServerVersion serverVersion)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName) ;
            
            services.AddDbContext<MoneyControlDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Setting:Jwt:ExpiresMinutes");
            var singinKey = configuration.GetValue<string>("Setting:Jwt:SigniningKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, singinKey!));

        }

    }
}
