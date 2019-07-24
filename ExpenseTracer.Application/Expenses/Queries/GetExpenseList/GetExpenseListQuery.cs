using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Application.Interfaces;
using ExpenseTracer.Common.Dates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracer.Application.Expenses.Queries
{

    public class GetExpenseListQuery : IRequest<ExpenseListViewModel>
    {
    }

    public class GetExpenseListQueryHandler : IRequestHandler<GetExpenseListQuery, ExpenseListViewModel>
    {
        private readonly IDatabaseService databaseService;
        private readonly IDateTimeProvider dateTimeProvider;

        public GetExpenseListQueryHandler(IDatabaseService databaseService, IDateTimeProvider dateTimeProvider)
        {
            this.databaseService = databaseService;
            this.dateTimeProvider = dateTimeProvider;
        }


        public async Task<ExpenseListViewModel> Handle(GetExpenseListQuery request, CancellationToken cancellationToken)
        {
            var expenses = await databaseService.Expenses.ToListAsync();

            var result = expenses.Select(e => new ExpenseLookUpModel()
            {
                Id = e.Id,
                Amount = e.Amount,
                Timestamp = e.Timestamp.Trim(TimeSpan.TicksPerMinute)
            });

            var vm = new ExpenseListViewModel() { Expenses = result.ToList() };

            return vm;
        }
    }
}
