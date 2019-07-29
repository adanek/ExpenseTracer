using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracer.Application.Interfaces
{
    /// <summary>
    /// Provides the service to read and write persistent data
    /// </summary>
    public interface IDatabaseService : IAsyncTransaction
    {
        /// <summary>
        /// Gets or sets a collection of <see cref="Expense"/>
        /// </summary>
        IRepository<Expense> Expenses { get; }
    }

    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(int id);

        void Add(T entity);

        void Remove(T entity);
    }


    public interface IAsyncTransaction : IDisposable
    {
        /// <summary>
        /// Commits all pending changes
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
