using System;

namespace ExpenseTracer.Domain.Entities
{
    /// <summary>
    /// Represents an expense
    /// </summary>
    public class Expense : Common.IEntity
    {
        /// <summary>
        /// Gets or sets the Id of the expense
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the amount of money spent for the expense
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the expense has been recorded
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }
}
