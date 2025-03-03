using AutoMapper;
using MoneyControl.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyControl.Domain.Entities;
using MoneyControl.Exception.ExceptionBase;
using MoneyControl.Exception;
using MoneyControl.Application.UseCases.Expenses.Register;
using MoneyControl.Domain.Repositories;
using MoneyControl.Domain.Repositories.Expenses;
using MoneyControl.Domain.Services.LoggedUsers;

namespace MoneyControl.Application.UseCases.Expenses.Update
{
    public class UpdateExpenseByIdUseCase : IUpdateExpenseByIdUseCase
    {

        private readonly IExpensesUpdateOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;


        public UpdateExpenseByIdUseCase(IExpensesUpdateOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task Execute(long id, RequestExpenseJson request)
        {

            Validate(request);

            var loggedUser = await _loggedUser.Get();

            var expense = await _repository.GetById(id);

            if(expense is null || expense.UserId != loggedUser.Id)
            {
                throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
            }

            _mapper.Map(request, expense);

            expense.UserId = loggedUser.Id;

            await _repository.UpdateById(expense);

            await _unityOfWork.Commit();
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
