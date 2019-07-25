using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Application.Interfaces;
using ExpenseTracer.Domain.Entities;
using MediatR;

namespace ExpenseTracer.Application.Expenses.Commands
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Unit>
    {
        private readonly IDatabaseService _databaseService;

        public CreateExpenseCommandHandler(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<Unit> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense() {Amount = request.Amount, Timestamp = request.Timestamp};

            this._databaseService.Expenses.Add(expense);
            await this._databaseService.SaveChangesAsync(CancellationToken.None);

            return Unit.Value;
        }
    }
}