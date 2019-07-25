using System;
using MediatR;

namespace ExpenseTracer.Application.Expenses.Commands
{
    public class CreateExpenseCommand : IRequest
    {
        public decimal Amount { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}