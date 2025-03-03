
using AutoMapper;
using MoneyControl.Exception.ExceptionBase;
using MoneyControl.Exception;
using MoneyControl.Domain.Repositories;
using MoneyControl.Domain.Repositories.Expenses;
using MoneyControl.Domain.Services.LoggedUsers;

namespace MoneyControl.Application.UseCases.Expenses.Delete
{
    public class DeleteExpenseByIdUseCase : IDeleteExpenseByIdUseCase
    {

        private readonly IExpensesDeleteOnlyRepository _repository;
        private readonly IExpensesReadOnlyRepository _readRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILoggedUser _loggedUser;


        public DeleteExpenseByIdUseCase(IExpensesDeleteOnlyRepository repository, IExpensesReadOnlyRepository readRepository, IUnityOfWork unityOfWork, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _loggedUser = loggedUser;
            _readRepository = readRepository;
        }

        public async Task Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();

            var expense = await _readRepository.GetById(id);

            if(expense is null || expense.Id != loggedUser.Id)
            {
                throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
            }

            await _repository.DeleteById(id);

            await _unityOfWork.Commit();
        }
    }
}
