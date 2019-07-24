using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Application.Interfaces;
using ExpenseTracer.Common.Dates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracer.Application.Expenses.Queries.GetExpenseDetails
{
    /// <summary>
    /// Represents the request to access the details of an expense
    /// </summary>
    public class GetExpenseDetailQuery : IRequest<ExpenseDetailViewModel>
    {
        public GetExpenseDetailQuery(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier of the requested expense
        /// </summary>
        public int Id { get; }
    }

    public class GetExpenseDetailQueryHandler : IRequestHandler<GetExpenseDetailQuery, ExpenseDetailViewModel>
    {
        private readonly IDatabaseService databaseService;

        public GetExpenseDetailQueryHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }
        public async Task<ExpenseDetailViewModel> Handle(GetExpenseDetailQuery request, CancellationToken cancellationToken)
        {
            var expense = await this.databaseService.Expenses.SingleOrDefaultAsync(e => e.Id.Equals(request.Id));

            var vm = new ExpenseDetailViewModel()
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Timestamp = expense.Timestamp.Trim(TimeSpan.TicksPerSecond)
            };

            return vm;
        }
    }
}
