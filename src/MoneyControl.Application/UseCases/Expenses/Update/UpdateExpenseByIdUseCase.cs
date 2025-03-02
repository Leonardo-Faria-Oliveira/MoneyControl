using AutoMapper;
using MoneyControl.Communication.Requests;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyControl.Domain.Entities;
using MoneyControl.Exception.ExceptionBase;
using MoneyControl.Exception;
using MoneyControl.Application.UseCases.Expenses.Register;

namespace MoneyControl.Application.UseCases.Expenses.Update
{
    public class UpdateExpenseByIdUseCase : IUpdateExpenseByIdUseCase
    {

        private readonly IExpensesUpdateOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public UpdateExpenseByIdUseCase(IExpensesUpdateOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task Execute(long id, RequestExpenseJson request)
        {

            Validate(request);
            
            var expense = await _repository.GetById(id);

            if(expense is null)
            {
                throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
            }

            _mapper.Map(request, expense);

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
