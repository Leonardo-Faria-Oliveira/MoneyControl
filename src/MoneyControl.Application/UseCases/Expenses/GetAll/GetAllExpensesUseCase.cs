using AutoMapper;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyControl.Domain.Repositories.Expenses;
using MoneyControl.Domain.Services.LoggedUsers;

namespace MoneyControl.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpensesUseCase : IGetAllExpensesUseCase
    {
        private readonly IExpensesReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetAllExpensesUseCase(IExpensesReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }


        public async Task<ResponseExpensesJson> Execute()
        {

            var loggedUser = await _loggedUser.Get();
            var expenses = await _repository.GetAll(loggedUser.Id);


            return new ResponseExpensesJson
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(expenses),
            };

        }
    }
}
