using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracer.Application.Interfaces
{
    /// <summary>
    /// Provides the service to read and write persistent data
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Gets or sets a collection of <see cref="Expense"/>
        /// </summary>
        DbSet<Expense> Expenses { get; set; }

        /// <summary>
        /// Saves the changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
