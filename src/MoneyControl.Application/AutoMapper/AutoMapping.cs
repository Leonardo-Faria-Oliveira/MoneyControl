using AutoMapper;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Entities;

namespace MoneyControl.Application.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestExpenseJson, Expense> ();

            CreateMap<RequestRegisterUserJson, User>().ForMember(entity => entity.Password, config => config.Ignore());
        }


        private void EntityToResponse()
        {
            CreateMap<Expense, ResponseRegisteredExpenseJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
            CreateMap<Expense, ResponseExpenseJson>();

            CreateMap<User, ResponseRegisteredUserJson>();

        }




    }
}
