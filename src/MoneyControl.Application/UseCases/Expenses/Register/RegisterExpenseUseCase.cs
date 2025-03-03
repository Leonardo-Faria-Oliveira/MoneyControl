using AutoMapper;
using MoneyControl.Communication.Enums;
using MoneyControl.Communication.Requests;
using MoneyControl.Communication.Responses;
using MoneyControl.Domain.Entities;
using MoneyControl.Domain.Repositories;
using MoneyControl.Domain.Repositories.Expenses;
using MoneyControl.Domain.Services.LoggedUsers;
using MoneyControl.Exception.ExceptionBase;

namespace MoneyControl.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public RegisterExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
        {

            Validate(request);

            var loggedUser = await _loggedUser.Get();

            var entity = _mapper.Map<Expense>(request);
            entity.UserId = loggedUser.Id;

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
