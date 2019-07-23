using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Common.Dates;
using MediatR;

namespace ExpenseTracer.Application.Expenses.Queries
{

    public class GetExpenseListQuery : IRequest<ExpenseListViewModel>
    {
    }

    public class GetExpenseListQueryHandler : IRequestHandler<GetExpenseListQuery, ExpenseListViewModel>
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public GetExpenseListQueryHandler(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }


        public Task<ExpenseListViewModel> Handle(GetExpenseListQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExpenseListViewModel()
            {
                Expenses = new List<ExpenseLookUpModel>()
                {
                    new ExpenseLookUpModel()
                    {
                        Id = 1,
                        Amount = 12.34m,
                        Timestamp = this.dateTimeProvider.Now
                    },

                    new ExpenseLookUpModel()
                    {
                        Id = 2,
                        Amount = 23m,
                        Timestamp = this.dateTimeProvider.Now
                    }
                }
            };

            return Task.FromResult(vm);
        }
    }
}
