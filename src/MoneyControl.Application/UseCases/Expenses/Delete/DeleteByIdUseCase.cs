
using AutoMapper;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Domain.Repository;
using MoneyControl.Exception.ExceptionBase;
using MoneyControl.Exception;

namespace MoneyControl.Application.UseCases.Expenses.Delete
{
    public class DeleteExpenseByIdUseCase : IDeleteExpenseByIdUseCase
    {

        private readonly IExpensesDeleteOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        

        public DeleteExpenseByIdUseCase(IExpensesDeleteOnlyRepository repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task Execute(long id)
        {
            var isExpenseFound = await _repository.DeleteById(id);

            if (!isExpenseFound)
            {
                throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
            }

            await _unityOfWork.Commit();
        }
    }
}
