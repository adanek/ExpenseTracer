using System;

namespace ExpenseTracer.Application.Expenses.Queries.GetExpenseDetails
{
    public class ExpenseDetailViewModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
