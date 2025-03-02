using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Application.AutoMapper;
using MoneyControl.Application.UseCases.Expenses.Delete;
using MoneyControl.Application.UseCases.Expenses.Get;
using MoneyControl.Application.UseCases.Expenses.GetAll;
using MoneyControl.Application.UseCases.Expenses.Register;
using MoneyControl.Application.UseCases.Expenses.Update;
using MoneyControl.Application.UseCases.Expenses.Filter;

namespace MoneyControl.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            

            AddUseCases(services);
            AddAutoMapper(services);


        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
            services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
            services.AddScoped<IDeleteExpenseByIdUseCase, DeleteExpenseByIdUseCase>();
            services.AddScoped<IUpdateExpenseByIdUseCase, UpdateExpenseByIdUseCase>();
            services.AddScoped<IFilterByMonthUseCase, FilterByMonthUseCase>();


        }
    }
}
