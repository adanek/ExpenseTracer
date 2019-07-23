using MediatR;

namespace ExpenseTracer.Application.Expenses.Queries.GetExpenseDetails
{
    /// <summary>
    /// Represents the request to access the details of an expense
    /// </summary>
    public class GetExpenseDetailQuery : IRequest<ExpenseViewModel>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the requested expense
        /// </summary>
        public int Id { get; set; }
    }
}
