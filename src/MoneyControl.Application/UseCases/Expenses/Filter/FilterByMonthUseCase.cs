using AutoMapper;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Repositories.Expenses;

namespace MoneyControl.Application.UseCases.Expenses.Filter
{
    public class FilterByMonthUseCase : IFilterByMonthUseCase
    {

        private readonly IExpensesReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public FilterByMonthUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ResponseExpensesJson> Execute(DateOnly date)
        {
            var expenses = await _repository.FilterByMonth(date);


            return new ResponseExpensesJson
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(expenses),
            };

        }
    }
}
