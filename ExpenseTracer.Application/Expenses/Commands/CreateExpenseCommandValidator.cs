using System.Collections.Generic;
using System.Text;
using ExpenseTracer.Common.Dates;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpenseTracer.Application.Expenses.Commands
{
    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator(IDateTimeProvider dateTimeProvider)
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(e => e.Timestamp).LessThanOrEqualTo(dateTimeProvider.Now);
        }
    }
}
