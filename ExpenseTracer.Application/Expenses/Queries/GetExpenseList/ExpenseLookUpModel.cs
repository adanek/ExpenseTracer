using System;

namespace ExpenseTracer.Application.Expenses.Queries
{
    public class ExpenseLookUpModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
