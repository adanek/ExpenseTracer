using ExpenseTracer.Domain.Common;

namespace ExpenseTracer.Domain.Entities
{
    /// <summary>
    /// Represents an expense category
    /// </summary>
    public class Category : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category
        /// </summary>
        public string Name { get; set; }
    }
}
