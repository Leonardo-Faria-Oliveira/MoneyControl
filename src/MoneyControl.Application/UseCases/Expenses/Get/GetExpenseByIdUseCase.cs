using AutoMapper;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Repositories.Expenses;
using MoneyControl.Domain.Services.LoggedUsers;
using MoneyControl.Exception;
using MoneyControl.Exception.ExceptionBase;

namespace MoneyControl.Application.UseCases.Expenses.Get
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {

        private readonly IExpensesReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _loggedUser = loggedUser;
            _mapper = mapper;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            
            var expense = await _repository.GetById(id);

            var loggedUser = await _loggedUser.Get();

            if (expense is null || expense.Id != loggedUser.Id)
            {
                throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
            }


            return _mapper.Map<ResponseExpenseJson>(expense);
            
        }

    
    }
}
