using AutoMapper;
using MoneyControl.Communication.Enums;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Entities;
using MoneyControl.Domain.Repository;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Exception.ExceptionBase;

namespace MoneyControl.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public RegisterExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
        {

            Validate(request);

            var entity = _mapper.Map<Expense>(request);

           await _repository.Add(entity);
           await _unityOfWork.Commit();

           return _mapper.Map<ResponseRegisteredExpenseJson>(entity);

        }

        private void Validate(RequestExpenseJson request)
        {

            var validator = new ExpenseValidator();

            var validation = validator.Validate(request);

            if (!validation.IsValid) 
            {
                var errorMessages = validation.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ValidationErrorException(errorMessages);
            }

           

        }

      
    }
}
