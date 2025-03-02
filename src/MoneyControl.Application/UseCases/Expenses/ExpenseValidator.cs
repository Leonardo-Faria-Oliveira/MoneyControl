using FluentValidation;
using MoneyControl.Communication.Requests;
using MoneyControl.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Application.UseCases.Expenses
{
    public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
    {
        public ExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourcesErrorMessages.TITLE_REQUIRED);
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourcesErrorMessages.AMOUNT_GREATHER_THAN_ZERO);
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourcesErrorMessages.DATE_TODAY_BEFORE);
            RuleFor(expense => expense.Type).IsInEnum().WithMessage(ResourcesErrorMessages.INVALID_PAYMENT_TYPE);
        }
    }
}
