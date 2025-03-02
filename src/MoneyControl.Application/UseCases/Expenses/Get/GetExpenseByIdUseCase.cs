using AutoMapper;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Exception;
using MoneyControl.Exception.ExceptionBase;

namespace MoneyControl.Application.UseCases.Expenses.Get
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {

        private readonly IExpensesReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            
            var expense = await _repository.GetById(id);

            if (expense is null)
            {
                throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
            }


            return _mapper.Map<ResponseExpenseJson>(expense);
            
        }

    
    }
}
